using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.TerminalExpressions
{
    public class Image : IMarkdownExpression
    {
        string _source;
        string _altSource;

        public Image(string source, string altSource)
        {
            _source = source;
            _altSource = altSource;
        }

        public string Interpret()
        {
            return $"<img src=\"{_source}\" alt=\"{_altSource}\"/>";
        }
    }
}
