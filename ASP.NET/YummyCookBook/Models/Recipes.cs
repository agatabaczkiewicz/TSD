using System;
using System.ComponentModel.DataAnnotations;

namespace YummyCookBook.Models
{
    public class Recipes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int NumberOfLikes { get; set; }
        public string TipsAndTricks { get; set; }
        public string Ingredients { get; set; }
        public string Process { get; set; }

    }
}
