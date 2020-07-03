using System;
using System.Linq;

namespace ShuntingYardAlgorithm.Implementation
{
    public static class Operator
    {
        private static readonly char[] Operators = {'^', '*', '/', '+', '-'};

        public static int Precedence(char @operator)
        {
            return @operator switch
            {
                '^' => 4,
                '*' => 3,
                '/' => 3,
                '+' => 2,
                '-' => 2,
                _ => 0
            };
        }

        public static string Associativity(char @operator)
        {
            return @operator switch
            {
                '^' => "Right",
                '*' => "Left",
                '/' => "Left",
                '+' => "Left",
                '-' => "Left",
                _ => throw new InvalidOperationException($"Char {@operator} is not an operator")
            };
        }

        public static bool IsOperator(char @operator)
        {
            return Operators.Contains(@operator);
        }
    }
}