using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.TerminalExpressions
{
    public class Link : IMarkdownExpression
    {
        string _reference;
        string _text;

        public string Interpret()
        {
            return $"<a href=\"{_reference}\">{_text}</a>";
        }

        public Link(string reference, string text)
        {
            _reference = reference;
            _text = text;
        }
    }
}
