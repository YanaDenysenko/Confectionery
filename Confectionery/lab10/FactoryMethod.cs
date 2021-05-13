using System;
using System.Collections.Generic;
using System.Text;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Confectioner con = new CakeConfectioner("Гаєнкова Валерія");
            Product product1 = con.Create();

            con = new СookiesConfectioner("Чемерис Аліна");
            Product product2 = con.Create();

            con = new PancakesConfectioner("Гавриленко Ольга");
            Product product3 = con.Create();

            con = new CupcakesConfectioner("Козак Олена");
            Product product4 = con.Create();

            con = new CakepopsConfectioner("Кириченко Анастасія");
            Product product5 = con.Create();

            Console.ReadLine();
        }
    }

    // абстрактний клас пекарів
    abstract class Confectioner
    {
        public string Name { get; set; }

        public Confectioner(string n)
        {
            Name = n;
        }
        // фабричний метод
        abstract public Product Create();
    }

    // виготовляє торти
    class CakeConfectioner : Confectioner
    {
        public CakeConfectioner(string n) : base(n)
        { }

        public override Product Create()
        {
            return new CakeProduct();
        }
    }

    // виготовляє печиво
    class СookiesConfectioner : Confectioner
    {
        public СookiesConfectioner(string n) : base(n)
        { }

        public override Product Create()
        {
            return new СookiesProduct();
        }
    }

    // виготовляє кекси
    class CupcakesConfectioner : Confectioner
    {
        public CupcakesConfectioner(string n) : base(n)
        { }

        public override Product Create()
        {
            return new CupcakesProduct();
        }
    }


    // виготовляє панкейки
    class PancakesConfectioner : Confectioner
    {
        public PancakesConfectioner(string n) : base(n)
        { }

        public override Product Create()
        {
            return new PancakesProduct();
        }
    }


    // виготовляє кейкпопси
    class CakepopsConfectioner : Confectioner
    {
        public CakepopsConfectioner(string n) : base(n)
        { }

        public override Product Create()
        {
            return new CakepopsProduct();
        }
    }

    abstract class Product
    { }

    class CakeProduct : Product
    {
        public CakeProduct()
        {
            Console.WriteLine("Торт виготовлено");
        }
    }

    class СookiesProduct : Product
    {
        public СookiesProduct()
        {
            Console.WriteLine("Печиво виготовлено");
        }
    }

    class CupcakesProduct : Product
    {
        public CupcakesProduct()
        {
            Console.WriteLine("Кекси виготовлено");
        }
    }

    class PancakesProduct : Product
    {
        public PancakesProduct()
        {
            Console.WriteLine("Панкейки виготовлено");
        }
    }

    class CakepopsProduct : Product
    {
        public CakepopsProduct()
        {
            Console.WriteLine("Кейкпопси виготовлено");
        }
    }
}
