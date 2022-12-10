namespace ChristmasPastryShop.Repositories
{
    using System.Collections.Generic;

    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Repositories.Contracts;

    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> cocktails;

        public CocktailRepository()
        {
            cocktails= new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => cocktails.AsReadOnly();

        public void AddModel(ICocktail cocktail)
        {
            cocktails.Add(cocktail);
        }
    }
}
