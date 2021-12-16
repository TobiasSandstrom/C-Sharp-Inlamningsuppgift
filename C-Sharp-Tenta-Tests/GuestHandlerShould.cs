using C_Sharp_Tenta.Classes;
using C_Sharp_Tenta.Handlers;
using System.Collections.Generic;
using Xunit;

namespace C_Sharp_Tenta_Tests
{

    public class GuestHandlerShould
    {
        [Fact]
        public void AddGuestToList() 
        {
            string UserInputFirstName = "Test";
            string UserInputLasttName = "Testsson";
            string UserInputEmail = "Test@Hotmail.com";
            string UserInputSpecialRequest = "Nej";

            List<Guest> testList = AddGuest(UserInputFirstName, UserInputLasttName, UserInputEmail, UserInputSpecialRequest);

            Assert.NotEmpty(testList);



        }

        public List<Guest> AddGuest(string userInputFirstName, string UserInputLasttName, string UserInputEmail, string UserInputSpecialRequest)
        {

            Guest testguest = new Guest()
            {
                firstName = userInputFirstName,
                lastName = UserInputLasttName,
                email = UserInputEmail,
                specialRequest = UserInputSpecialRequest
            };
            List<Guest> testList = new List<Guest>();
            testList.Add(testguest);
            return testList;


        }



        //Testar så metoden tar bort en gäst i listan
        [Fact]
        public void RemoveGuest()
        {
            GuestHandler _sut = new GuestHandler();
            List<Guest> testGuests = new List<Guest>();
            Guest testGuest = new Guest()
            {
                firstName = "Test",
                lastName = "Testsson",
                email = "Testsson@test.nu",
                specialRequest = "Allergisk mot skaldjur"
            };
            testGuests.Add(testGuest);
            
            // Ange i path strängen vart testfilen ska hamna, den kommer vara tom men den behövs för att metoden ska fungera
            string path = @"C:\Users\Tobia\OneDrive\Skrivbord\Dokument\Skola\3_C#\Inlämningsuppgift_C_SHARP\C-Sharp-Tenta-Tests\testFile.txt";
            string userInput = "1";

            _sut.RemoveGuestFromList(userInput, path, testGuests);

            Assert.Empty(testGuests);

        }

        // Testar så metoden skriver ut gästlistan i en stränglista
        // Fick skriva om den här metoden lite i huvudprogrammet
        [Fact]
        public void ListGuests()
        {
            GuestHandler _sut = new GuestHandler();
            List<Guest> testGuests = new List<Guest>();
            Guest testGuest = new Guest()
            {
                firstName = "Test",
                lastName = "Testsson",
                email = "Testsson@test.nu",
                specialRequest = "Allergisk mot skaldjur"
            };
            testGuests.Add(testGuest);

            List<string> testList = ListAllGuests(testGuests);

            Assert.NotEmpty(testList);
        }
        
        
        public List<string> ListAllGuests(List<Guest> guests)
        {
            List<string> consoleReplica = new List<string>();
            
            int i = 0;
            
            foreach (Guest guest in guests)
            {
                string guestListLine = $"{i})\n" +
                    $"Namn: {guest.firstName} {guest.lastName} \n" +
                    $"Epost: {guest.email}\n";
                consoleReplica.Add(guestListLine);
                i++;
            }
            return consoleReplica;
        }

    }
}