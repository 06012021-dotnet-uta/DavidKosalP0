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

class Result
{

    /*
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int diagonalDifference(List<List<int>> arr)
    {
        //initialize for left diagonal
        int leftSum = 0;
        int leftRow;
        int leftColumn = 0;
        
        //initialize for right diagonal
        int rightSum = 0;
        int rightRow;
        int rightColumn = arr.Count - 1;
        
        //takes the number at [0,0] and sums the numbers going down 1 and left 1
        for(leftRow = 0; leftRow < arr.Count; leftRow++){
            leftSum = leftSum + arr[leftRow][leftColumn];
            leftColumn++;
        }
        
        //takes the number at [0,3] and sums the numbers going down 1 and right 1
        for(rightRow = 0; rightRow < arr.Count; rightRow++){
            rightSum = rightSum + arr[rightRow][rightColumn];
            rightColumn--;
        }
        
        //returns the absolute value of the difference between the 2 diagonals
        return Math.Abs(leftSum - rightSum);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
