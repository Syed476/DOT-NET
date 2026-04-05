namespace Ch03
{
    // ── 1. Fields, constructors, methods ─────────────────────────────────────
    public class Panda
    {
        public string Name;
        public static int Population;          // shared across all instances

        public Panda(string name)
        {
            Name = name;
            Population++;
        }

        public void Greet() => Console.WriteLine($"Hi, I'm {Name}");
    }

    // ── 2. Properties (encapsulate a backing field) ───────────────────────────
    public class Stock
    {
        decimal _price;

        public decimal Price
        {
            get => _price;
            set => _price = value < 0 ? throw new ArgumentException("Negative price") : value;
        }

        // Auto-property — compiler generates the backing field
        public string Symbol { get; set; } = "";
    }

    // ── 3. Indexer ────────────────────────────────────────────────────────────
    public class Sentence
    {
        string[] _words = "The quick brown fox".Split();

        public string this[int index]
        {
            get => _words[index];
            set => _words[index] = value;
        }
    }

    // ── 4. Inheritance ────────────────────────────────────────────────────────
    public class Asset
    {
        public string Name = "";
        public virtual decimal NetValue => 0;          // overridable
    }

    public class House : Asset
    {
        public decimal Mortgage;
        public override decimal NetValue => Mortgage;  // override
    }

    // ── 5. Interface ──────────────────────────────────────────────────────────
    public interface IDescribable
    {
        string Describe();
    }

    public class Car : IDescribable
    {
        public string Model { get; set; } = "";
        public string Describe() => $"Car model: {Model}";
    }

    // ── Entry point ───────────────────────────────────────────────────────────
    public class TypesDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== Ch03: Creating Types ===");

            // Classes & static fields
            var p1 = new Panda("Tai Shan");
            var p2 = new Panda("Bao Bao");
            p1.Greet();
            p2.Greet();
            Console.WriteLine($"Population: {Panda.Population}");   // 2

            // Properties
            var stock = new Stock { Symbol = "AMZN", Price = 185.5m };
            Console.WriteLine($"{stock.Symbol}: ${stock.Price}");

            // Indexer
            var sentence = new Sentence();
            Console.WriteLine(sentence[1]);        // quick
            sentence[1] = "slow";
            Console.WriteLine(sentence[1]);        // slow

            // Inheritance & virtual
            var house = new House { Name = "Beach House", Mortgage = 250_000m };
            Console.WriteLine($"{house.Name} net value: {house.NetValue}");

            // Interface
            IDescribable d = new Car { Model = "Tesla Model S" };
            Console.WriteLine(d.Describe());
        }
    }
}
