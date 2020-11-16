using System;
using Moq;
using NUnit.Framework;
using PreMarkerShort.Core;
using PreMarkerShort.Interfaces;

namespace PreMarkerShort.Tests
{
    [TestFixture]
    public class CommandManagerTest
    {
        [Test]
        public void ExecuteCommand_WithNullCommand_ArgumentNullException()
        {
            var commManager = new CommandManager();

            var ex = Assert.Throws<ArgumentNullException>(() => commManager.ExecuteCommand(null)); 
            Assert.That(ex.Message.Contains("command"));
        }

        [Test]
        public void ExecuteCommand_WithCorrectCommand_CorrectCommandExecuting()
        {
            const int expectedValue = 12;
            var actualValue = 11;
            var commManager = new CommandManager();

            var moqCommand = new Mock<ICommand>();
            moqCommand.Setup(comm => comm.Execute())
                .Callback(() => { actualValue = expectedValue; });

            commManager.ExecuteCommand(moqCommand.Object);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Undo_WithCorrect3ExecutedCommands_CorrectUndo()
        {
            const int expectedValue = 11;
            var actualValue = new TestEntity{ Value = 15};
            var commManager = new CommandManager();
            
            var moqCommand1 = CreateCommand(actualValue, 44);
            commManager.ExecuteCommand(moqCommand1);
            var moqCommand2 = CreateCommand(actualValue, expectedValue);
            commManager.ExecuteCommand(moqCommand2);
            var moqCommand3 = CreateCommand(actualValue, 99);
            commManager.ExecuteCommand(moqCommand3);

            commManager.Undo();

            Assert.AreEqual(expectedValue, actualValue.Value);
        }

        [Test]
        public void Redo_With2PreviousUndo_CorrectRedo()
        {
            const int expectedValue = 33;
            var actualValue = new TestEntity { Value = 15 };
            var commManager = new CommandManager();

            var moqCommand1 = CreateCommand(actualValue, 44);
            commManager.ExecuteCommand(moqCommand1);
            var moqCommand2 = CreateCommand(actualValue, expectedValue);
            commManager.ExecuteCommand(moqCommand2);
            var moqCommand3 = CreateCommand(actualValue, 99);
            commManager.ExecuteCommand(moqCommand3);

            commManager.Undo();
            commManager.Undo();
            commManager.Redo();

            Assert.AreEqual(expectedValue, actualValue.Value);
        }

        private ICommand CreateCommand(TestEntity testEntity, int newValue)
        {
            var startValue = testEntity.Value;

            var moqCommand = new Mock<ICommand>();
            moqCommand.Setup(comm => comm.Execute())
                .Callback(() => { testEntity.Value = newValue; });

            moqCommand.Setup(comm => comm.Undo())
                .Callback(() => { testEntity.Value = startValue; });

            return moqCommand.Object;
        }

        private class TestEntity
        {
            public int Value { get; set; }
        }
    }
}
