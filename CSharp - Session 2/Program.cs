namespace CS___Session_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Input the first number: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Input the second number: ");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("What do you want to do with those numbers?\r\n[A]dd\r\n[S]ubtract\r\n[M]ultiply\r\n");

            var op = Console.ReadKey();
            Console.WriteLine();
            switch (op.KeyChar)
            {
                case 'A':
                case 'a':
                    Console.WriteLine($"{x} + {y} = {x+y}");
                    break;
                case 'S':
                case 's':
                    Console.WriteLine($"{x} - {y} = {x - y}");
                    break;
                case 'M':
                case 'm':
                    Console.WriteLine($"{x} * {y} = {x * y}");
                    break;
                default:
                    Console.WriteLine("Invalid Option!");
                    break;
            }

            Console.WriteLine("Press Any Key to Close");
            Console.ReadKey();
        }
    }
}
