using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreter.TerminalExpressions
{
    public interface IMarkdownExpression
    {
        string Interpret();
    }
}
