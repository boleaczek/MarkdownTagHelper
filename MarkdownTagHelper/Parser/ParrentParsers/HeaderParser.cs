using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.NonTerminalExpressions;

namespace Parser.ParrentParsers
{
    public class HeaderParser : ParrentParser
    {
        public override (INonTerminalExpression parrentTag, string text) Parse(INonTerminalExpression parrentTag, string text)
        {
            int headerLevel = 0;
            if (text.Length > 0)
            {
                while (headerLevel < text.Length && text[headerLevel] == '#')
                {
                    headerLevel++;
                }
            }
            if(headerLevel <= 6 && headerLevel > 0)
            {
                parrentTag.Children.Add(new Header(headerLevel));
                return (parrentTag, text.Remove(0, headerLevel));
            }
            else
            {
                if(Succesor != null)
                {
                    return Succesor.Parse(parrentTag, text);
                }
                else
                {
                    return (parrentTag, text);
                }
            }
        }
    }
}
