using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.NonTerminalExpressions;
using Interpreter.TerminalExpressions;

namespace Parser.ParrentParsers
{
    public class ParagraphParser : ParrentParser
    {
        public override (INonTerminalExpression parrentTag, string text) Parse(INonTerminalExpression parrentTag, string text)
        {
            if(parrentTag.Children.Count == 0)
            {
                parrentTag.Children.Add(new Paragraph());
                return (parrentTag, text);
            }
            IMarkdownExpression previousTag = parrentTag.Children[parrentTag.Children.Count - 1];
            if (text == "" || previousTag == null || previousTag.GetType() == typeof(Header))
            {
                parrentTag.Children.Add(new Paragraph());
                return (parrentTag, text);
            }
            else
            {
                return (parrentTag, text);
            }
        }
    }
}
