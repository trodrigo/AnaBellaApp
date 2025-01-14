﻿using System.ComponentModel.DataAnnotations;

namespace AnaBellaApp.Web.Models.Store
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string ImageURL { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            if (Name.Length < 24) return Name;
            return $"{Name.Substring(0, 21)} ...";
        }

        public string SubstringDescription()
        {
            if (Description.Length < 355)
            {
                int increment = 355 - Description.Length;
                for (int i = 0; i <= increment; i++) 
                {
                    Description += " ";
                }
                return Description ;
            }
            return $"{Description.Substring(0, 352)} ...";
        }
    }
}
