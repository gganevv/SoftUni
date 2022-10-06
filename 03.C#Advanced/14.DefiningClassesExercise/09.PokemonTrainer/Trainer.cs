using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void CheckPokemonsHelth()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Health <= 0)
                {
                    Pokemons.RemoveAt(i);
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}