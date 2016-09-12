using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using StudyingProject3.Strings;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void StringWithAllUniqueChars()
        {
            Assert.IsTrue(Strings.HasOnlyUniqueCharacters(StringSamples.WithUniqueCharacters()));

            Assert.IsFalse(Strings.HasOnlyUniqueCharacters(StringSamples.WithRepeatedCharacters()));
        }

        [TestMethod]
        public void ReverseStringCStyle()
        {
            var value = StringSamples.CStyleString();

            Assert.AreEqual("\0edcba", Strings.ReverseString(value));
        }

        [TestMethod]
        public void ReverseStringInPlace()
        {
            Assert.AreEqual("epilef", Strings.ReverseInPlace("felipe"));
        }

        [TestMethod]
        public void TransformWordsToNumbers()
        {
            var unrepeated = "This sample, does not!!!Repeat anything...!";

            Assert.AreEqual("1 2 3 4 5 6", Strings.WordsToNumbersNewString(unrepeated));

            var repeated = "!!!!!!,,,...   __ foo foo bar bar ble banana foo !!";

            Assert.AreEqual("1 1 2 2 3 4 1", Strings.WordsToNumbersNewString(repeated));
        }

        [TestMethod]
        public void CapturePalindromes()
        {
            var value = "ovo";

            CollectionAssert.AreEqual(new List<string>() { "ovo" }, Strings.GetPalindromesFromString(value).ToList());

            value = "daabbaad";

            CollectionAssert.AreEqual(new List<string>() { "aa", "bb", "abba", "aabbaa", "daabbaad" }, Strings.GetPalindromesFromString(value).ToList());

            value = "arara";

            CollectionAssert.AreEqual(new List<string>() { "ara", "rar", "arara" }, Strings.GetPalindromesFromString(value).ToList());

            value = "daabbbaad";

            CollectionAssert.AreEqual(new List<string>() { "aa", "bb", "bbb", "abbba", "aabbbaa", "daabbbaad" }, Strings.GetPalindromesFromString(value).ToList());

            value = "daabbbaadfoo";

            CollectionAssert.AreEqual(new List<string>() { "aa", "bb", "bbb", "abbba", "aabbbaa", "daabbbaad", "oo" }, Strings.GetPalindromesFromString(value).ToList());

            value = "a";

            CollectionAssert.AreEqual(new List<string>(), Strings.GetPalindromesFromString(value).ToList());

            value = "ab";

            CollectionAssert.AreEqual(new List<string>(), Strings.GetPalindromesFromString(value).ToList());

            value = "felipe";

            CollectionAssert.AreEqual(new List<string>(), Strings.GetPalindromesFromString(value).ToList());
        }
    }
}