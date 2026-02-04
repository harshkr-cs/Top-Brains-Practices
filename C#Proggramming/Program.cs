// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static bool IsVowel(char ch)
    {
        ch=char.ToLower(ch);
        return ch == 'a' ||ch == 'e'|| ch == 'i'||ch == 'o' ||ch == 'u';
    }
    static void Main()
    {
        string word1=Console.ReadLine();
        string word2=Console.ReadLine();
        HashSet<char> consonantsInWord2 =new HashSet<char>();
        foreach (char c in word2)
        {
            char lower=char.ToLower(c);
            if (!IsVowel(lower))
            consonantsInWord2.Add(lower);
        }
        StringBuilder filtered=new StringBuilder();
        foreach (char c in word1)
        {
            char lower=char.ToLower(c);
            if (!IsVowel(lower) && consonantsInWord2.Contains(lower))
            continue;
            filtered.Append(c);
        }
        StringBuilder result=new StringBuilder();
        for (int i=0;i<filtered.Length;i++)
        {
            if (i==0 || filtered[i]!=filtered[i-1])
                result.Append(filtered[i]);
        }
        Console.WriteLine(result.ToString());
    }
}
