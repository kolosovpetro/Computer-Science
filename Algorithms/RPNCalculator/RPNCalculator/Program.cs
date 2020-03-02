using System;

namespace RPNCalculator
{
    class Program
    {
        static void Main(string[] args)
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
            string infix = "2 * 3 ^ 4";
            string expectedPostfix = "2 3 +";
            string postfix = InfixToPostfix(infix);
            double outputpostfix = PostfixEvaluator(postfix);
            Console.WriteLine("Infix: {0}", infix);
            Console.WriteLine("Expected postfix: {0}", expectedPostfix);
            Console.WriteLine("Postfix: {0}", postfix);
            Console.WriteLine("Output: {0}", outputpostfix);

        }
        static string InfixToPostfix(string infix)
        {
            string output = "";
            Stack<string> Operators = new Stack<string>();
            foreach (var item in infix.Split(' '))
            {
                if (double.TryParse(item, out double op))
                {
                    output += item + " ";
                }
                else if (item == "(")
                {
                    Operators.Push(item);
                }
                else if (item == ")")
                {
                    while (Operators.Peek() != "(")
                    {
                        output += Operators.Pop() + " ";
                    }
                    //This is to remove opening bracket from the stack
                    Operators.Pop();
                }
                else
                {
                    while (!Operators.IsEmpty() && (Precedence(Operators.Peek()) > Precedence(item) || Precedence(Operators.Peek()) == Precedence(item) && Associativity(item) == "left"))
                    {
                        output += Operators.Pop() + " ";
                    }

                    Operators.Push(item);
                }
            }
            while (!Operators.IsEmpty())
            {
                output += Operators.Pop() + " ";
            }
            output = output.TrimEnd(' ');
            return output;
        }
        static double PostfixEvaluator(string expression)
        {
            Stack<double> OperandStack = new Stack<double>();
            foreach (var item in expression.Split(' '))
            {
                if (double.TryParse(item, out double operand))
                {
                    OperandStack.Push(operand);
                }
                else
                {
                    double op2 = OperandStack.Pop();
                    double op1 = OperandStack.Pop();
                    double output = Evaluate(op1, op2, item);
                    OperandStack.Push(output);
                }
            }
            return OperandStack.Pop();

        }
        public static double Evaluate(double op1, double op2, string oper)
        {
            if (oper == "+")
            {
                return op1 + op2;
            }
            else if (oper == "-")
            {
                return op1 - op2;
            }
            else if (oper == "*")
            {
                return op1 * op2;
            }
            else if (oper == "/")
            {
                return op1 / op2;
            }
            else if (oper=="^")
            {
                return Math.Pow(op1, op2);
            }
            else
            {
                return 0;

            }
        
        }
        public static string Associativity(string op)
        {
            if(op=="^")
            {
                return "right";
            }
            else
            {
                return "left";
            }
        }
        public static int Precedence(string op)
        {
            if (op == "^")
            {
                return 4;
            }

            else if (op == "/" || op == "*")
            {
                return 3;
            }
            else if (op == "+" || op == "-")
            {
                return 2;
            }
            return -1;
        }
    }


    public class Stack<T>
    {
        int count;
        T[] elements;

        public Stack()
        {
            count = 0;
            elements = new T[10];
        }

        public void Push(T value)
        {
            elements[count] = value;
            count++;
        }

        public T Peek()
        {
            return elements[count - 1];
        }

        public T Pop()
        {
            count--;
            return elements[count];
        }

        public bool IsEmpty()
        {
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
