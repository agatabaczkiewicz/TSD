using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YummyCookBook.Models;
namespace YummyCookBook
{
   
    public class Program
    {
      
        static public List<Recipes> recipes = new List<Recipes>()
        {
               new Recipes { Id = 1, Name = "Tomato Soup", Difficulty = 3, NumberOfLikes = 30, TipsAndTricks = "Add some sugar", Ingredients ="Tommatoes, water, cream", Process ="boiling" },
              new Recipes { Id = 2, Name = "Tomato Soup", Difficulty = 3, NumberOfLikes = 30, TipsAndTricks = "Add some sugar", Ingredients ="Tommatoes, water, cream", Process ="boiling" }

        };
        public static void Main(string[] args)
        {
       
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
