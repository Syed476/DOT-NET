namespace Ch02
{
    // Value type: assignment copies the value
    public struct PointStruct { public int X, Y; }

    // Reference type: assignment copies the reference
    public class PointClass { public int X, Y; }

    public class VariablesDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== Value Type (struct) ===");
            PointStruct p1 = new PointStruct();
            p1.X = 7;
            PointStruct p2 = p1;           // copies the value
            p1.X = 9;
            Console.WriteLine(p1.X);       // 9
            Console.WriteLine(p2.X);       // 7 — p2 is unaffected

            Console.WriteLine("=== Reference Type (class) ===");
            PointClass r1 = new PointClass();
            r1.X = 7;
            PointClass r2 = r1;            // copies the reference
            r1.X = 9;
            Console.WriteLine(r1.X);       // 9
            Console.WriteLine(r2.X);       // 9 — both point to same object
        }
    }
}
