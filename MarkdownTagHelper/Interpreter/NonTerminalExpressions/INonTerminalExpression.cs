using System;
using System.Collections.Generic;
using System.Text;
using Interpreter.TerminalExpressions;

namespace Interpreter.NonTerminalExpressions
{
    public interface INonTerminalExpression : IMarkdownExpression
    {
        List<IMarkdownExpression> Children { get; set; } 
    }
}
