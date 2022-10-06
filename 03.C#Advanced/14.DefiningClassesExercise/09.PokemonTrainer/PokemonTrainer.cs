using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class PokemonTrainer
    {
        static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();
            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                AddTrainers(trainers, input);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                CheckElements(trainers, input);

                input = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(x => x.Badges).ToList();
            trainers.ForEach(x => Console.WriteLine(x));
        }

        private static void CheckElements(List<Trainer> trainers, string input)
        {
            string element = input;
            foreach (Trainer trainer in trainers)
            {
                bool playerWon = false;
                foreach (var pokemon in trainer.Pokemons)
                {
                    if (pokemon.Element == element)
                    {
                        playerWon = true;
                        continue;
                    }
                }
                if (playerWon)
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.ForEach(x => x.Health -= 10);
                }

                trainer.CheckPokemonsHelth();
            }
        }

        private static void AddTrainers(List<Trainer> trainers, string input)
        {
            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string trainerName = inputArgs[0];
            string pokemonName = inputArgs[1];
            string pokemonElement = inputArgs[2];
            int pokemonHealth = int.Parse(inputArgs[3]);

            if (!trainers.Any(x => x.Name == trainerName))
            {
                trainers.Add(new Trainer(trainerName));
            }
            trainers.FirstOrDefault(x => x.Name == trainerName)
                .Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }
    }
}