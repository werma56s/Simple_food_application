using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoodApp
{

    public static class Class1
    {
        public static double suma = 0;
        public static string pom ="";
        public static int licznik = 0;
        public static List<string> lista = new List<string>();

        public static void Addd(double price,string a, string b) {
            pom = a + " " + Convert.ToString(price) + "$";
            lista.Add(pom);
            licznik++;
            Suma(price);
        }
        public static void Suma(double a)
        {
            suma += a;
        }

        public static void Popp()
        {

        }
 
    }
}
