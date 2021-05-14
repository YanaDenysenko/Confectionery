using System;
using System.Collections.Generic;
using System.Text;

namespace lab12_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Cupcakes cupcakes = new Cupcakes();
            Puncakes puncakes = new Puncakes();

            cupcakes.Make();
            puncakes.Make();

            Console.Read();
        }
    }
    abstract class Production
    {
        public void Make()
        {
            Dough();
            Form();
            Baking();
            Packaging();
        }
        public abstract void Dough();
        public abstract void Form();
        public abstract void Baking();
        public virtual void Packaging()
        {
            Console.WriteLine("Складаємо вироби в пакунки");
        }
    }

    class Cupcakes : Production
    {
        public override void Dough()
        {
            Console.WriteLine("Робимо тісто на кекси");
        }

        public override void Form()
        {
            Console.WriteLine("Заливаємо тісто в паперові форми для кексів");
        }

        public override void Baking()
        {
            Console.WriteLine("Випікаємо тісто в духовці");
        }
    }

    class Puncakes : Production
    {
        public override void Dough()
        {
            Console.WriteLine("Робимо тісто на напкейки");
        }

        public override void Form()
        {
            Console.WriteLine("Виливаємо невелику кількість тіста на сковорідку");
        }

        public override void Baking()
        {
            Console.WriteLine("Випікаємо тісто на сковорідці");
        }
    }

}
