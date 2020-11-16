using System;
using System.Collections.Generic;
using System.Linq;
using PreMarkerShort.Interfaces;

namespace PreMarkerShort.Core
{
    public class CommandManager : ICommandManager
    {
        public readonly List<ICommand> Commands = new List<ICommand>();
        private int _lastExecutedCommandPosition;

        public void ExecuteCommand(ICommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            RemoveAllRevertedCommand();

            Commands.Add(command);
            command.Execute();

            _lastExecutedCommandPosition = Commands.Count - 1;
        }
        public void Undo()
        {
            if (!Commands.Any())
            {
                return;
            }

            if (_lastExecutedCommandPosition < 0)
            {
                return;
            }

            Commands[_lastExecutedCommandPosition].Undo();
            _lastExecutedCommandPosition--;
        }

        public void Redo()
        {
            if (!Commands.Any())
            {
                return;
            }

            if (_lastExecutedCommandPosition >= Commands.Count)
            {
                return;
            }
            Commands[_lastExecutedCommandPosition + 1].Execute();
            _lastExecutedCommandPosition++;
        }

        private void RemoveAllRevertedCommand()
        {
            Commands.RemoveAll(c => Commands.IndexOf(c) > _lastExecutedCommandPosition);
        }
    }
}