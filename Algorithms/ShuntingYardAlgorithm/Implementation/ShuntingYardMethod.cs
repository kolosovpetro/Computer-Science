using System.Collections.Generic;
using System.Linq;
using static ShuntingYardAlgorithm.Implementation.Operator;

namespace ShuntingYardAlgorithm.Implementation
{
    public static class ShuntingYardMethod
    {
        public static Queue<char> InfixToPostfix(string input)
        {
            var outputQueue = new Queue<char>();
            var operandStack = new Stack<char>();

            foreach (var token in input)
            {
                // if token is number - add to output queue
                if (int.TryParse(token.ToString(), out var number))
                {
                    outputQueue.Enqueue(token);
                    continue;
                }

                // if token is '(' - add to operand stack
                if (token == '(')
                {
                    operandStack.Push(token);
                    continue;
                }

                // if token is ')' - add from stack to queue while '(' found, then just pop
                if (token == ')')
                {
                    while (operandStack.Peek() != '(')
                    {
                        outputQueue.Enqueue(operandStack.Pop());
                    }

                    operandStack.Pop();
                    continue;
                }

                // if token is an operator and stack is not empty
                while (operandStack.Any()
                       && (Precedence(operandStack.Peek()) > Precedence(token) ||
                           Precedence(operandStack.Peek()) == Precedence(token))
                       && Associativity(token) == "Left")
                {
                    outputQueue.Enqueue(operandStack.Pop());
                }

                operandStack.Push(token);
            }

            while (operandStack.Any())
            {
                outputQueue.Enqueue(operandStack.Pop());
            }

            return outputQueue;
        }
    }
}