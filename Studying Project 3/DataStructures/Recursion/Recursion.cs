using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyingProject3.Extensions;

namespace StudyingProject3.Recursion
{
    public static class Recursion
    {
        public static int CutRod(int[] prices, int n)
        {
            if (prices == null || prices.Length == 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 0;
            }

            int maxValue = 0;

            for (int i = 0; i < n; i++)
            {
                maxValue = IntExtensions.Max(maxValue, prices[i] + CutRod(prices, n - i - 1));
            }

            return maxValue;
        }

        public static int SubsetSum(int[] values, int target)
        {
            var solution = new bool[values.Length];

            var indicesInSolution = new HashSet<int>();

            SubsetSum(values, target, 0, 0, solution, indicesInSolution);

            return indicesInSolution.Count;
        }

        public static HashSet<string> GetPermutations (string word)
        {
            if (word.Length == 2)
            {
                return new HashSet<string>() { word, new string(word.ToCharArray().Reverse().ToArray())};
            }

            var newPerms = new HashSet<string>();

            var firstChar = word.Substring(0, 1);

            var perms = GetPermutations(word.Substring(1));

            foreach (var perm in perms)
            {
                for (int i = 0; i <= perm.Length; i++)
                {
                    var newPerm = InsertCharAt(firstChar, perm, i);
                    newPerms.Add(newPerm);
                }
            }
            
            return newPerms;
        }

        public static Dictionary<string, string> FlattenDictionaries(Dictionary<string, object> unflattenedDictionary)
        {
            var result = new Dictionary<string, string>();

            if (unflattenedDictionary == null)
            {
                return result;
            }

            FlattenDictionaries(unflattenedDictionary, result, string.Empty);

            return result;
        }

        public static int GetWaysToReachNum(int value)
        {
            if (value == 0)
            {
                return 1;
            }
            else if (value < 0)
            {
                return 0;
            }

            return GetWaysToReachNum(value - 1) + GetWaysToReachNum(value - 2) + GetWaysToReachNum(value - 3);
        }

        public static int GetMagicIndex(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            return GetMagicIndex(array, 0, array.Length - 1);
        }

        public static List<List<int>> GetAllSubsetsOfSet(int[] array)
        {
            if (array.Length == 0)
            {
                return null;
            }

            var subsets = new List<List<int>>();

            return GetAllSubsetsOfSet(array, 0, subsets);
        }

        private static List<List<int>> GetAllSubsetsOfSet(int[] array, int curIndex, List<List<int>> subsets)
        {
            if (curIndex == array.Length)
            {
                subsets.Add(new List<int>());

                return subsets;
            }

            var item = array[curIndex];

            GetAllSubsetsOfSet(array, curIndex + 1, subsets);

            var newSets = new List<List<int>>();

            foreach (var set in subsets)
            {
                var newSet = new List<int>();

                newSet.Add(item);
                newSet.AddRange(set);

                newSets.Add(newSet);
            }

            subsets.AddRange(newSets);
            
            return subsets;
        }

        private static int GetMagicIndex(int[] array, int start, int end)
        {
            if (end < start || start > array.Length - 1 || end > array.Length - 1 || start < 0 || end < 0)
            {
                return -1;
            }

            var middle = (start + end) / 2;

            if (array[middle] == middle)
            {
                return middle;
            }

            var leftEnd = Math.Min(middle - 1, array[middle]);           

            var left = GetMagicIndex(array, start, leftEnd);

            if (left > 0)
            {
                return left;
            }

            var rightStart = Math.Max(middle + 1, array[middle]);

            var right = GetMagicIndex(array, rightStart, end);

            return right;
        }

        private static void FlattenDictionaries(Dictionary<string, object> unflattenedDictionary, Dictionary<string, string> result, string prefix)
        {
            foreach (var dictObject in unflattenedDictionary)
            {
                if (dictObject.Value is Dictionary<string, object>)
                {
                    if (string.IsNullOrEmpty(prefix))
                    {
                        FlattenDictionaries((Dictionary<string, object>)dictObject.Value, result, dictObject.Key.ToString());
                    }
                    else
                    {
                        FlattenDictionaries((Dictionary<string, object>)dictObject.Value, result, prefix + "." + dictObject.Key.ToString());
                    }                    
                }
                else
                {
                    if (string.IsNullOrEmpty(prefix))
                    {
                        result.Add(dictObject.Key, dictObject.Value.ToString());
                    }
                    else
                    {
                        result.Add(prefix + "." + dictObject.Key, dictObject.Value.ToString());
                    }
                }
            }
        }

        private static string InsertCharAt(string character, string perm, int index)
        {
            var start = perm.Substring(0, index);
            var end = perm.Substring(index);

            return start + character + end;
        }

        private static void SubsetSum(int[] values, int target, int currentSum, int currentIndex, bool[] solution, HashSet<int> indicesInSolution)
        {
            if (currentSum == target)
            {
                for (int i = 0; i < solution.Length; i++)
                {
                    if (solution[i] == true)
                    {
                        indicesInSolution.Add(i);
                    }
                }
                return;
            }

            if (currentIndex == values.Length)
            {
                return;
            }

            solution[currentIndex] = true;
            currentSum += values[currentIndex];
            SubsetSum(values, target, currentSum, currentIndex + 1, solution, indicesInSolution);

            solution[currentIndex] = false;
            currentSum -= values[currentIndex];
            SubsetSum(values, target, currentSum, currentIndex + 1, solution, indicesInSolution);
        }
    }
}