﻿using System;
using PreMarkerShort.Interfaces;

namespace PreMarkerShort.Print
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}