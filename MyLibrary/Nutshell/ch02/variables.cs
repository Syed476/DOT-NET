namespace Ch02
{
    public struct PointStruct { public int X, Y; }
    public class PointClass { public int X, Y; }

    public class VariablesDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== Value Type (struct) ===");
            PointStruct p1 = new PointStruct();
            p1.X = 7;
            PointStruct p2 = p1;
            Console.WriteLine(p1.X);       // 7
            Console.WriteLine(p2.X);       // 7
            p1.X = 9;
            Console.WriteLine(p1.X);       // 9
            Console.WriteLine(p2.X);       // 7 — p2 is unaffected (value copied)

            Console.WriteLine("=== Reference Type (class) ===");
            PointClass r1 = new PointClass();
            r1.X = 7;
            PointClass r2 = r1;
            Console.WriteLine(r1.X);       // 7
            Console.WriteLine(r2.X);       // 7
            r1.X = 9;
            Console.WriteLine(r1.X);       // 9
            Console.WriteLine(r2.X);       // 9 — both point to same object (reference copied)

            Console.WriteLine("=== in Keyword (pass by read-only ref) ===");
            SomeBigStruct x = default;
            Foo(x);
            Foo(in x);
            Bar(x);
            Bar(in x);

            Console.WriteLine("=== ref Locals ===");
            RefLocalDemo();
        }

        static void Foo(SomeBigStruct a) => Console.WriteLine("Foo");
        static void Foo(in SomeBigStruct a) => Console.WriteLine("in Foo");

        static void Bar(in SomeBigStruct a) => Console.WriteLine("in Bar");

        struct SomeBigStruct
        {
            public decimal A,B,C,D,E,F,G;
        }

        public static void RefLocalDemo()
        {
            int[] numbers = { 0, 1, 2, 3, 4 };
            ref int numRef = ref numbers[2];
            numRef *= 10;
            Console.WriteLine(numbers[2]);  // 20
            Console.WriteLine(numRef);      // 20
        }

    }
}
