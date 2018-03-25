using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.TerminalExpressions;

namespace Interpreter.NonTerminalExpressions
{
    public class Paragraph:INonTerminalExpression
    {
        public List<IMarkdownExpression> Children { get; set; } = new List<IMarkdownExpression>();

        public string Interpret()
        {
            string output = "<p>";
            foreach (IMarkdownExpression child in Children)
            {
                output += child.Interpret();
            }
            output += "</p>";
            return output;
        }
    }
}
