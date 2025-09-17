using System;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("John", 3, 16);
        var scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Well done!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            var input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            var rand = new Random();
            int wordsToHide = rand.Next(1, 4); // creative extension
            scripture.HideRandomWords(wordsToHide);
        }
    }
}
