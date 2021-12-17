using C_Sharp_Tenta.Classes;
using C_Sharp_Tenta.Handlers;
using System.Collections.Generic;
using Xunit;

namespace C_Sharp_Tenta_Tests
{

    public class GuestHandlerShould
    {   
        // Testar s� metoden skapar och l�gger till en g�st i g�stlistan
        // Testvarianten och huvudprogrammets metod skiljer sig lite pga att huvudprogrammet beh�ver anv�ndarens input/readlines
        [Fact]
        public void AddGuestToList() 
        {
            string UserInputFirstName = "Test";
            string UserInputLasttName = "Testsson";
            string UserInputEmail = "Test@Hotmail.com";
            string UserInputSpecialRequest = "Nej";

            List<Guest> testList = CreateGuestAndAddToList(UserInputFirstName, UserInputLasttName, UserInputEmail, UserInputSpecialRequest);

            Assert.NotEmpty(testList);



        }

        public List<Guest> CreateGuestAndAddToList(string userInputFirstName, string UserInputLasttName, string UserInputEmail, string UserInputSpecialRequest)
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

        //-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-


        // Testar s� metoden tar bort en g�st i listan

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
            
            // Ange i path str�ngen vart testfilen ska hamna, den kommer vara tom men den beh�vs f�r att metoden ska fungera
            string path = @"";
            string userInput = "1";

            _sut.RemoveGuestFromList(userInput, path, testGuests);

            Assert.Empty(testGuests);

        }


        //-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-


        // Testar s� metoden skriver ut g�stlistan i en str�nglista
        // Testvarianten och huvudprogrammets metod skiljer sig lite pga att huvudprogrammets beh�ver anv�ndarens input/readlines
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
        //-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-
    }
}