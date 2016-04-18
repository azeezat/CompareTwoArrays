using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    //This program was written by Azeezat Raheem
    //Email: azeezat94@gmail.com
    class Program
    {
        //int i, j;
        //This algorithm works well if the arrays hav the same length
        static void FindMissing(int[] array1, int[] array2)
        {
            Program my = new Program();
            int i = 0, j = 0;
            int t = 0;
            int x = 0; int y = 0;
            int miss = 0;
            Array.Sort(array1);
            Array.Sort(array2);

            

            for (i = 1; i < array1.Length; i++)
            {
                for (j = 1; j < array2.Length; j++)
                {
                    //Check if the arrays are already equal
                    if (i == j && array1[i-1] == array2[j-1] && array1.Length == array2.Length)
                    {
                        Console.WriteLine("No other missing number was found");
                    }

                    //check if any of the first numbers is missing
                    if (array1[0] != array2[0] && array1[0] < array2[0])
                    {
                        miss = array1[0];
                        Console.WriteLine("{0} is missing from the Second array", miss);
                        int[] array = { miss };
                        int[] arr = array.Concat(array2).ToArray();
                        array1 = arr;
                        Array.Sort(array2);
                    }

                    if (array1[0] != array2[0] && array2[0] < array1[0])
                    {
                        miss = array2[0];
                        Console.WriteLine("{0} is missing from the First array", miss);
                        int[] array = { miss };
                        int[] arr = array.Concat(array1).ToArray();
                        array1 = arr;
                        Array.Sort(array1);
                    }

                    //If the first numbers are intact
                    if (i == j && array1[i] != array2[j])
                    {
                        t = i;

                        //Subtract to get difference
                        x = array1[t] - array1[t - 1];
                        y = array2[t] - array2[t - 1];

                        if (x < y)//The missing number is in array2
                        {
                            //add difference to array2
                            miss = array2[t - 1] + x;
                            Console.WriteLine("{0} is missing from the Second array", miss);
                            //Generate a new array for the missing numbers
                            int[] array = { miss };
                            //Add missing numbers to the second array
                            int[] arr = array.Concat(array2).ToArray();
                            //Change the value of array2 to the new concatenated array
                            array2 = arr;
                            //Sort array2 again
                            Array.Sort(array2);
                        }

                        if (y < x)//The missing number is in array1
                        {
                            miss = array1[t - 1] + y;
                            Console.WriteLine("{0} is missing from the First array", miss);
                            int[] array = { miss };
                            int[] arr = array.Concat(array1).ToArray();
                            array1 = arr;
                            Array.Sort(array1);
                        }

                        if (x == y && array1[t - 1] < array2[t - 1])//The missing number is in array2
                        {
                            //subtract difference from the bigger number
                            miss = array2[t - 1] - y;
                            Console.WriteLine("{0} is missing from the Second array", miss);
                            int[] array = { miss };
                            int[] arr = array.Concat(array2).ToArray();
                            array2 = arr;
                            Array.Sort(array2);

                        }

                        if (x == y && array1[t - 1] > array2[t - 1])//The missing number is in array1
                        {
                            miss = array1[t - 1] - x;
                            Console.WriteLine("{0} is missing from the First array", miss);
                            int[] array = { miss };
                            int[] arr = array.Concat(array1).ToArray();
                            array1 = arr;
                            Array.Sort(array1);
                        }
                        
                    }
                }
            }

            

            //if at the end of the day, one array is longer than the other, then return the excess as missing

            if (array1.Length > array2.Length)
            {
                for (int ii = array2.Length; ii < array1.Length; ii++)
                {
                    Console.WriteLine("{0} is missing from the Second array", array1[ii]);
                }
            }

            //if at the end of the day, one array is longer than the other, then return the excess as missing
            if (array2.Length > array1.Length)
            {
                for (int ii = array1.Length; ii < array2.Length; ii++)
                {
                    Console.WriteLine("{0} is missing from the First array", array2[ii]);
                }
            }
        }
        
        static void Main(string[] args)
        {

            int[] array1 = {80,90,100,101,20 };
            int[] array2 = { 2, 5, 15, 80 };
            FindMissing(array1, array2);
        }
    }
}