using System;
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
