using System;
using static System.Console;
namespace VerkstedFinder.Context
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Press [ENTER] to continue");
            ReadLine();

            /*using (var db = new AndremiContext())
            {
                    WriteLine("Adding some post numbers and places");

                    var query = db.Poststeds;
                    foreach (var item in query)
                    {
                        WriteLine(item.Postnr + ", " + item.PoststedName);
                    }
            }*/
            //Initialize.InitPostNumbers();
            //Initialize.InitializePermission();
            //Initialize.InitializeRoles();
            Initialize.InitializeWorkshops();
            ReadLine();

        }
    }
}
