using System;
using System.Text;

namespace Ch03
{
    public class TypesDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== CH03: Creating Types ===");
            var o = new Octopus();
            Console.WriteLine(o.Age);      // 10

            Console.WriteLine("=== Panda: the 'this' keyword ===");
            var harry = new Panda("Harry");
            var mavis = new Panda("Mavis");
            harry.Marry(mavis);
            Console.WriteLine(harry.Mate.Name); // Mavis
            Console.WriteLine(mavis.Mate.Name); // Harry

            Console.WriteLine("=== Partial Methods ===");
            var paymentForm = new PaymentForm(150); // OK
            // new PaymentForm(50); // would throw ArgumentOutOfRangeException

            Console.WriteLine("=== Nameof Operator ===");
            NameofDemo.Run();
            Console.WriteLine("=== Indexers ===");
            Sentence s = new Sentence();
            Console.WriteLine(s[0]);       // the
            Console.WriteLine(s[1]);       // quick
            s[1] = "Kangaroo";
            Console.WriteLine(s[1]);       // Kangaroo
            
            Console.WriteLine("=== Pattern Matching with 'is' ===");
            Asset a = new Stock { Name = "MSFT", SharesOwned = 100 };
            Console.WriteLine($"Asset: {a.Name}");
            if (a is Stock s2 && s2.SharesOwned < 150)
                Console.WriteLine("Poor");    // prints Poor (100 < 150)
            else
                Console.WriteLine("Rich");

            Asset a2 = new Stock { Name = "AAPL", SharesOwned = 200 };
            Console.WriteLine($"Asset: {a2.Name}");
            if (a2 is Stock s3)
                Console.WriteLine(s3.SharesOwned); // 200

            Console.WriteLine("=== IUndoable Interface ===");
            IUndoable[] undoableItems = { new TextBox(), new RichTextBox() };
            foreach (IUndoable item in undoableItems)
                item.Undo();

            Console.WriteLine("=== Enum Flags Demo ===");
            EnumDemo.Run();

            Console.WriteLine("=== Generic Stack Demo ===");
            StackDemo.Run();
        }
    }

    class Octopus
    {
        string name;
        public int Age = 10;
        private static readonly int legs = 8, eyes = 1;
    }

    public class Panda
    {
        public string Name;
        public Panda Mate;

        public Panda(string name)
        {
            Name = name;
        }

        public void Marry(Panda partner)
        {
            Mate = partner;
            partner.Mate = this;
        }
    }
    // partial methods — definition part
    partial class PaymentForm
    {
        public PaymentForm(decimal amount)
        {
            ValidatePayment(amount);
        }
        partial void ValidatePayment(decimal amount);
    }

    // partial methods — implementation part
    partial class PaymentForm
    {
        partial void ValidatePayment(decimal amount)
        {
            if (amount < 100) throw new ArgumentOutOfRangeException("amount", "amt too low");
        }
    }

    public class NameofDemo
    {
        public static void Run()
        {
            int count = 123;
            Console.WriteLine($"Variable name: {nameof(count)}, Variable value: {count}");

            var sb = new StringBuilder("Hello");
            Console.WriteLine($"Object type: {nameof(StringBuilder)}");
            Console.WriteLine($"Property name: {nameof(StringBuilder.Length)}, Actual length: {sb.Length}");
            Console.WriteLine($"Method name: {nameof(StringBuilder.Append)}");
            
            // Show the difference between nameof and ToString
            Console.WriteLine($"nameof(count) = '{nameof(count)}' (compile-time string)");
            Console.WriteLine($"count.ToString() = '{count.ToString()}' (runtime value)");
        }
    }
    
    class Sentence
    {
        private string[] words = "the quick brown fox".Split();

        public string this[int wordNum]
        {
            get { return words[wordNum]; }
            set { words[wordNum] = value; }
        }
    }

    public class Asset
    {
        public string Name;
    }

    public class Stock : Asset
    {
        public long SharesOwned;
    }
    public class House : Asset
    {
        public decimal Mortgage;
    }
    
    public interface IUndoable
    {
        void Undo();
    }
    
    public class TextBox : IUndoable
    {
        public virtual void Undo() => Console.WriteLine("TextBox.Undo");
    }
    
    public class RichTextBox : TextBox
    {
        public override void Undo() => Console.WriteLine("RichTextBox.Undo");
    }
    
    public class EnumDemo
    {
        public static void Run()
        {
            for (int i = 0; i <= 16; i++)
            {
                BorderSides side = (BorderSides)i;
                Console.WriteLine(IsFlagDefined(side) + " " + side);
            }
        }
        
        static bool IsFlagDefined(Enum e)
        {
            decimal d;
            return !decimal.TryParse(e.ToString(), out d);
        }
    }
    
    [Flags]
    public enum BorderSides
    {
        Left = 1,
        Right = 2,
        Top = 4,
        Bottom = 8
    }
    
    public class StackDemo
    {
        public static void Run()
        {
            Console.WriteLine("Creating stack of bears...");
            Stack<Bear> bears = new Stack<Bear>();
            
            Console.WriteLine("Adding bears to stack:");
            bears.Push(new Bear("Yogi"));
            Console.WriteLine("Pushed: Yogi");
            bears.Push(new Bear("BooBoo"));
            Console.WriteLine("Pushed: BooBoo");
            bears.Push(new Bear("Paddington"));
            Console.WriteLine("Pushed: Paddington");
            
            Console.WriteLine("\nPopping bears from stack (LIFO):");
            Console.WriteLine($"Popped: {bears.Pop().Name}");
            Console.WriteLine($"Popped: {bears.Pop().Name}");
            Console.WriteLine($"Popped: {bears.Pop().Name}");
            
            Console.WriteLine("\nTesting ZooCleaner with generic constraint:");
            Stack<Bear> moreBears = new Stack<Bear>();
            moreBears.Push(new Bear("Teddy"));
            ZooCleaner.Wash(moreBears);
        }
    }

    public class Stack<T>
    {
        private int position;
        T[] data = new T[100];
        public void Push(T obj) => data[position++] = obj;
        public T Pop() => data[--position];
    }
    
    public abstract class Animal
    {
        public string Name { get; set; }
        public Animal(string name) { Name = name; }
    }
    
    public class Bear : Animal
    {
        public Bear(string name) : base(name) { }
    }
    
    static class ZooCleaner
    {
        public static void Wash<T>(Stack<T> animals) where T : Animal 
        {
            Console.WriteLine($"Washing {typeof(T).Name} animals in the stack...");
        }
    }
    
}
