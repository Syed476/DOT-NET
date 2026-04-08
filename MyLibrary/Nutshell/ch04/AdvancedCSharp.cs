namespace Ch04
{
    delegate int Transformer(int x);

    public class AdvancedCSharpDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== CH04: Advanced C# ===");
            Transformer t = Square;
            int result = t(4);
            Console.WriteLine(result);

            int Square(int x) => x * x;
        }
    }
}
