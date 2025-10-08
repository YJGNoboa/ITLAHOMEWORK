using System.Net.Http.Headers;

namespace MiPrimerPrograma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            Console.Write("Escribe la medida de un cateto: ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Escribe la medida del otro cateto: ");
            b = Convert.ToDouble(Console.ReadLine());

            double Hipotenusa = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            Console.WriteLine("La hipotenusa es: " + Hipotenusa);
        }
    }
}
