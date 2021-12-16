using C_Sharp_Tenta.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Tenta.Handlers
{
    public interface IGuestHandler
    {
        Guest AddGuest();
        void ListAllGuests(List<Guest> guests);
        public void WriteGuestsToFile(string fileLocation, List<Guest> guests);
    }
    public class GuestHandler : IGuestHandler
    {
        public Guest AddGuest()
        {
            Guest guest = new Guest();
            string ?svar;
            bool loop = true;
            bool loop2;

            while (loop)
            {
                bool fName = true;
                bool lName = true;
                bool eMail = true;

                // Användaren anger sitt förnamn och inputen sparas i en ny guests firstName
                while (fName)
                {
                    Console.Clear();
                    Console.WriteLine("Ange ert förnamn: ");
                    string ?firstName = Console.ReadLine();

                    if (!string.IsNullOrEmpty(firstName))
                    {
                        guest.firstName = firstName;
                        fName = false;
                    }
                }

                // Användaren anger sitt efternamn och inputen sparas i en ny guests lastName
                while (lName)
                {
                    Console.Clear();
                    Console.WriteLine("Ange ert efternamn: ");
                    string ?lastName = Console.ReadLine();

                    if (!string.IsNullOrEmpty(lastName))
                    {
                        guest.lastName = lastName;
                        lName = false;
                    }
                }

                // Användaren anger sitt email och inputen sparas i en ny guests email
                while (eMail)
                {
                    Console.Clear();
                    Console.WriteLine("Ange er email: ");
                    string ?email = Console.ReadLine();

                    if (!string.IsNullOrEmpty(email))
                    {
                        guest.email = email;
                        eMail = false;
                    }
                }



                // Användaren får ange ifall denne har några speciella önskemål, inputen sparas i den nya guestens specialRequest
                loop2 = true;
                while (loop2)
                {
                    Console.Clear();
                    Console.WriteLine("Har ni några speciella önskemål? J / N ");
                    svar = Console.ReadLine();

                    // Använder string.ToLower() så det inte spelar roll ífall användaren använder stort eller liten bokstav
                    switch (svar.ToLower())
                    {
                        case "j":
                            if (!string.IsNullOrEmpty(svar))
                            {
                                Console.WriteLine("Vad önskar ni? : ");
                                guest.specialRequest = Console.ReadLine();

                                loop = false;
                                loop2 = false;   
                            }
                            break;

                        case "n":
                            guest.specialRequest = "Nej";
                            loop = false;
                            loop2 = false;
                            break;

                        default:
                            Console.WriteLine("Ange J eller N");
                            Console.ReadLine();
                            break;
                    }

                }
            }
            Console.WriteLine("Gäst är nu registrerad");
            Console.ReadLine();
            return guest;
        }

       
        //Metod för att lista alla gäster i consolen
        public void ListAllGuests(List<Guest> guests)
        {
            int i = 1;
            foreach (Guest guest in guests)
            {
                Console.WriteLine($"{i})\n" +
                    $"Namn: {guest.firstName} {guest.lastName} \n" +
                    $"Epost: {guest.email}\n");
                i++;
            }
        }

        //Metod som skriver alla gäster i gästlistan till en textfil
        public void WriteGuestsToFile(string fileLocation, List<Guest> guests)
        {
            StreamWriter sw = new StreamWriter(fileLocation);
            using (sw)
            {
                foreach (Guest guest in guests)
                    sw.WriteLine($"Namn: {guest.firstName} {guest.lastName}. Email: {guest.email}. Speciella Önskemål: {guest.specialRequest}");
            }
        }

        //Metod som tar bort en gäst ifrån gästlistan
        public string RemoveGuestFromList(string userInput, string fileLocation, List<Guest> guests)
        {
            string name;
            if (Int32.TryParse(userInput, out int parsedInput))
            {
                try
                {
                    name = $"{guests[parsedInput - 1].firstName} {guests[parsedInput - 1].lastName}";
                    guests.RemoveAt((parsedInput - 1));
                }
                catch (Exception)
                {

                    return "Kunde inte hitta en gäst som matchar det nummret";
                }
            }

            else
            {
                return "Ni måste ange en siffra";
            }

            WriteGuestsToFile(fileLocation, guests);
            return $"{name} har nu tagits bort och listan har uppdaterats";
        }
    }
}
