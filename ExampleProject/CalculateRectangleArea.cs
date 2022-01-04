using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleProject
{
    class CalculateRectangleArea
    {
        /*
Imagine we have an image. We'll represent this image as a simple 2D array where every pixel is a 1 or a 0.

The image you get is known to have potentially many distinct rectangles of 0s on a background of 1's. Write a function that takes in the image and returns the coordinates of all the 0 rectangles -- top-left and bottom-right; or top-left, width and height.

image1 = [
  [0, 1, 1, 1, 1, 1, 1],
  [1, 1, 1, 1, 1, 1, 1],
  [0, 1, 1, 0, 0, 0, 1],
  [1, 0, 1, 0, 0, 0, 1],
  [1, 0, 1, 1, 1, 1, 1],
  [1, 0, 1, 0, 0, 1, 1],
  [1, 1, 1, 0, 0, 1, 1],
  [1, 1, 1, 1, 1, 1, 0],
]

Sample output variations (only one is necessary):

findRectangles(image1) =>
  // (using top-left-row-column and bottom-right):
  [
    [[0,0],[0,0]],
    [[2,0],[2,0]],
    [[2,3],[3,5]],
    [[3,1],[5,1]],
    [[5,3],[6,4]],
    [[7,6],[7,6]],
  ]
  // (using top-left-row-column and width/height):
  [
    [[0,0],[1,1]],
    [[2,0],[1,1]],
    [[2,3],[3,2]],
    [[3,1],[1,3]],
    [[5,3],[2,2]],
    [[7,6],[1,1]],
  ]

Other test cases:

image2 = [
  [0],
]

findRectangles(image2) =>
  // (using top-left-row-column and bottom-right):
  [
    [[0,0],[0,0]],
  ]

  // (using top-left-row-column and width/height):
  [
    [[0,0],[1,1]],
  ]

image3 = [
  [1],
]

findRectangles(image3) => []

image4 = [
  [1, 1, 1, 1, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 0, 0, 0, 1],
  [1, 1, 1, 1, 1],
]

findRectangles(image4) =>
  // (using top-left-row-column, and bottom-right or width/height):
  [
    [[1,1],[3,3]],
  ]

n: number of rows in the input image
m: number of columns in the input image

*/

        public static void NumOfRectanlges()
        {
            // C# (jagged array)
            int[][] image1 = new int[][]
            {
          new int[] {0, 1, 1, 1, 1, 1, 1},
          new int[] {1, 1, 1, 1, 1, 1, 1},
          new int[] {0, 1, 1, 0, 0, 0, 1},
          new int[] {1, 0, 1, 0, 0, 0, 1},
          new int[] {1, 0, 1, 1, 1, 1, 1},
          new int[] {1, 0, 1, 0, 0, 1, 1},
          new int[] {1, 1, 1, 0, 0, 1, 1},
          new int[] {1, 1, 1, 1, 1, 1, 0}
            };

            int[][] image2 = new int[][]
            {
          new int[] {0}
            };

            int[][] image3 = new int[][]
            {
          new int[] {1}
            };

            int[][] image4 = new int[][]
            {
          new int[] {1, 1, 1, 1, 1},
          new int[] {1, 0, 0, 0, 1},
          new int[] {1, 0, 0, 0, 1},
          new int[] {1, 0, 0, 0, 1},
          new int[] {1, 1, 1, 1, 1}
            };

            List<Result> results1 = CalculateRectangles(image1);

            foreach (Result r in results1)
            {
                Console.WriteLine(r.Row + "," + r.Col + "," + r.Width + "," + r.Height);
            }

        }

        public static List<Result> CalculateRectangles(int[][] image)
        {
            List<Result> result = new List<Result>();

            if (image != null && image.Length > 0)
            {
                for (int i = 0; i < image.Length; i++)
                {
                    for (int j = 0; j < image[i].Length; j++)
                    {
                        if (image[i][j] == 0)
                        {
                            Result res = new Result(i, j, 1, 1);
                            image[i][j] = 2;//mark visited
                            RectangleHelper(i, j, image, res);
                            result.Add(res);
                        }
                    }
                }
            }

            return result;

        }

        public static void RectangleHelper(int row, int col, int[][] image, Result rect)
        {
            //base 
            if (row >= image.Length || col >= image[0].Length || image[row][col] == 1)
                return;

            //recursive
            if (row + 1 < image.Length && image[row + 1][col] == 0)
            {
                int newRow = row + 1;
                int newCol = col;
                int currHieght = newRow - rect.Row + 1;

                image[newRow][newCol] = 2;//mark visited
                if(rect.Height < currHieght)
                    rect.Height = currHieght;
                RectangleHelper(newRow, newCol, image, rect);
            }
            if (col + 1 < image[row].Length && image[row][col + 1] == 0)
            {
                int newRow = row;
                int newCol = col + 1;
                int currWidth = newCol - rect.Col + 1;

                image[newRow][newCol] = 2;//mark visited
                if (rect.Width < currWidth)
                    rect.Width = currWidth;
                RectangleHelper(newRow, newCol, image, rect);
            }
        }

        public static void RectangleHelper2(int row, int col, int[][] image, Result rect)
        {
            //base 
            if (row >= image.Length || col >= image[0].Length || image[row][col] == 1)
                return;

            //recursive


            if (row + 1 < image.Length && image[row + 1][col] == 0)
            {
                int newRow = row + 1;
                int newCol = col;
                int currHieght = newRow - rect.Row + 1;

                image[newRow][newCol] = 2;//mark visited
                if (rect.Height < currHieght)
                    rect.Height += 1;
                RectangleHelper2(newRow, newCol, image, rect);
            }
            if (col + 1 < image[row].Length && image[row][col + 1] == 0)
            {
                int newRow = row;
                int newCol = col + 1;
                int currWidth = newCol - rect.Col + 1;

                image[newRow][newCol] = 2;//mark visited
                if (rect.Width < currWidth)
                    rect.Width += 1;
                RectangleHelper2(newRow, newCol, image, rect);
            }
        }

        public class Result
        {
            public int Row, Col;
            public int Width, Height;

            public Result(int r, int c, int w, int h)
            {
                this.Row = r;
                this.Col = c;
                this.Width = w;
                this.Height = h;
            }
        }

    }





}



