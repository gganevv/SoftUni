namespace ChristmasPastryShop.Core
{
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using Contracts;
    using Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private BoothRepository booths;
        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            booths.AddModel(new Booth(boothId, capacity));
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == delicacyName) != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName == "Gingerbread")
            {
                booth.DelicacyMenu.AddModel(new Gingerbread(delicacyName));
            }
            else if (delicacyTypeName == "Stolen")
            {
                booth.DelicacyMenu.AddModel(new Stolen(delicacyName));
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == cocktailName && x.Size == size) != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (cocktailTypeName == "Hibernation")
            {
                booth.CocktailMenu.AddModel(new Hibernation(cocktailName, size));
            }
            else if (cocktailTypeName == "MulledWine")
            {
                booth.CocktailMenu.AddModel(new MulledWine(cocktailName, size));
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> booths = this.booths.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople).OrderBy(x => x.Capacity).ThenByDescending(x => x.BoothId).ToList();
            IBooth booth = booths.FirstOrDefault();
            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);

            string[] orderArgs = order.Split("/", System.StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderArgs[0];
            string itemName = orderArgs[1];
            int countOfOrderedPieces = int.Parse(orderArgs[2]);

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == itemName);
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
            }
            else if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                if (booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName) == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                string size = orderArgs[3];
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(x => x.Name == itemName && x.Size == size);
                if (cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }
                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, countOfOrderedPieces, itemName);
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            double bill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {bill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            return booth.ToString();
        }
    }
}
