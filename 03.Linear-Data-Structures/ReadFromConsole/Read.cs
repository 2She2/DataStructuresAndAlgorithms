namespace ReadFromConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Read
    {
        public static List<int> Ints()
        {
            List<int> inputNubers = new List<int>();
            string currLine = Console.ReadLine();

            while (currLine.Length > 0)
            {
                int currLineToNumber = int.Parse(currLine);
                inputNubers.Add(currLineToNumber);

                currLine = Console.ReadLine();
            }

            return inputNubers;
        }

        public static List<int> IntsWithCount()
        {
            List<int> inputNubers = new List<int>();
            string currLine = Console.ReadLine();
            int length = int.Parse(currLine);

            while (length > 0)
            {
                currLine = Console.ReadLine();

                int currLineToNumber = int.Parse(currLine);
                inputNubers.Add(currLineToNumber);

                length--;
            }

            return inputNubers;
        }
    }
}
