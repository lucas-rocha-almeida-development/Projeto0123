using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Projeto0123.Entities;
using System.Globalization;

namespace Projeto0123
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com caminho do arquivo: ");
            string path = Console.ReadLine();

            List <Produto> list = new List<Produto>();
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)//enquanto não chegar no fim da ultima linha do bloco
                {
                  string[] fildes = sr.ReadLine().Split(',');
                    string name = fildes[0];
                    double price = double.Parse(fildes[1],CultureInfo.InvariantCulture);

                    list.Add(new Produto (  name,price));

                }
            }
            //encontrar preço medio de todos os produtos
            //caso lista seja vazia irie colocar o valor 0 (tratativa de excessão)
            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Media geral dos produtos:" + avg.ToString("F2",CultureInfo.InvariantCulture));

            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p =>p.Name);
            Console.WriteLine("Produtos com preço abaixo da media:");
            foreach (string nomes in names) { 
              
                Console.WriteLine(nomes);
            }

        }
    }
}
