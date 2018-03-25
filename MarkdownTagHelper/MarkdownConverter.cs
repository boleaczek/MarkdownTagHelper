using Interpreter.NonTerminalExpressions;
using Parser.ChildrenParsers;
using Parser.ParrentParsers;
using Parser;
using System;

namespace Converter
{
    public class MarkdownConverter
    {
        public string ConvertMarkdown(string markdown)
        {
            ParrentParser parrentParser = new HeaderParser();
            parrentParser.Succesor = new ParagraphParser();
            ChildrenParser childrenParser = new TextParser();
            childrenParser.Succesor = new MediaParser();
            INonTerminalExpression document =  new MarkdownParser(parrentParser, childrenParser).Parse(markdown);
            return document.Interpret();
        }
    }
}
