using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Шоколадні панкейки
            Pancakes pancakes1 = new ChocoPancakes();
            pancakes1 = new ChocolatePancakes(pancakes1); // Шоколадні панкейки з шоколадом
            pancakes1 = new JamPancakes(pancakes1); // Шоколадні панкейки з джемом
            pancakes1 = new CondensedMilkPancakes(pancakes1); // Шоколадні панкейки з згущеним молоком
            Console.WriteLine("Назва: {0}", pancakes1.Name);
            Console.WriteLine("Ціна: {0}", pancakes1.GetCost());

            // Ванільні панкейки
            Pancakes pancakes2 = new VanilaPancakes();
            pancakes2 = new ChocolatePancakes(pancakes2); // Ванільні панкейки з шоколадом
            pancakes2 = new JamPancakes(pancakes2); // Ванільні панкейки з джемом
            pancakes2 = new CondensedMilkPancakes(pancakes2); // Ванільні панкейки з згущеним молоком
            Console.WriteLine("Назва: {0}", pancakes1.Name);
            Console.WriteLine("Ціна: {0}", pancakes1.GetCost());

            // Мікс панкейки
            Pancakes pancakes3 = new MixPancakes();
            pancakes3 = new ChocolatePancakes(pancakes3); // Мікс панкейки з шоколадом
            pancakes3 = new JamPancakes(pancakes3); // Мікс панкейки з джемом
            pancakes3 = new CondensedMilkPancakes(pancakes3); // Мікс панкейки з згущеним молоком
            Console.WriteLine("Назва: {0}", pancakes1.Name);
            Console.WriteLine("Ціна: {0}", pancakes1.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Pancakes
    {
        public Pancakes(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    // Шоколадні панкейки
    class ChocoPancakes : Pancakes
    {
        public ChocoPancakes() : base("Шоколадні панкейки")
        { }
        public override int GetCost()
        {
            return 100;
        }
    }

    // Ванільні панкейки
    class VanilaPancakes : Pancakes
    {
        public VanilaPancakes() : base("Ванільні панкейки")
        { }
        public override int GetCost()
        {
            return 90;
        }
    }

    // Мікс панкейки
    class MixPancakes : Pancakes
    {
        public MixPancakes() : base("Мікс панкейки")
        { }
        public override int GetCost()
        {
            return 110;
        }
    }

    abstract class PancakesDecorator : Pancakes
    {
        protected Pancakes pancakes;
        public PancakesDecorator(string n, Pancakes pancakes) : base(n)
        {
            this.pancakes = pancakes;
        }
    }

    // Шоколад добавка
    class ChocolatePancakes : PancakesDecorator
    {
        public ChocolatePancakes(Pancakes p)
            : base(p.Name + ", з шоколадом", p)
        { }

        public override int GetCost()
        {
            return pancakes.GetCost() + 10;
        }
    }

    // Джем добавка
    class JamPancakes : PancakesDecorator
    {
        public JamPancakes(Pancakes p)
            : base(p.Name + ", з джемом", p)
        { }

        public override int GetCost()
        {
            return pancakes.GetCost() + 8;
        }
    }

    // Згущене молоко добавка
    class CondensedMilkPancakes : PancakesDecorator
    {
        public CondensedMilkPancakes(Pancakes p)
            : base(p.Name + ", з згущеним молоком", p)
        { }

        public override int GetCost()
        {
            return pancakes.GetCost() + 15;
        }
    }

}
