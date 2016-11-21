using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingProject3.Arrays
{
    public static class Arrays
    {
        public static int[] JoinOrderedArrays(int[] array1, int[] array2)
        {
            int arr1Index = 0, arr2Index = 0, newArrayIndex = 0;
            int[] newArray = new int[array1.Length + array2.Length];

            while (arr1Index < array1.Length && arr2Index < array2.Length)
            {
                if (array1[arr1Index] <= array2[arr2Index])
                {
                    newArray[newArrayIndex] = array1[arr1Index];

                    arr1Index++;
                }
                else
                {
                    newArray[newArrayIndex] = array2[arr2Index];

                    arr2Index++;
                }

                newArrayIndex++;
            }

            CompleteArray(newArray, newArrayIndex, array1, arr1Index);
            CompleteArray(newArray, newArrayIndex, array2, arr2Index);

            return newArray;
        }

        private static void CompleteArray(int[] newArray, int newArrayIndex, int[] array, int arrayIndex)
        {
            if (arrayIndex >= array.Length)
            {
                return;
            }

            while (newArrayIndex < newArray.Length)
            {
                newArray[newArrayIndex] = array[arrayIndex];

                newArrayIndex++;
                arrayIndex++;
            }
        }
        
        public static int RemoveDuplicatesFromArray(int[] array)
        {
            if (array == null)
            {
                return 0;
            }

            if (array.Length == 1)
            {
                return 1;
            }

            int lastInteger = array[0];

            int newArrayIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (lastInteger != array[i])
                {
                    lastInteger = array[i];
                    newArrayIndex++;
                    array[newArrayIndex] = array[i];
                }
            }

            for (int i = newArrayIndex + 1; i < array.Length; i++)
            {
                array[i] = 0;
            }

            return newArrayIndex + 1;
        }

        public static int[] LookAndSaySequence(int n)
        {
            var array = new int[] { 1 };

            int lastNumberCounter = 0;
            int lastNumber = 0;

            for (int i = 1; i <= n; i++)
            {
                var newArray = new List<int>();

                lastNumber = array[0];
                lastNumberCounter = 0;

                for (int j = 0; j < array.Length; j++)
                {
                    if (lastNumber == array[j])
                    {
                        lastNumberCounter++;
                    }
                    else
                    {
                        newArray.Add(lastNumberCounter);
                        newArray.Add(lastNumber);

                        lastNumber = array[j];
                        lastNumberCounter = 1;
                    }
                }

                newArray.Add(lastNumberCounter);
                newArray.Add(lastNumber);

                array = newArray.ToArray();
            }

            return array;
        }

        public static int[] CompactArray(int[] array)
        {
            if (array == null)
            {
                return null; 
            }

            if (array.Length <= 1)
            {
                return array;
            }

            var newArray = new int[array.Length];
            var newArrayIndex = 0;

            int lastNumber = array[0];
            int lastNumberCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (lastNumber == array[i])
                {
                    lastNumberCount++;
                }
                else
                {
                    newArray[newArrayIndex] = lastNumberCount;
                    newArrayIndex++;
                    newArray[newArrayIndex] = lastNumber;
                    newArrayIndex++;

                    lastNumber = array[i];
                    lastNumberCount = 1;
                }
            }

            newArray[newArrayIndex] = lastNumberCount;
            newArrayIndex++;
            newArray[newArrayIndex] = lastNumber;

            return newArray;
        }

        public static void MakeRowAndColumnZero(int[,] matrix, int size)
        {
            var listOfRowAndColumns = new List<Tuple<int, int>>();

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        listOfRowAndColumns.Add(new Tuple<int, int>(row, col));
                    }
                }
            }

            foreach (var item in listOfRowAndColumns)
            {
                MakeRowAndColumnZero(matrix, item.Item1, item.Item2, size);                
            }
        }

        public static List<int> GetNumbersInBothOrderedArrays(int[] array1, int[] array2)
        {
            var numbersInBoth = new List<int>();

            if (array1.Length == 0 || array2.Length == 0)
            {
                return numbersInBoth;
            }

            int array1Index = 0, array2Index = 0;

            while (array1Index != array1.Length && array2Index != array2.Length)
            {
                if (array1[array1Index] == array2[array2Index])
                {
                    numbersInBoth.Add(array1[array1Index]);

                    array1Index++;
                    array2Index++;
                }
                else if (array1[array1Index] > array2[array2Index])
                {
                    array2Index++;
                }
                else
                {
                    array1Index++;
                }                
            }

            return numbersInBoth;
        }

        public static int[,] RotateMatrix(int[,] matrix, int size, int degrees)
        {
            if (degrees % 90 != 0)
            {
                return matrix;
            }

            var timesToRotate = degrees / 90;

            for (int i = 1; i <= timesToRotate; i++)
            {
                for (int layer = 0; layer < size / 2; layer++)
                {
                    for (int step = layer; step < size - 1 - layer; step++)
                    {
                        var top = matrix[layer, step];

                        matrix[layer, step] = matrix[size - 1 - step - layer, layer];

                        matrix[size - 1 - step - layer, layer] = matrix[size - 1 - layer, size - 1 - step - layer];

                        matrix[size - 1 - layer, size - 1 - step - layer] = matrix[step, size - 1 - layer];

                        matrix[step, size - 1 - layer] = top;                      
                    }
                }
            }

            return matrix;
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static int GetMaxDistanceOfAdjacentPoints(int[] array)
        {
            if (array == null || array.Length < 2)
            {
                return -2;
            }

            QuickSort(array);

            int currentMax = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                currentMax = Math.Max(currentMax, Math.Abs(array[i + 1] - array[i]));
            }

            if (currentMax == 0)
            {
                return -2;
            }
            else
            {
                return currentMax;
            }
        }

        private static void QuickSort(int[] array, int start, int end)
        {
            if (end > start)
            {
                var pivot = PartitionQuickSort(array, start, end);

                QuickSort(array, start, pivot - 1);
                QuickSort(array, pivot + 1, end);
            }         
        }

        private static int PartitionQuickSort(int[] array, int start, int end)
        {
            var random = new Random().Next(start, end);

            Swap(array, random, end);

            var i = start;

            for (int j = start; j < end; j++)
            {
                if (array[j] <= array[end])
                {
                    Swap(array, j, i);
                    i++;
                }
            }

            Swap(array, i, end);

            return i;
        }

        private static void Swap(int[] array, int from, int to)
        {
            var aux = array[to];

            array[to] = array[from];

            array[from] = aux;
        }
               
        private static void MakeRowAndColumnZero(int[,] matrix, int row, int col, int size)
        {
            for (int i = 0; i < size; i++)
            {
                matrix[row, i] = 0;
            }

            for (int i = 0; i < size; i++)
            {
                matrix[i, col] = 0;
            }
        }        
    }

}