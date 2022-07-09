using System.Text;

namespace _06.StoreBoxes
{
    public class Box
    {
        public Box(int serialNumber, Item item, int quantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            Quantity = quantity;
        }

        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double BoxPrice => Quantity * Item.Price;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{SerialNumber}");
            sb.AppendLine($"-- {Item.Name} - ${Item.Price:f2}: {Quantity}");
            sb.AppendLine($"-- ${BoxPrice:f2}");
            return sb.ToString().Trim();
        }
    }
}
