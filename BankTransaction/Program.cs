// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    public static int BankTransaction(int initialBalance,int[] transactions)
    {
        int balance=initialBalance;
        foreach(int it in transactions)
        {
            if(it>=0)
            {
                balance+=it;
            }
            else
            {
                if (balance + it >= 0)
                {
                    balance+=it;
                }
            }
        }
        return balance;
    }
    static void Main()
    {
        int initialBalance=100;
        int[] transaction={50,-30,-150,20};
        int finalBalance=BankTransaction(initialBalance,transaction);
        Console.WriteLine("Final Balance: "+finalBalance);
    }
}
