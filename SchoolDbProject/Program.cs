using System;
//TODO Snygga till utskrifter!

//TODO➡️ Det måste finnas en meny där man kan välja att visa olika data som efterfrågas av skolan. (I Console Bara till EF funktioner).

//TODO➡️ Hur många lärare jobbar på de olika avdelningarna?(EF VS)

//TODO➡️ Visa information om alla elever (EF VS)

//TODO➡️ Visa en lista på alla aktiva kurser (EF VS)

//TODO➡️ Skolan vill kunna ta fram en översikt över all personal där det framgår namn och vilka befattningar dem har samt hur många år de har arbetat på skolan. Administratören vill också ha möjlighet att spara ny personal. (SQL i SSMS)

//TODO➡️ Vi vill spara elever och se vilken klass de läser i. Vi vill kunna spara betyg för en elev i varje kurs de läst och vi vill kunna se vilken lärare som satt betyget. Betyg ska också ha ett datum som de sats.(SQL i SSMS)

//TODO➡️ Hur mycket betalar respektive avdelning ut i lön varje månad?(SQL SSMS)

//TODO➡️ Hur mycket är medellönen för de olika avdelningarna?(SQL SSMS)

//TODO➡️ Skapa en Stored Procedure som tar emot en id och returnerar viktig information om den eleven som är registrerad på det id. (SQL i SSMS)

//TODO➡️ Sätt betyg på en elev med att använda Transactions i fall något går fel (SQL i SSMS)

/*TODO⚙ Extra utmaningar
1-Visa information om en elev, vilken klass han tillhör och vilken/vilka lärare han har samt vilka betyg han har fått i en kurs.(SQL)
2 - Skapa en View som visar alla lärare och vilka utbildningar som dom ansvarar för.(SQL i SSMS)
3 - Uppdatera / korrigera en elevs information via koden (EF i VS)
*/
namespace SchoolDbProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}
