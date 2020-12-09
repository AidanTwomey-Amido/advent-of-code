using System.Collections.Generic;

namespace BagHandling.Library
{
    public record Bag
    {
        public string Modifier { get; init;}

        public Bag(string modifier, string colour)
        {
            Modifier = modifier;
            Colour = colour;

            this.Parents = new List<Bag>();
            this.Children = new List<Bag>();
        }

        public string Colour { get; init;}
        public List<Bag> Parents { get; private set;}
        public List<Bag> Children { get; private set;}

        public string Id => $"{Modifier}_{Colour}";

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
