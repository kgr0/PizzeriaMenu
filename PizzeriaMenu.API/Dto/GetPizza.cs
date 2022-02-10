namespace PizzeriaMenu.API.Dto
{
    public class GetPizza
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<string> Ingredients { get; set; }

        public float Price { get; set; }

    }
}
