using System;

namespace NumericalIntegration.RPN
{
    internal class RpnCalculator
    {
        public static string InfixToPostfix(string infix)
        {
            string output = "";

            Stack<string> operators = new Stack<string>();

            foreach (var item in infix.Split(' '))
            {
                if (double.TryParse(item, out _))
                {
                    output += item + " ";
                }

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

        public static string InfixToPostfix(string infix, double variable)
        {
            string output = "";

            Stack<string> operators = new Stack<string>();

            foreach (var item in infix.Split(' '))
            {
                if (double.TryParse(item, out _))
                {
                    output += item + " ";
                }

                else if (item.ToLower() == "x")
                {
                    output += variable + " ";
                }

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
            Stack<double> operandStack = new Stack<double>();

            foreach (var item in expression.Split(' '))
            {
                if (double.TryParse(item, out double operand))
                {
                    operandStack.Push(operand);
                }

                else
                {
                    double op2 = operandStack.Pop();
                    double op1 = operandStack.Pop();
                    double output = Evaluate(op1, op2, item);
                    operandStack.Push(output);
                }
            }

            return operandStack.Pop();
        }

        public static double PostfixEvaluator(string expression, double variable)
        {
            Stack<double> operandStack = new Stack<double>();

            foreach (var item in expression.Split(' '))
            {
                if (double.TryParse(item, out double operand))
                {
                    operandStack.Push(operand);
                }

                if (item.ToLower() == "x")
                {
                    operandStack.Push(variable);
                }

                else
                {
                    double op2 = operandStack.Pop();
                    double op1 = operandStack.Pop();
                    double output = Evaluate(op1, op2, item);
                    operandStack.Push(output);
                }
            }

            return operandStack.Pop();
        }

        public static double Evaluate(double operand1, double operand2, string operation)
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

        public static string Associativity(string op)
        {
            return op == "^" ? "right" : "left";
        }

        public static int Precedence(string op)
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
