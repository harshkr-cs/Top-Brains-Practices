// See https://aka.ms/new-console-template for more information
﻿using System;
using System.Text;
using System.Globalization;
class Program
{
    static void Main()
    {
        string input=Console.ReadLine();
        input=input.Trim();
        StringBuilder sb=new StringBuilder();
        for(int i = 0; i < input.Length; i++)
        {
            if(i==0||input[i]!=input[i-1])
            sb.Append(input[i]);
        }
        string cleaned=string.Join(" ",sb.ToString().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries));
        TextInfo textInfo=CultureInfo.CurrentCulture.TextInfo;
        cleaned=textInfo.ToTitleCase(cleaned.ToLower());
        Console.WriteLine(cleaned);
    }
}
