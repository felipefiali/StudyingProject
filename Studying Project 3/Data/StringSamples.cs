namespace Data
{
    public static class StringSamples
    {
        public static string WithUniqueCharacters()
        {
            return "abcdefghijklmnopqrstuvxzy";
        }

        public static string WithRepeatedCharacters()
        {
            return "abcdefdhh";
        }

        public static string CStyleString()
        {
            return "abcde\0";
        }
    }
}