using System;
using System.Collections.Generic;

namespace StudyingProject3.Strings
{
    public static class Strings
    {
        public static bool HasOnlyUniqueCharacters(string value)
        {
            // Assuming it's only ASCII characters
            var charsFound = new bool[255];

            foreach (char character in value)
            {
                if (charsFound[character])
                {
                    return false;
                }
                else
                {
                    charsFound[character] = true;
                }
            }

            return true;
        }

        public static string ReverseString(string value)
        {
            var newString = string.Empty;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                newString += value[i];
            }

            return newString;
        }

        public static string ReverseInPlace(string value)
        {
            var mutableString = value.ToCharArray();
            int i = 0, j = value.Length - 1;

            while (i != j && i < j)
            {
                var aux = mutableString[i];

                mutableString[i] = value[j];
                mutableString[j] = value[i];

                i++;
                j--;
            }

            return new string(mutableString);
        }

        public static string WordsToNumbersNewString(string value)
        {
            // This sample, does not!!!Repeat anything...!"

            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            var resultingString = string.Empty;

            var wordCount = 0;

            var wordMap = new Dictionary<string, int>();

            var currentWord = string.Empty;

            foreach (char character in value)
            {
                var charAscii = (int)character;

                if ((charAscii >= 65 && charAscii <= 90) || (charAscii >= 97 && charAscii <= 122))
                {
                    currentWord += charAscii;
                }
                else
                {
                    if (string.IsNullOrEmpty(currentWord))
                    {
                        continue;
                    }

                    if (!wordMap.ContainsKey(currentWord))
                    {
                        wordCount++;

                        wordMap[currentWord] = wordCount;                     
                    }

                    resultingString += wordMap[currentWord] + " ";

                    currentWord = string.Empty;
                }
            }

            return resultingString.TrimEnd(' ');            
        }

        public static HashSet<string> GetPalindromesFromString(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length == 1)
            {
                return new HashSet<string>();
            }

            var palindromes = new HashSet<string>();

            for (int i = 0, j = 1; i < value.Length && j < value.Length; i++, j++)
            {
                ExpandFromCenterAndCapturePalindrome(value, i, i, palindromes);
                ExpandFromCenterAndCapturePalindrome(value, i, j, palindromes);
            }

            return palindromes;
        }

        public static string SmallestSubstringOfStringWithCharacters(char[] characters, string bigString)
        {
            if (characters.Length == 1)
            {
                return new string(characters);
            }

            int uniqueCharsCount = 0;

            var charactersDict = new Dictionary<char, int>();

            foreach (var character in characters)
            {
                if (!charactersDict.ContainsKey(character))
                {
                    uniqueCharsCount++;

                    charactersDict.Add(character, 1);
                }
                else
                {
                    charactersDict[character] += 1;
                }
            }

            var minHead = 0;
            var minTail = 0;
            var minLength = Int32.MaxValue;

            for (int head = 0; head < bigString.Length; head++)
            {
                var foundCharsDict = new Dictionary<char, int>();
                var currentUniqueCharsCount = 0;

                if (charactersDict.ContainsKey(bigString[head]))
                {
                    foundCharsDict.Add(bigString[head], 1);

                    if (foundCharsDict[bigString[head]] == charactersDict[bigString[head]])
                    {
                        currentUniqueCharsCount++;
                    }

                    for (int tail = head + 1; tail < bigString.Length; tail++)
                    {
                        if (charactersDict.ContainsKey(bigString[tail]))
                        {
                            if (foundCharsDict.ContainsKey(bigString[tail]))
                            {
                                foundCharsDict[bigString[tail]] += 1;
                            }
                            else
                            {
                                foundCharsDict.Add(bigString[tail], 1);
                            }

                            if (foundCharsDict[bigString[tail]] == charactersDict[bigString[tail]])
                            {
                                currentUniqueCharsCount++;
                            }
                        }                        

                        if (currentUniqueCharsCount == uniqueCharsCount)
                        {
                            var size = (tail - head) + 1;

                            if (size < minLength)
                            {
                                minLength = size;
                                minHead = head;
                                minTail = tail;
                            }

                            break;
                        }
                    }
                }
            }

            return bigString.Substring(minHead, minLength);

        }
        
        private static void ExpandFromCenterAndCapturePalindrome(string value, int i, int j, HashSet<string> palindromes)
        {
            var palindrome = string.Empty;

            while (i >= 0 && j < value.Length)
            {
                if (value[i] == value[j])
                {
                    if (i == j)
                    {
                        palindrome = value[i].ToString();
                    }
                    else
                    {
                        palindrome = value[i] + palindrome + value[j];

                        palindromes.Add(palindrome);
                    }
                }
                else
                {
                    return;
                }

                i--;
                j++;
            }
        }

        private static string CaptureFromString(this string value, int start, int end)
        {
            var retString = string.Empty;

            while (start <= end)
            {
                retString += value[start];

                start++;
            }

            return retString;
        }    
    }    
}