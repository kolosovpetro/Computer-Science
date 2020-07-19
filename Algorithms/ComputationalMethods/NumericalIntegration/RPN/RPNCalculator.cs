using System;

namespace NumericalIntegration.RPN
{
    internal static class RpnCalculator
    {
        public static string InfixToPostfix(string infix)
        {
            var output = "";

            var operators = new Stack<string>();

            foreach (var item in infix.Split(' '))
            {
                if (double.TryParse(item, out _))
                    output += item + " ";

                else
                    switch (item)
                    {
                        case "(":
                            operators.Push(item);
                            break;
                        case ")":
                            {
                                while (operators.Peek() != "(") 
                                    output += operators.Pop() + " ";

                                // This is to remove opening bracket from the stack

                                operators.Pop();
                                break;
                            }

                        default:
                            {
                                while (!operators.IsEmpty()
                                       && (Precedence(operators.Peek()) > Precedence(item)
                                           || Precedence(operators.Peek()) == Precedence(item)
                                           && Associativity(item) == "left"))
                                {
                                    output += operators.Pop() + " ";
                                }

                                operators.Push(item);
                                break;
                            }
                    }
            }

            while (!operators.IsEmpty())
            {
                output += operators.Pop() + " ";
            }

            output = output.TrimEnd(' ');

            return output;
        }

        public static string InfixToPostfix(string infix, double variable)
        {
            var output = "";

            var operators = new Stack<string>();

            foreach (var item in infix.Split(' '))
            {
                if (double.TryParse(item, out _))
                    output += item + " ";

                else if (item.ToLower() == "x")
                    output += variable + " ";

                else
                    switch (item)
                    {
                        case "(":
                            operators.Push(item);
                            break;
                        case ")":
                            {
                                while (operators.Peek() != "(")
                                {
                                    output += operators.Pop() + " ";
                                }

                                // This is to remove opening bracket from the stack

                                operators.Pop();
                                break;
                            }
                        default:
                            {
                                while (!operators.IsEmpty()
                                       && (Precedence(operators.Peek()) > Precedence(item)
                                           || Precedence(operators.Peek()) == Precedence(item)
                                           && Associativity(item) == "left"))
                                {
                                    output += operators.Pop() + " ";
                                }

                                operators.Push(item);
                                break;
                            }
                    }
            }

            while (!operators.IsEmpty())
            {
                output += operators.Pop() + " ";
            }

            output = output.TrimEnd(' ');
            return output;
        }

        public static double PostfixEvaluator(string expression)
        {
            var operandStack = new Stack<double>();

            foreach (var item in expression.Split(' '))
            {
                if (double.TryParse(item, out double operand))
                {
                    operandStack.Push(operand);
                }

                else
                {
                    var op2 = operandStack.Pop();
                    var op1 = operandStack.Pop();
                    var output = Evaluate(op1, op2, item);
                    operandStack.Push(output);
                }
            }

            return operandStack.Pop();
        }

        private static double Evaluate(double operand1, double operand2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                case "^":
                    return Math.Pow(operand1, operand2);
                default:
                    return 0;
            }
        }

        private static string Associativity(string op)
        {
            return op == "^" ? "right" : "left";
        }

        private static int Precedence(string op)
        {
            switch (op)
            {
                case "^":
                    return 4;
                case "/":
                case "*":
                    return 3;
                case "+":
                case "-":
                    return 2;
                default:
                    return -1;
            }
        }
    }
}
