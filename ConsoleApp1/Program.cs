using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj swoj pesel: ");
            string pesel = "55030101193";
            string buffer = Console.ReadLine();
            pesel = String.IsNullOrEmpty(buffer) == true ? "55030101193" : buffer;
            Console.Write("Twoja plec to: ");
            Console.WriteLine(SprawdzPlec(pesel) == 'K' ? "Kobieta" : "Męszczyna");
            
            Console.WriteLine(SprawdzSumeKontrolna(pesel) == true ? "Twoj pesel jest poprawny" : "Twoj pesel jest niepoprawny");
        }

        public static char SprawdzPlec(string pesel)
        {
            return Convert.ToInt32(pesel[9]) % 2 == 0 ? 'K' : 'M';
        }

        public static bool SprawdzSumeKontrolna(string pesel)
        {
            List<int> wagi = new List<int>()
            {
                1,3,7,9,1,3,7,9,1,3
            };
            int S = 0;
            for (int i = 0; i < 10; i++)
            {
                int liczba = Convert.ToInt32(pesel[i] - '0');
                S += liczba * wagi[i];
            }
            int M = S % 10;
            int R = 0;
            if (M == 0) R = 0;
            else
            {
                R = 10 - M;
            }
            return (R == pesel[10]) ? false : true;
        }
    }
}
