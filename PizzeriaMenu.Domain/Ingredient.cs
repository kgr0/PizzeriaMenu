using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzeriaMenu.Domain
{
    public class Ingredient
    {
        public Ingredient(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int PizzaId { get; set; }

        [JsonIgnore]
        public Pizza? Pizza { get; set; }
    }
}
