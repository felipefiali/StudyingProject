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
    }
}