namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using System.Text;
    
    using Contracts;
    using Cocktails.Contracts;
    using Delicacies.Contracts;
    using Repositories.Contracts;
    using Utilities.Messages;
    using ChristmasPastryShop.Repositories;

    public class Booth : IBooth
    {
        private DelicacyRepository delicacyMenu;
        private CocktailRepository cocktailMenu;
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => cocktailMenu;

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine("-Cocktail menu:");
            foreach (var cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().Trim();
        }
    }
}
