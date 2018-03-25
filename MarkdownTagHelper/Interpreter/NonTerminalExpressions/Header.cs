using System;
using System.Collections.Generic;
using Interpreter.TerminalExpressions;

namespace Interpreter.NonTerminalExpressions
{
    public class Header : INonTerminalExpression
    {
        int _level = 0;
        public List<IMarkdownExpression> Children { get; set; } = new List<IMarkdownExpression>();

        public string Interpret()
        {
            string output = $"<h{_level}>";
            foreach (IMarkdownExpression child in Children)
            {
                output += child.Interpret();
            }
            output += $"</h{_level}>";
            return output;
        }

        public Header(int level)
        {
            _level = level;
        }
    }
}
