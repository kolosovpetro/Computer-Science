using System;

namespace NumericalIntegration
{
    class RPNCalculator
    {
        public static string InfixToPostfix(string infix)
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
                    while (!Operators.IsEmpty() 
                        && (Precedence(Operators.Peek()) > Precedence(item) 
                        || Precedence(Operators.Peek()) == Precedence(item) 
                        && Associativity(item) == "left"))
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
        public static string InfixToPostfix(string infix, double Variable)
        {
            string output = "";
            Stack<string> Operators = new Stack<string>();
            foreach (var item in infix.Split(' '))
            {
                if (double.TryParse(item, out double op))
                {
                    output += item + " ";
                }
                else if (item.ToLower() == "x")
                {
                    output += Variable + " ";
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
                    while (!Operators.IsEmpty() 
                        && (Precedence(Operators.Peek()) > Precedence(item) 
                        || Precedence(Operators.Peek()) == Precedence(item) 
                        && Associativity(item) == "left"))
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
        public static double PostfixEvaluator(string expression)
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
        public static double PostfixEvaluator(string expression, double Variable)
        {
            Stack<double> OperandStack = new Stack<double>();
            foreach (var item in expression.Split(' '))
            {
                if (double.TryParse(item, out double operand))
                {
                    OperandStack.Push(operand);
                }

                if (item.ToLower() == "x")
                {
                    OperandStack.Push(Variable);
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
}
