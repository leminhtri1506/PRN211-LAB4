using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAB4
{
    internal class Bai3_Product
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string[] Colors { get; set; }
            public int Brand { set; get; }

            public Product(int id, string name, double price, string[] colors, int brand)
            {
                Id = id;
                Name = name;
                Price = price;
                Colors = colors;
                Brand = brand;
            }

            public override string? ToString()
            {
                return $"{Id,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
            }
        }

        public class Brand
        {


            public string Name { get; set; }
            public int ID { get; set; }
        }

        //------------------------------------------------------------------
        public class Program
        {


            static void Main(string[] args)
            {
                var brands = new List<Brand>()
                {
                    new Brand{ID=1, Name="Cong ty AAA" },
                     new Brand{ID=2, Name="Cong ty BBB" },
                      new Brand{ID=4, Name="Cong ty CCC" },
                };

                var products = new List<Product>()
                {
                    new Product(1, "Ban Tra",400, new string[]{ "Xam","Xanh"},2),
                    new Product(2, "Tranh Treo",400, new string[]{ "Vang","Xanh"},1),
                    new Product(3, "Den Trum",500, new string[]{ "Trang"},3),
                    new Product(4, "Ban Hoc",200, new string[]{ "Trang","Xanh"},1),
                    new Product(5, "Tui Da",300, new string[]{ "Do","Den","Vang"},2),
                    new Product(6, "Giuong Ngu",500, new string[]{ "Trang"},2),
                    new Product(7, "Tu Ao",600, new string[]{ "Trang"},3),
                };

                var filter = from product in products
                             join brand in brands on product.Brand equals brand.ID
                             where product.Price == 400
                             select new
                             {
                                 name = product.Name,
                                 price = product.Price,
                                 brand = brand.Name,
                             };
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("---Filter product have price = 400---");
                foreach (var item in filter)
                {
                    Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
                }

                Console.WriteLine("\n--------------------------------------------------");

                Console.WriteLine("---Filter product have color = yellow---");


                var filterColor = from product in products
                                  join brand in brands on product.Brand equals brand.ID
                                  where product.Colors.Contains("Vang")
                                  select new
                                  {
                                      name = product.Name,
                                      price = product.Price,
                                      brand = brand.Name,
                                  };
                foreach (var item in filterColor)
                {
                    Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
                }

                Console.WriteLine("\n--------------------------------------------------"); Console.WriteLine("---Filter product descending order of Price---");
                var filterDescending = from product in products
                                       join brand in brands on product.Brand equals brand.ID

                                       orderby product.Price descending // Sort by price in descending order
                                       select new
                                       {
                                           name = product.Name,
                                           price = product.Price,
                                           brand = brand.Name,
                                       };
                foreach (var item in filterDescending)
                {
                    Console.WriteLine($"{item.name,10} {item.price,4} {item.brand,12}");
                }

                Console.ReadLine();
            }
        }
    }
}
