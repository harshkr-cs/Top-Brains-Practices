// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter expression (a op b): ");
        string exp = Console.ReadLine();

        Console.WriteLine(EvalArithmeticExp(exp));
    }

    static string EvalArithmeticExp(string exp)
    {
        if (string.IsNullOrWhiteSpace(exp))
            return "Error:InvalidExpression";

        string[] parts = exp.Split(' ');

        // Format must be exactly: a op b
        if (parts.Length != 3)
            return "Error:InvalidExpression";

        // Validate numbers
        if (!int.TryParse(parts[0], out int a) ||
            !int.TryParse(parts[2], out int b))
            return "Error:InvalidNumber";

        string op = parts[1];

        switch (op)
        {
            case "+":
                return (a + b).ToString();

            case "-":
                return (a - b).ToString();

            case "*":
                return (a * b).ToString();

            case "/":
                if (b == 0)
                    return "Error:DivideByZero";
                return (a / b).ToString(); 

            default:
                return "Error:UnknownOperator";
        }
    }
}

