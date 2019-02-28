﻿using static System.Console;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using System.Linq;
using System;
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
                string result = await client.GetStringAsync(@"https://raw.githubusercontent.com/Andreas981/VerkstedFinder/master/postnummer.txt");

                client.DefaultRequestHeaders.Add("Accepted-Language", "no");
                client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");

                using (var db = new AndremiContext())
                {
                    var count = (from o in db.Poststeds select o).Count();
                    //Adding an if statement in case of someone calling the method when the database is alread populated
                    if (count < 10)
                    { 
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

        public static async Task InitializePermission()
        {
            WriteLine("Adding permissions...");
            Permission permissionCreate = new Permission(){Perm_name = "Create"};
            Permission permissionRead = new Permission(){Perm_name = "Read"};
            Permission permissionUpdate = new Permission(){Perm_name = "Update"};
            Permission permissionDelete = new Permission(){Perm_name = "Delete"};
            Permission permissionEditUsers = new Permission(){Perm_name = "Edit Users"};

            using (var db = new AndremiContext())
            {
                db.Permissions.Add(permissionCreate);
                db.Permissions.Add(permissionRead);
                db.Permissions.Add(permissionUpdate);
                db.Permissions.Add(permissionDelete);
                db.Permissions.Add(permissionEditUsers);

                db.SaveChanges();
            }
        }

        public static async Task InitializeRoles()
        {
            WriteLine("Adding roles...");
            Role user = new Role(){Name = "User"};
            Role admin = new Role(){Name = "Admin"};
            Role mod = new Role(){Name = "Moderator"};

            using (var db = new AndremiContext())
            {
                db.Roles.Add(user);
                db.Roles.Add(admin);
                db.Roles.Add(mod);

                db.SaveChanges();
            }
        }

    }
}