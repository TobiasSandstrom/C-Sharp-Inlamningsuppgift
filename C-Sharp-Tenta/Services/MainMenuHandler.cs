using C_Sharp_Tenta.Classes;
using C_Sharp_Tenta.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Tenta.Services
{
    public interface IMenuHandler
    {
        public void MainMenu();
        public List<Guest> MenuRegister(List<Guest>guests, string fileLocation, GuestHandler worker);
        public void MenuListGuests(List<Guest>guests, GuestHandler worker);

        public void MenuRemoveGuest(List<Guest> guests, string fileLocation, GuestHandler worker);
    }

    public class MainMenuHandler : IMenuHandler
    {
        public void MainMenu()
        {
            // Ange vart textfilen ska hamna i stringen nedan
            string fileLocation = @"";
            List<Guest> guests = new List<Guest>();
            GuestHandler worker = new GuestHandler();
            DiscountCodeGenerator generator = new DiscountCodeGenerator();
            int UserInput;
            bool application = true;
            while (application)
            {


                Console.Clear();
                Console.WriteLine("Konferens");
                Console.WriteLine("1) Registrera dig \n" +
                                  "2) Lista upp registrerade gäster \n" +
                                  "3) Ta bort gäst från listan \n" +
                                  "4) Generera rabattkod \n" +
                                  "5) Avsluta");


                // Konverterar användarens input till en int och genom en switch kollar vad denne vill göra
                if (Int32.TryParse(Console.ReadLine(), out UserInput))
                {
                    switch (UserInput)
                    {
                        case 1:
                            guests = MenuRegister(guests, fileLocation, worker);
                            break;
                        case 2:
                            MenuListGuests(guests, worker);
                            break;
                        case 3:
                            MenuRemoveGuest(guests, fileLocation, worker);
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine($"Din rabattkod: {generator.GenerateDiscountCode()}");
                            Console.ReadLine();
                            break;
                        case 5:
                            application = false;
                            break;

                        default:
                            Console.WriteLine("Ange en siffra mellan 1-5");
                            Console.ReadLine();

                            break;
                    }

                }
                else { 
                    Console.WriteLine("Du måste ange en siffra");
                    Console.ReadLine();
                }
            }
        }

        // Metod som kallas på när användaren vill registrera en gäst.
        // Metoden kallar på Guest.AddGuest så användaren får mata in sin information 
        // och efter det kallar på Guest.WriteGuestToFile för att uppdatera textfilen
        public List<Guest> MenuRegister(List<Guest> guests, string fileLocation, GuestHandler worker)
        {
            guests.Add(worker.AddGuest());
            worker.WriteGuestsToFile(fileLocation, guests);
            return guests;

        }



        // Metod som listar upp alla gäster i listan ifall listan har 1 eller mer gäster
        public void MenuListGuests(List<Guest> guests, GuestHandler worker)
        {
            if (guests.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("Alla gäster som kommer: \n");
                worker.ListAllGuests(guests);
            }
            else
            {
                Console.WriteLine("Gästlistan är tom");
            }
            Console.ReadLine();
        }
        
        // Metod som låter användaren välja vilken gäst som ska tas bort ifrån listan ifall listan har 1 eller mer gäster
        public void MenuRemoveGuest(List<Guest> guests, string fileLocation, GuestHandler worker)
        {
            if (guests.Count > 0)
            {

                Console.Clear();
                Console.WriteLine("Vilken gäst vill ni ta bort? Ange siffran som står innan namnet\n");
                worker.ListAllGuests(guests);
                Console.WriteLine(worker.RemoveGuestFromList(Console.ReadLine(), fileLocation, guests));
            }
            else
            {
                Console.WriteLine("Gästlistan är tom");
            }
            Console.ReadLine();
        }
    }
}
