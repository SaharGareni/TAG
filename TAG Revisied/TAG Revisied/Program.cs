namespace TAG_Revisied

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var commandParser = GameInitializer.Initialize();
            while (true)
            {
                Console.Write(">");
                Console.WriteLine(commandParser.Parse(Console.ReadLine())); 
            }
        }
    }
}
