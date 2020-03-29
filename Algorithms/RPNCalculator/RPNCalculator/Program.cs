using System;

namespace RPNCalculator
{
    internal class Program
    {
        private static void Main()
        {
            /*Console.WriteLine("Hello, this is RPN calculator");
            string expression = "2 3 5 + *";
            double expectedOutput = 16;
            double output = PostfixEvaluator(expression);
            Console.WriteLine("Expression: {0}", expression);
            Console.WriteLine("Expected output: {0}", expectedOutput);
            Console.WriteLine("Output: {0}", output);
            */

            Console.WriteLine("And now to transforming infix to postfix");
            const string infix = "2 * 3 ^ 4";
            const string expectedPostfix = "2 3 +";
            string postfix = InfixToPostfix(infix);
            double postfixOutput = PostfixEvaluator(postfix);

            Console.WriteLine("Infix: {0}", infix);
            Console.WriteLine("Expected postfix: {0}", expectedPostfix);
            Console.WriteLine("Postfix: {0}", postfix);
            Console.WriteLine("Output: {0}", postfixOutput);

        }

        private static string InfixToPostfix(string infix)
        {
            string output = "";

            Stack<string> operators = new Stack<string>();

            foreach (var item in infix.Split(' '))
            {
                if (double.TryParse(item, out _))
                {
                    output += item + " ";
                }

                else if (item == "(")
                {
                    operators.Push(item);
                }

                else if (item == ")")
                {
                    while (operators.Peek() != "(")
                    {
                        output += operators.Pop() + " ";
                    }

                    //This is to remove opening bracket from the stack

                    operators.Pop();
                }

                else
                {
                    while (!operators.IsEmpty() && (Precedence(operators.Peek()) > Precedence(item) || Precedence(operators.Peek()) == Precedence(item) && Associativity(item) == "left"))
                    {
                        output += operators.Pop() + " ";
                    }

                    operators.Push(item);
                }
            }

            while (!operators.IsEmpty())
            {
                output += operators.Pop() + " ";
            }

            output = output.TrimEnd(' ');
            return output;
        }

        private static double PostfixEvaluator(string expression)
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

        public static double Evaluate(double op1, double op2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return op1 + op2;
                case "-":
                    return op1 - op2;
                case "*":
                    return op1 * op2;
                case "/":
                    return op1 / op2;
                case "^":
                    return Math.Pow(op1, op2);
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


    public class Stack<T>
    {
        private int _count;
        private readonly T[] _elements;

        public Stack()
        {
            _count = 0;
            _elements = new T[10];
        }

        public void Push(T value)
        {
            _elements[_count] = value;
            _count++;
        }

        public T Peek()
        {
            return _elements[_count - 1];
        }

        public T Pop()
        {
            _count--;
            return _elements[_count];
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }
    }
}
