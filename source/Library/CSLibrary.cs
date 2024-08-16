namespace Library
{
    public static class CSLibrary
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static string SayOK()
        {
            return "OK!";
        }

        public static int[] GetRandoms(int seed)
        {
            var random = new Random(seed);

            var retVal = new int[random.Next(10)];

            for (int i = 0; i < retVal.Length; i++)
            {
                retVal[i] = random.Next();
            }

            return retVal;
        }

        public static ImportantInfo GetImportantInfo()
        {
            return new ImportantInfo()
            {
                Name = Environment.UserName,
                Date = DateTime.Now,
                Age = Environment.TickCount
            };
        }
    }
}
