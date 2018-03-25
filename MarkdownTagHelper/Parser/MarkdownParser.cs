using Interpreter.NonTerminalExpressions;
using Interpreter.TerminalExpressions;
using Parser.ChildrenParsers;
using Parser.ParrentParsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class MarkdownParser
    {
        ParrentParser _parrentParser;
        ChildrenParser _childrenParser;

        public MarkdownParser(ParrentParser parrentParser, ChildrenParser childrenParser)
        {
            _parrentParser = parrentParser;
            _childrenParser = childrenParser;
        }

        public INonTerminalExpression Parse(string input)
        {
            string[] text = input.Split("\n");
            INonTerminalExpression document = new Document();

            foreach (string line in text)
            {
                string parsedText = "";
                (document, parsedText) = _parrentParser.Parse(document, line);
                if (parsedText != "")
                {
                    document.Children[document.Children.Count - 1] = ParseChildren(document.Children[document.Children.Count - 1] as INonTerminalExpression, parsedText);
                }
            }
            return document;
        }



        List<INonTerminalExpression> AddParrentNode(INonTerminalExpression newParrent, INonTerminalExpression oldParrent, List<INonTerminalExpression> document)
        {
            if (newParrent.Equals(oldParrent) )
            {
                document.Add(oldParrent);
            }
            return document;
        }

        INonTerminalExpression ParseChildren(INonTerminalExpression parrentNode, string text)
        {
            ChildrenParser.ParsingMode mode = ChildrenParser.ParsingMode.Text;
            text += "\n";
            string parsedText = "";
            foreach (char character in text)
            {
                mode = _childrenParser.SwitchMode(mode, character);
                (parsedText, parrentNode) = _childrenParser.ParseString(mode, parrentNode, parsedText, character);
            }
            if (parsedText != "")
            {
                parrentNode.Children.Add(new Text(parsedText));
            }
            return parrentNode;
        }
    }
}


