using Interpreter.NonTerminalExpressions;
using Interpreter.TerminalExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.ChildrenParsers
{
    public class MediaParser : ChildrenParser
    {
        string _src = "";
        string _alt = "";

        public override (string, INonTerminalExpression) ParseString(ParsingMode mode, INonTerminalExpression parrentNode, string text, char character)
        {
            if (mode == ParsingMode.Src || mode == ParsingMode.Href)
            {
                _src += character;
                text += character;
            }
            else if (mode == ParsingMode.BeginAlt || mode == ParsingMode.BeginNestedText
                || mode == ParsingMode.EndAlt || mode == ParsingMode.EndNestedText)
            {
                _alt += character;
                text += character;
            }
            else if (mode == ParsingMode.AddMediaNode)
            {
                var MakeChildNodeResult = MakeChildNode(text, _alt, _src, mode, parrentNode);
                _src = "";
                _alt = "";
                return CallSuccesor(mode, parrentNode, MakeChildNodeResult.text, character);
            }
            return CallSuccesor(mode, parrentNode, text, character);
        }

        (string, INonTerminalExpression) CallSuccesor(ParsingMode mode, INonTerminalExpression parrentNode, string text, char character)
        {
            if (Succesor != null)
            {
                return Succesor.ParseString(mode, parrentNode, text, character);
            }
            return (text, parrentNode);
        }

        (INonTerminalExpression parrentNode, string text) MakeChildNode(string text, string alt, string src, ParsingMode mode, INonTerminalExpression parrentNode)
        {
            text = text.Replace(alt, "").Replace(src, "");
            string paramB = alt.Replace("!", "").Replace("[", "").Replace("]", "");
            string paramA = src.Replace("(", "");
            if (text != "")
            {
                parrentNode.Children.Add(new Text(text));
            }
            text = "";
            if (alt.StartsWith('!'))
            {
                parrentNode.Children.Add(new Image(paramA, paramB));

            }
            else if (alt.StartsWith('['))
            {
                parrentNode.Children.Add(new Link(paramA, paramB));
            }

            return (parrentNode, text);
        }

        public override ParsingMode SwitchMode(ParsingMode mode, char character)
        {
            switch (character)
            {
                case '!':
                    mode = ParsingMode.BeginAlt;
                    break;
                case '[':
                    if (mode != ParsingMode.BeginAlt)
                    {
                        mode = ParsingMode.BeginNestedText;
                    }
                    break;
                case ']':
                    if (mode == ParsingMode.BeginAlt)
                    {
                        mode = ParsingMode.EndAlt;
                    }
                    else if (mode == ParsingMode.BeginNestedText)
                    {
                        mode = ParsingMode.EndNestedText;
                    }
                    break;
                case '(':
                    if (mode == ParsingMode.EndAlt)
                    {
                        mode = ParsingMode.Src;
                    }
                    else if (mode == ParsingMode.EndNestedText)
                    {
                        mode = ParsingMode.Href;
                    }
                    break;
                case ')':
                    mode = ParsingMode.AddMediaNode;
                    break;
            }
            if(Succesor != null)
            {
                return Succesor.SwitchMode(mode, character);
            }
            return mode;
        }
    }
}
