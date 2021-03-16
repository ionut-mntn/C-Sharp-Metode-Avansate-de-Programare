using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1:
            //string[] words = { "this", "is", "a", "not", "very", "long", "test" };
            //var result = from w in words
            //             where w.Length >= 4
            //             // select w.ToUpper; // asa dc nu merge??
            //             select w;

            //foreach (string s in result)
            //    Console.WriteLine(s.ToUpper());

            //string[] words = { "this", "is", "a", "not", "very", "long", "test" };
            //var res = words.Select(w => new
            //{

            //})


            //int[] numbers = { 3, 6, 7, 9, 2, 5, 3, 7 };
            //var res = from n in numbers
            //            where n > 5
            //            select n;
            //foreach (int n in res)
            //    Console.WriteLine(n);

            //string[] words = { "this", "is", "a", "not", "very", "long", "test" };
            //var result = from w in words
            //             where w.Length >= 4
            //             // select w.ToUpper; // asa dc nu merge??
            //             select( w => w.toUpper());

            string[] words = { "this", "is", "a", "not", "very", "long", "test" };
            var result = words
                .Select(w => w.ToUpper())
                .Where(w => w.Length >= 4)
                .ToArray();

            foreach (string s in result)
                Console.WriteLine(s);

            Console.WriteLine();

            // 2:
            // int[] numbers = new int[]{ 2, 3, 4, 5, 4, 23, 5, 4, 4, 2, 4, 3, 5 };
            int [] numbers = { 2, 3, 4, 5, 4, 23, 5, 4, 4, 2, 4, 3, 5 }; // e vreo diferenta intre asta si cea de deasupra ?
            var result2 = numbers               // de vazut ce tip returneaza .GroupBy aici! pt ca: de unde stie ToDictionary() de ".key" si de ".count()"?
                .GroupBy(number => number);      // devine clar ca returneaza un obiect de tip cheie valoare
                                                 //                .ToDictionary(number => number.Key,number => number.Count());

            //foreach (KeyValuePair<int, int> pereche in result2)
            //    Console.WriteLine(pereche.Key + " " + pereche.Value);
            foreach (var aux in result2)
                Console.WriteLine(aux.Key + ": " + aux.Count());

            Console.WriteLine();

            // 3:
            string str = "This IS a TEST string";
            var result3 = str
                .Split(' ')
                .Where(w => w == w.ToUpper());

            foreach (var r in result3)
                Console.WriteLine(r);

            Console.WriteLine();

            // 4:
            int[] a1 = { 1, 2, 3 };
            int[] a2 = { 4, 5, 6 };
            int scalarProduct = a1.Zip(a2, (f1, f2) => f1 * f2)
                .Sum();                     // .Zip aplica functia lambda pasata "fiecare cu fiecare" pentru cele 2 containere date

            Console.WriteLine(scalarProduct);

            Console.WriteLine();

            // 5:
            string[] words2 = { "this", "is", "a", "not", "very", "long", "test", "lang", "lebadang" };
            char firstLetter = 'l';
            char lastLetter = 'g';
            var result5 = from w in words2
                          where w[0] == firstLetter && w[w.Length - 1] == lastLetter
                          // sau cica puteam folosi w[^1]
                          select w; // linq nu face schimbari asupra "the underlying data"

            foreach (string w in result5)
                Console.WriteLine(w);

            Console.WriteLine();

            // 6:
            // cum precizez path relativ??????

            XDocument xdoc = XDocument.Load(@"E:\Facultate\sem III\MAP - Metode Avansate de Programare\C#\Seminar 13\ConsoleApp1\products.xml");
            // - in situatii de genul de pus un arond inainte de string-ul cu path-ul care impune: " sa se trateze verbatim (word-for-word) string-ul "

            // astea de dedesubt dc nu merg??
            // XDocument xdoc = XDocument.Load(@"database\products.xml");
            // XDocument xdoc = XDocument.Load("database\\products.xml");
            // XDocument xdoc = XDocument.Load("ConsoleApp1\\database\\products.xml");
            // XDocument xdoc = XDocument.Load(@"ConsoleApp1\database\products.xml");


            var res = xdoc.Descendants("Product").Select(p => new
            {
                id = p.Attribute("id").Value,        // asta e doar read-only !!
                name = p.Element("Name").Value,
                quantity = p.Element("Quantity").Value,
                price = p.Element("Price").Value // obs: daca nu pun ".value" mi-l ia verbatim.. adica: "<Price>5000</Price>"

            });

            res.ToList()
            .ForEach(p => Console.WriteLine(p));

            Console.WriteLine(res.GetType());
            // Console.WriteLine(getStaticType(res));

            res = res.ToList()
                .Sort(aux1, aux2 => aux1.id < aux2.id ? aux1 : aux2);
            

        }
    }
}
