namespace Banksimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variabeldeklaration
            double saldo = 0.0; // Huvudkontots saldo
            bool körProgram = true;

            // Huvudloop för menyn
            while (körProgram)
            {
                // Utskrift av meny
                Console.WriteLine("\n**** BANKSIMULATOR ****");
                Console.WriteLine("[I]nsättning");
                Console.WriteLine("[U]ttag");
                Console.WriteLine("[S]aldo");
                Console.WriteLine("[R]äntebetalning");
                Console.WriteLine("[A]vsluta");
                Console.Write("Välj ett alternativ: ");

                // Läser användarens val
                string val = Console.ReadLine().ToUpper();

                // Menyns switch-sats
                switch (val)
                {
                    case "I": // Insättning
                        Console.Write("Ange belopp att sätta in: ");
                        if (double.TryParse(Console.ReadLine(), out double insättning) && insättning > 0)
                        {
                            saldo += insättning;
                            Console.WriteLine("");
                            Console.WriteLine($" -----> Du har satt in {insättning} kr. Nytt saldo: {saldo} kr.");
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt belopp. Försök igen.");
                        }
                        break;

                    case "U": // Uttag
                        Console.Write("Ange belopp att ta ut: ");
                        if (double.TryParse(Console.ReadLine(), out double uttag) && uttag > 0)
                        {
                            if (uttag <= saldo)
                            {
                                saldo -= uttag;
                                Console.WriteLine("");
                                Console.WriteLine($" -----> Du har tagit ut {uttag} kr. Nytt saldo: {saldo} kr.");
                            }
                            else
                            {
                                Console.WriteLine("Otillräckligt saldo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt belopp. Försök igen.");
                        }
                        break;

                    case "S": // Saldo
                        Console.WriteLine("");
                        Console.WriteLine($" -----> Ditt aktuella saldo är: {saldo} kr.");
                        break;

                    case "R": // Ränteberäkning
                        Console.Write("Ange årlig insättning: ");
                        if (double.TryParse(Console.ReadLine(), out double årligInsättning) && årligInsättning > 0)
                        {
                            Console.Write("Ange räntesats i procent (t.ex. 10): ");
                            if (double.TryParse(Console.ReadLine(), out double ränta) && ränta > 0)
                            {
                                Console.Write("Ange antal år att spara: ");
                                if (int.TryParse(Console.ReadLine(), out int år) && år > 0)
                                {
                                    double framtidaSaldo = saldo;
                                    for (int i = 1; i <= år; i++)
                                    {
                                        framtidaSaldo += årligInsättning;
                                        framtidaSaldo += framtidaSaldo * (ränta / 100);
                                        Console.WriteLine($"År {i}: {framtidaSaldo:F2} kr");
                                    }
                                    Console.WriteLine("");
                                    Console.WriteLine($" -----> Efter {år} år kommer ditt saldo att vara: {framtidaSaldo:F2} kr.");
                                }
                                else
                                {
                                    Console.WriteLine("Antal år måste vara ett rimligt heltal.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Räntesatsen måste vara ett rimligt tal.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Årlig insättning måste vara ett rimligt tal.");
                        }
                        break;

                    case "A": // Avsluta
                        Console.WriteLine("");
                        Console.WriteLine(" -----> Tack för att du använde Banksimulatorn. Ha en bra dag!");
                        körProgram = false;
                        break;

                    default: // Ogiltigt val
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
    }
}
