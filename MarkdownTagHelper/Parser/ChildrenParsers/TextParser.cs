using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.NonTerminalExpressions;

namespace Parser.ChildrenParsers
{
    public class TextParser : ChildrenParser
    {
        public override (string, INonTerminalExpression) ParseString(ParsingMode mode, INonTerminalExpression parrentNode, string text, char character)
        {
            if (mode == ParsingMode.Text)
            {
                text += character;
            }

            if (Succesor != null)
            {
                return Succesor.ParseString(mode, parrentNode, text, character);
            }
            else
            {
                return (text, parrentNode);
            }
        }

        public override ParsingMode SwitchMode(ParsingMode mode, char character)
        {
            if (mode == ParsingMode.AddMediaNode && character != ')')
            {
                return ParsingMode.Text;
            }
            else
            {
                if (Succesor != null)
                {
                    return Succesor.SwitchMode(mode, character);
                }
                else
                {
                    return mode;
                }
            }
        }
    }
}
