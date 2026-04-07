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
}
