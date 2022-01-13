using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExampleProject.ArrProb
{
    public static class ArrayProblems
    {
        public static void MoveZeroes(int[] nums)
        {
            int zero = 0, nonZero = 0;
            if (nums.Length > 1)
            {
                while (zero < nums.Length && nums[zero] != 0)
                {
                    zero++; nonZero++;
                }


                while (nonZero < nums.Length)
                {
                    if (nums[nonZero] != 0)
                    {
                        Swap(nums, zero++, nonZero++);
                    }
                    else
                    {
                        nonZero++;
                    }

                }
            }
        }

        //418. Sentence Screen Fitting
        public static int ScreenSentenceTyping(string[] sentence, int rows, int cols)
        {
            int count = 0, currRow = 0, currCol = -1;
            bool isWordAdded = false;

            if (sentence.Any(s => s.Length > cols)) return 0;

            while (currRow < rows)
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    isWordAdded = false;

                    if (currCol >= cols - 1)
                    {
                        currCol = -1; currRow++;
                    }

                    if (currRow < rows)
                    {
                        int newWordLength = sentence[i].Length;

                        currCol += newWordLength; //curr col should be at the last char

                        if (currCol == cols - 1) //word added just update cols/row
                        {
                            currCol = -1;//for next turn
                            currRow++;
                            isWordAdded = true;
                        }
                        else if (currCol >= cols)//word falling outside of boundary update col/row and again add the word
                        {
                            currCol = -1; currRow++;
                            if (currRow < rows)
                            {
                                currCol += newWordLength;

                                if (currCol < cols)
                                {
                                    currCol++; //add space                            
                                    isWordAdded = true;
                                }
                                else break;
                            }
                            else
                                break;
                        }
                        else//word added and within col boundary
                        {
                            currCol++;
                            isWordAdded = true;
                        }
                    }
                    else
                    {
                        break;
                    }

                    if (i == sentence.Length - 1 && isWordAdded)
                        count++;
                }

            }

            return count;
        }

        public static void Swap(int[] nums, int zero, int nonZero)
        {
            int temp = nums[zero];
            nums[zero] = nums[nonZero];
            nums[nonZero] = temp;
        }

        /*
-- Rocks in 5 colors (Red, Blue, Black, While and Green) and 2 sizes (S and L) arriving in batches
-- Batches arriving at fixed intervals 
-- Batch size is fixed
-- Each rock to be put into named bucket based in its size. so 10 buckets total mounted on a turntable style machinery
-- Switching between buckets is an time-expensive operation.

// Goal:
For each batch, sort the rocks into their corresponding buckets with the lowest number of turns to change buckets.
Determine the order in which the buckets on the turntable are to be arranged to minimize the costs.
        */
        static int CalculateMinNumOfTunrs(int[] stoneBatch) // numbers 0-9 for 5color and 2 sizes
        {
            if (stoneBatch != null && stoneBatch.Length > 0)
            {
                Console.WriteLine("Calling sort");
                int numOfUnique = SortBatch(stoneBatch);
                return (numOfUnique - 1);
            }

            return 0;
        }

        static int SortBatch(int[] stoneBatch)
        {
            int[] bucket = new int[10];
            int numOfUnique = 0;
            for (int i = 0; i < stoneBatch.Length; i++)
            {
                Console.WriteLine("Iteration:" + i);
                if (bucket[stoneBatch[i]] == 0)
                {
                    numOfUnique++;
                }

                bucket[stoneBatch[i]] += 1;
            }

            return numOfUnique;

        }
    }
}
