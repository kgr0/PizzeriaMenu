using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMenu.Domain
{
    public class Pizza
    {
        public Pizza(
            string name, 
            string description,
            List<string> ingredients,
            float price)
        {
            Name = name;
            Description = description;
            Ingredients = new List<Ingredient>();
            ingredients.ForEach(i => Ingredients.Add(new(i)));
            Price = price;
        }

        public Pizza()
        {
            Name = String.Empty;
            Description = String.Empty;
            Ingredients = new List<Ingredient>();
            Price = 0;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
