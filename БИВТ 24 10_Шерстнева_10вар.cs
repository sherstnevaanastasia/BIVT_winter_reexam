// Variant_10

using System;
using System.CodeDom;
using System.Runtime.InteropServices;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            program.Task_1(4, 6, 22);
            // Input: S = 4, A = 6, N = 22
            // Output: time = 18
            program.Task_2(4, 6, 22);
            // Input: GPU = 4, RAM = 6, CPU = 22
            // Output: fps = 13,200000000000003
            int[,] M = new [,]{{ 23,7,-13,24,-21,18},{ 2, 0,12, -16, -20, -17}, { 22,  21,  -6,  19, -22,  -4}, { -13, 13,  18, -15, -20,  -2}, { 3,   7,   1, -20,  22,  -8}, { -22, -11,  13,  -2,   0, -14} };
            
            program.Task_3(M);
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 -13, 13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            // Output:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 22,  21,  18,  19, -22,  -4, 
                  2,   0,   1, -16, -20, -17, 
                 23,   7,  13,  24, -21,  18 */
            int[] A = new[] { 17, 17, 2, -10, -1, -20 };
            program.Task_4(ref A);
            // Input: 
            /*   17,  17,   2, -10,  -1, -20 */
            // Output:
            /*    2, -10, -20 */

            // Task_5:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*   17,  17,   2, -10,  -1, -20 */
            // Output 1:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*  -20, -10,  -1,   2,  17,  17, -15, -14,  -6,   0,  22,  23 */
            // Output 2:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            /*   17,  17,   2,  -1, -10, -20,  23,  22,   0,  -6, -14, -15 */

        }
        public double Task_1(double S, double A, double N)
        {
            int time = 0;
            double gotovnost = 0;
            while ( gotovnost < N)
            {
                
                gotovnost += Math.Sqrt(time);
                time += 1;
                if (gotovnost % A == 0 && gotovnost <N)
                {
                    gotovnost /= 1.5;
                }
                if (time % 5 == 0)
                {
                    gotovnost -= S;
                    if (gotovnost < 0) gotovnost = 0;
                }
            }
            Console.WriteLine(gotovnost);
            Console.WriteLine(time);
            return time;
        }
        public double Task_2(double GPU, double RAM, double CPU)
        {
            double gpuLoad = 10, ramLoad = 1, cpuLoad = 1, fps = 200;
            while (fps > 20)
            {
                if (gpuLoad < GPU)
                {
                    gpuLoad *= 1.1;
                }
                if (ramLoad < RAM)
                {
                    ramLoad *= 2;
                }
                else
                {
                    ramLoad /= 1.5;
                    cpuLoad++;
                }
                if (cpuLoad > CPU)
                {
                    cpuLoad = CPU;
                    gpuLoad = GPU;
                
                }
                else
                {
                    fps = (GPU / gpuLoad) * (RAM / ramLoad) * (CPU / cpuLoad);
                }

            }
            //Console.WriteLine(fps);
            return fps;
        }
        public void Task_3(int[,] M)
        {

            int rows = M.GetLength(0);
            int cols = M.GetLength(1);
            if (rows == 0 || cols== 0 || cols != rows)
            {
                return;
            }
            int minPositive = int.MaxValue;
            int minPositiveCol =-1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (M[i, j] > 0 && M[i, j] < minPositive)
                    {
                        minPositive = M[i, j];
                        minPositiveCol = j;
                    }
                }
            }
            for (int i = 0; i < rows/2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (j != minPositiveCol)
                    {
                        M[rows - i - 1, j] = M[i, j];
                    }
                }
            }
            for ( int i = 0; i < cols; i++)
            {
                for (int P = 0; P < rows; P++)
                {
                    //Console.WriteLine(M[i, P]);
                }
            }
        }
        public void Task_4(ref int[] A)
        {
            if (A.Length== 0)
            {
                return;
            }
            int minPositive = int.MaxValue;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0 && A[i] <minPositive)
                {
                    minPositive = A[i];
                }
            }
            if (minPositive == int.MaxValue)
            {
               
                return;// нт полож элем
            }
            
            bool isEven = true;
            if (minPositive % 2 != 0 ) isEven = false;
           
            int[] resultArray = GetArraySequence(A, isEven);

            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.Write(resultArray[i] +" ");
            }
        }
        public int[] GetArraySequence(int[] array, bool isEven) 
        {
            int count = 0;
            for (int i= 0; i < array.Length; i++)
            {
                if ((array[i] % 2 == 0)== isEven)
                {
                    isEven=true; 
                    count++;
                }
            }
            int[] newArray = new int[count];
            int index = 0;
            for (int i= 0;i < array.Length; i++)
            {
                if ((array[i] %2== 0)== isEven)
                {
                    newArray[index] = array[i];
                    index++;
                }
            }
            return newArray;
        
        }
        public void Task_5(ref int[,] M, ref int[] A, SortArray Op)
        {

        }
        public delegate void SortArray(int[] array);
        public void SortAscending(int[] array) { }
        public void SortDescending(int[] array) { }
        public int[] Concat(int[] array1, int[] array2) { return default(int[]); }

    }
}