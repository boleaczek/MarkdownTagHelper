using Interpreter.NonTerminalExpressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.ParrentParsers
{

    public abstract class ParrentParser
    {
        public ParrentParser Succesor { get; set; }
        public abstract (INonTerminalExpression parrentTag, string text) Parse(INonTerminalExpression parrentTag, string text);
    }
}
