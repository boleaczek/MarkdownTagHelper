using Interpreter.NonTerminalExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.ChildrenParsers
{
    public abstract class ChildrenParser
    {
        public enum ParsingMode
        {
            BeginAlt,
            BeginNestedText,
            EndAlt,
            EndNestedText,
            Text,
            Src,
            Href,
            AddMediaNode
        }

        public ChildrenParser Succesor;
        public abstract ParsingMode SwitchMode(ParsingMode mode, char character);
        public abstract (string,INonTerminalExpression) ParseString(ParsingMode mode, INonTerminalExpression parrentNode, string text, char character);
    }
}
