using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Array_DS
{

    // Complete the reverseArray function below.
    static int[] reverseArray(int[] a)
    {

        int swap = 0;
        for (int i = 0; i < a.Length/2; i++)
        {
            swap = a[i];
            a[i] = a[a.Length -1 - i];
            a[a.Length - 1 - i] = swap;
        }

    return a;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int[] res = reverseArray(arr);

        Console.WriteLine(string.Join(" ", res));

        Console.ReadLine();
       // textWriter.Flush();
       // textWriter.Close();
    }
}

