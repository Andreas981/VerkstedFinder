using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

using VerkstedFinder.Model;

namespace VerkstedFinder.Context
{
    class Initialize
    {
        
        public static async Task InitPostNumbers()
        {

            try
            {
                WriteLine("Getting postnumbers...");

                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync(@"https://raw.githubusercontent.com/Andreas981/VerkstedFinder/master/postnummer");


                client.DefaultRequestHeaders.Add("Accepted-Language", "no");
                client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");

                using (var db = new AndremiContext())
                {
                    var count = (from o in db.Poststeds select o).Count();
                    //Adding an if statement in case of someone calling the method when the database is alread populated
                    if (count < 10)
                    {
                        WriteLine("Adding to database...");
                        for (int i = 0; i < result.Split("\n").Length - 1; i++)
                        {
                            for (int j = 0; j < result.Split("\n")[i].Split("|").Length - 1; j++)
                            {
                                WriteLine(result.Split("\n")[i].Split("|")[0] + " finnes i " + result.Split("\n")[i].Split("|")[1]);

                                Poststed poststed = new Poststed()
                                {
                                    Postnr = Convert.ToInt32(result.Split("\n")[i].Split("|")[0]),
                                    PoststedName = result.Split("\n")[i].Split("|")[1]
                                };
                                db.Poststeds.Add(poststed);
                            }
                        }
                        db.SaveChanges();
                    }
                }

            }catch(Exception e)
            {
                WriteLine("Sorry, could not find the postnumber file");
                WriteLine(e.StackTrace);
            }
        }
        
        public static async Task InitializeWorkshops()
        {
            WriteLine("Getting workshops...");
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(@"https://raw.githubusercontent.com/Andreas981/VerkstedFinder/master/verksted");

            client.DefaultRequestHeaders.Add("Accepted-Language", "no");
            client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");

            using (var db = new AndremiContext())
            {
                WriteLine("Adding to database...");
                for(int i = 5001; i < result.Split("\n").Length-1; i++)
                {
                    WriteLine(result.Split("\n")[i]);
                    string[] data = new string[6];
                    for(int j = 0; j < result.Split("\n")[i].Split(";").Length; j++)
                    {
                        data[j] = result.Split("\n")[i].Split(";")[j];
                    }
                    Poststed poststed = db.Poststeds.FirstOrDefault(p => p.Postnr == Convert.ToInt32(data[2]));
                    WriteLine(poststed);

                    Workshop workshop = new Workshop()
                    {
                        Ws_name = data[0],
                        Ws_address = data[1],
                        Ws_orgnumber = data[5]
                    };
                    workshop.Ws_poststed = poststed;

                    if(poststed != null)
                        db.Workshops.Add(workshop);

                    WriteLine("Added");
                    if(i == 5500)
                    {
                        break;
                    }
                }
                WriteLine("Saving...");

                db.SaveChanges();
                WriteLine("Finished");
            }

        } 

        public static void InitializeRoles()
        {
            WriteLine("Adding roles...");
            Role user = new Role(){Name = "User"};
            Role admin = new Role(){Name = "Admin"};
            Role mod = new Role(){Name = "Moderator"};

            using (var db = new AndremiContext())
            {
                var count = (from o in db.Roles select o).Count();
                if (count < 1)
                {
                    db.Roles.Add(user);
                    db.Roles.Add(admin);
                    db.Roles.Add(mod);

                    db.SaveChanges();
                }
            }
        }

    }
}
