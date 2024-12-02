namespace pakowaniePrezentow
{
    internal class Program
    {
        static private int potPapier(string userInput)
        {
            int ilePapier;
            string[] krawedzieStr = userInput.Trim().Replace("  ", " ").Split(" ");
            List<int> krawedzieInt = new List<int>();
            foreach(string s in krawedzieStr)
            {
                if (int.TryParse(s, out int x) && x >= 0)
                    krawedzieInt.Add(x);
                else
                    return -1;
            }
            krawedzieInt.Sort();

            ilePapier = krawedzieInt[0] * krawedzieInt[1] * 2 + krawedzieInt[1] * krawedzieInt[2] * 2 + krawedzieInt[0] * krawedzieInt[2] * 2;
            ilePapier += krawedzieInt[krawedzieInt.Count - krawedzieInt.Count] * krawedzieInt[krawedzieInt.Count - (krawedzieInt.Count - 1)];

            return ilePapier;
        }

        static void Main(string[] args)
        {
            int n = 0;
            while(n < 1 || n > 1000)
            {
                do{
                    Console.WriteLine("Podaj liczbe paczek (w zakresie od 1 do 1000): ");
                } while (!int.TryParse(Console.ReadLine(), out n));
            }

            int wynik = 0;
            string userInput;
            for(int i = 0; i < n;i++)
            {
                do{
                    userInput = Console.ReadLine();
                    if (!userInput.Trim().Contains(" "))
                    {
                        userInput += " " + Console.ReadLine();
                        userInput += " " + Console.ReadLine();
                    }
                } while (potPapier(userInput) < 0);
                
                wynik += potPapier(userInput);
            }

            Console.WriteLine(wynik);
        }
    }
}
