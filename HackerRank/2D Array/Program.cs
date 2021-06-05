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
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
        int sum = 0;
        int row;
        int column;
        int x = 0;
        int y = 0;
        int[] hourglass = new int[16];
        int i = 0;
        int j;
        int maxSum = 0;
        
        //moves the hourglass down by 1 row
        for(row = 0; row < 4; row++){
            
            //moves the hourglass right by 1 column
            for(column = 0; column < 4; column++){

                //makes the shape of the hourglass at [0,0]
                //adds the sum of the hourglass
                sum = arr[x][y] + arr[x][y+1] + arr[x][y+2] +
                    arr[x+1][y+1] + arr[x+2][y] + arr[x+2][y+1] +
                    arr[x+2][y+2];

                //stores the sum in an array    
                hourglass[i] = sum;
                i++;

                //helps move the hourglass right by 1 column
                //resets the sum for the next hourglass
                y++;
                sum = 0;
                }

            //helps move the hourglass down by 1 row
            //resets the column position to 0    
            x++;
            y=0;
        }
        
        //finds the highest sum of the hourglass
        for(j = 0; j < hourglass.Length; j++){
            
            //if the current hourglass is higher than maxSum,
            //change the maxSum to current hourglass
            if(hourglass[j] > maxSum){
                maxSum = hourglass[j];
                
            }
        }
        
        return maxSum;

    }
    
        
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
