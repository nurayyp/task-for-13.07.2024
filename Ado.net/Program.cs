using Ado.net.Constants;
using Ado.net.Services;

namespace Ado.net
{
    public static class Program
    {
        public static void Main()
        {
            bool continuity = true;
            while (continuity)
            {
                ShowMenu();
                string choiceInput = Console.ReadLine();
                int choice;
                bool isSucceeded = int.TryParse(choiceInput, out choice);
                if (isSucceeded)
                {
                    switch ((Operations)choice)
                    {
                        case Operations.AllCountries:
                            CountryService.GetAllCountries();
                            break;
                        case Operations.AddCountry:
                            CountryService.AddCountry();
                            break;
                        case Operations.UpdateCountry:
                            CountryService.UpdateCountry();
                            break;
                        case Operations.DeleteCountry:
                            CountryService.DeleteCountry();
                            break;
                        case Operations.DetailsOfCountry:
                            CountryService.GetCountryDetails();
                            break;
                        case Operations.Exit:
                            continuity = false;
                            break;
                        default:
                            Messages.InvalidInputMessage("choice");
                            break;
                    }
                }
                else
                {
                    Messages.InvalidInputMessage("choice");
                }
            }
        }
        public static void ShowMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1 - Get All Countries");
            Console.WriteLine("2 - Add Country");
            Console.WriteLine("3 - Update Country");
            Console.WriteLine("4 - Delete Country");
            Console.WriteLine("5 - Details of Country");
            Console.WriteLine("0 - Exit");
        }
    }
}