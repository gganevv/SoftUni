using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            int pokeIndex = 0;
            int index;

            while (pokemons.Count != 0)
            {
                index = int.Parse(Console.ReadLine());
                bool validIndex = true;
                if (index < 0)
                {
                    index = 0;
                    pokeIndex = pokemons[index];
                    sum += pokeIndex;
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);
                    validIndex = false;
                }

                if (index >= pokemons.Count)
                {
                    index = pokemons.Count - 1;
                    pokeIndex = pokemons[index];
                    sum += pokeIndex;
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(pokemons[0]);
                    validIndex = false;
                }

                if (validIndex)
                {
                    pokeIndex = pokemons[index];
                    sum += pokeIndex;
                    pokemons.RemoveAt(index);
                }

                

                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= pokeIndex)
                    {
                        pokemons[i] += pokeIndex;
                    }
                    else
                    {
                        pokemons[i] -= pokeIndex;
                    }
                    
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
