using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.TerminalExpressions
{
    public class Text : IMarkdownExpression
    {
        string _text;

        public string Interpret()
        {
            return _text;
        }

        public Text(string text)
        {
            _text = text;
        }
    }
}
