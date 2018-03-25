using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.TerminalExpressions;

namespace Interpreter.NonTerminalExpressions
{
    public class Document : INonTerminalExpression
    {
        public List<IMarkdownExpression> Children { get; set; } = new List<IMarkdownExpression>();

        public string Interpret()
        {
            string document = "";
            foreach (var child in Children)
            {
                document += child.Interpret();
            }
            return document;
        }
    }
}
