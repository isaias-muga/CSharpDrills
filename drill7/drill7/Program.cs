namespace drill7
{
    public class Product
    {
        public required string Name { get; set; }
        public required string SKU { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string sku)
        {
            Name = name;
            SKU = sku;
        }
        public virtual void CalculateFinalPrice(decimal price)
        {
            Price = price;
        }
    }

    class PhysicalGoods : Product
    {
        public decimal Weight { get; set; }
        public PhysicalGoods(string name, string sku, decimal weight) : base(name, sku)
        {
            Weight = weight;
        }
        public override void CalculateFinalPrice(decimal price)
        {
            decimal shippingCost = Weight * 0.5m;
            Price = price + shippingCost;
        }
    }

    class DigitalGoods : Product
    {
        public string DownloadLink { get; set; }
        public DigitalGoods(string name, string sku, string downloadLink) : base(name, sku)
        {
            DownloadLink = downloadLink;
        }
        public enum SubscriptionLevel
        {
            Standard,
            Premiun,
            Deluxe
        }
        class SubscripcionGoods : Product
        {
            public required SubscriptionLevel Level { get; set; }
            public SubscripcionGoods(string name, string sku, SubscriptionLevel level) : base(name, sku)
            {
                Level = level;
            }
            public override void CalculateFinalPrice(decimal price)
            {
                Price = Level switch
                {
                    SubscriptionLevel.Standard => price + 0.25m,
                    SubscriptionLevel.Premiun => price + 0.50m,
                    SubscriptionLevel.Deluxe => price + 0.75m,
                    _ => throw new ArgumentOutOfRangeException(nameof(Level), "Invalid subscription level")
                };

            }
        }


        class Program
        {
            static void Main(string[] args)
            {
            }
        }
    }