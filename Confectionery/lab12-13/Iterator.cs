using System;
using System.Collections.Generic;
using System.Text;

namespace lab12_13
{
    class Program1
    {
        static void Main(string[] args)
        {
            Confectionery confectionery = new Confectionery();
            Buyer buyer = new Buyer();
            buyer.SeeProducts(confectionery);

            Console.Read();
        }
    }

    class Buyer
    {
        public void SeeProducts(Confectionery confectionery)
        {
            IProductIterator iterator = confectionery.CreateNumerator();
            while (iterator.HasNext())
            {
                Product product = iterator.Next();
                Console.WriteLine(product.Name);
            }
        }
    }

    interface IProductIterator
    {
        bool HasNext();
        Product Next();
    }
    interface IProductNumerable
    {
        IProductIterator CreateNumerator();
        int Count { get; }
        Product this[int index] { get; }
    }
    class Product
    {
        public string Name { get; set; }
    }

    class Confectionery : IProductNumerable
    {
        private Product[] products;
        public Confectionery()
        {
            products = new Product[]
            {
                new Product{Name="Кекси"},
                new Product{Name="Торти"},
                new Product{Name="Панкейки"},
                new Product{Name="Печиво"},
                new Product{Name="Кейкпопси"}
            };
        }
        public int Count
        {
            get { return products.Length; }
        }

        public Product this[int index]
        {
            get { return products[index]; }
        }
        public IProductIterator CreateNumerator()
        {
            return new ConfectioneryNumerator(this);
        }
    }
    class ConfectioneryNumerator : IProductIterator
    {
        IProductNumerable aggregate;
        int index = 0;
        public ConfectioneryNumerator(IProductNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Product Next()
        {
            return aggregate[index++];
        }
    }
}
