using System;
using System.Text;

namespace task4
{
    class Product
    {
        public string[] Names;
        public decimal[] Prices;
        public decimal[] Discounts;
        public decimal[] DiscountedPrices;
        public float[] Quantities;
        public decimal[] Totals;
        public float[] Vats;
        public Product(string[] Names, decimal[] Prices, decimal[] Discounts, float[] Quantities, float[] Vats)
        {
            this.Names = Names;
            this.Prices = Prices;
            this.Discounts = Discounts;
            DiscountedPrices = new decimal[Names.Length];
            for (int i = 0; i < Names.Length; i++)
            {
                this.DiscountedPrices[i] = Prices[i] - Discounts[i];
            }
            this.Quantities = Quantities;
            Totals = new decimal[Names.Length];
            for (int i = 0; i < Names.Length; i++)
            {
                this.Totals[i] = this.DiscountedPrices[i] * (decimal)Quantities[i];
            }
            this.Vats = Vats;
        }
    }

    class Purchase
    {
        public int bonusesUsed = 0;
    }

    class ClubCard
    {
        public string cardNumber = "7789548621452829";
        public int bonuses = 2049;

        public int CountBonuses(decimal _totalBillSum)
        {
            return (int)Math.Floor(_totalBillSum * 0.015m * 100);
        }
        public string HideCardNumber(string _cardNumber)
        {
            return _cardNumber.Substring(0, 4) + "*****" + _cardNumber.Substring(12, 4);
        }
    }

    class Bill
    {
        Product pr;
        public int Width;
        public Bill(int Width, Product pr)
        {
            this.Width = Width;
            this.pr = pr;
        }
        public readonly string Header = "Перекрёсток";
        public readonly string HotLine = "ГОРЯЧАЯ ЛИНИЯ 8-800-200-95-55";
        public readonly string Name = "КАССОВЫЙ ЧЕК";
        StringBuilder sb = new StringBuilder();

        public string BuildLineCenter(string _info, char _aggregate)
        {
            sb.Clear();

            int lineBeginning = Width / 2 - _info.Length / 2;
            
            for (int i = 0, j = 0; i < Width; i++)
            {
                if ((i < lineBeginning) ^ (i >= lineBeginning + _info.Length))
                {
                    sb.Insert(i, _aggregate);
                }
                else
                {
                    sb.Insert(i, _info[j]);
                    j++;
                }

            }
            return sb.ToString();
        }

        public string BuildTableLine(decimal _price, decimal _discount, float _quantity, float _vat)
        {
            string resultString = "";
            decimal discountedPrice = _price - _discount;
            decimal totalSum = Math.Round(discountedPrice * (decimal)_quantity, 2);

            resultString = String.Format("{0,18:f}{1,18:f}{2,18:f}{3,18:f3}{4,18:f}{5,18:P0}", _price, _discount, discountedPrice, _quantity, totalSum, _vat);
            return resultString;
        }

        public decimal TotalDiscount(decimal[] _discounts)
        {
            decimal result = 0;
            decimal discountedPrice = 0;
            for (int i = 0; i < _discounts.Length; i++)
            {
                //discountedPrice = _prices[i] - _discounts[i];
                result += pr.Discounts[i];
            }

            return result;
        }

        public decimal TotalSum(decimal[] _prices, decimal[] _discounts, float[] _quantities)
        {
            decimal result = 0;
            decimal productSum = 0;
            for (int i = 0; i < _prices.Length; i++)
            {
                //productSum = Math.Round((_prices[i] - _discounts[i]) * (decimal)_quantities[i], 2);
                result += pr.Totals[i];
            }

            return result;
        }
        public decimal CountVat(decimal _totals, float _vats)
        {
            decimal resultVat = 0;
            resultVat += _totals * (decimal)_vats / (1 + (decimal)_vats);
            return resultVat;
        }
    }

    class Program
    {
        const int billWidth = 108;
        const int aligmnetLength = billWidth / 6;

        static void Main(string[] args)
        {
            string[] names = new string[] { "Хлебцы", "Масло", "Маффин", "Яблоки", "Мёд", "Лук зелёный", "Огурцы", "Томаты", "Овощная смесь", "Укроп зелёный", "Тыква" };
            decimal[] prices = new decimal[] { 87.9m, 579.0m, 89.9m, 119.96m, 199.0m, 59.9m, 229.9m, 129.9m, 149.9m, 69.9m, 99.9m };
            decimal[] discounts = new decimal[] { 0m, 279.1m, 0m, 20.06m, 0m, 0m, 60.0m, 0m, 70.0m, 0m, 0m };
            float[] quantities = new float[] { 1, 1, 2, 0.776f, 1, 0.243f, 0.483f, 2, 1, 0.143f, 1.312f };
            float[] vats = new float[] { 0.1f, 0.1f, 0.2f, 0.1f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f };
            Product pr = new Product(names, prices, discounts, quantities, vats);
            Bill bl = new Bill(billWidth, pr);
            ClubCard cc = new ClubCard();
            Purchase prch = new Purchase();
            decimal totalSum = 0;
            decimal totalDiscount = 0;
            Console.WriteLine(bl.BuildLineCenter(bl.Header, ' '));
            Console.WriteLine(bl.BuildLineCenter(bl.HotLine, '*'));
            Console.WriteLine(bl.BuildLineCenter(bl.Name, ' '));
            Console.WriteLine("{0,18}{1,18}{2,18}{3,18}{4,18}{5,18}", "Цена", "Скидка", "Цена со скидкой", "Кол-во", "Итого", "НДС");
            for (int i = 0; i < pr.Names.Length; i++)
            {
                Console.WriteLine($"{i + 1}: " + pr.Names[i]);
                Console.WriteLine(bl.BuildTableLine(pr.Prices[i], pr.Discounts[i], pr.Quantities[i], pr.Vats[i]));
            }
            totalSum = bl.TotalSum(pr.Prices, pr.Discounts, pr.Quantities);
            totalDiscount = bl.TotalDiscount(pr.Discounts);
            Console.WriteLine("{0,-54}{1,54}", "Итого с учётом скидок:", totalSum);
            Console.WriteLine("{0,-54}{1,54}", "Ваша суммарная скидка:", totalDiscount);
            Console.WriteLine(bl.BuildLineCenter("", '.'));
            Console.WriteLine("{0,-25}{1,-15}", "Карта клуба:", cc.HideCardNumber(cc.cardNumber));
            Console.WriteLine("{0,-25}{1,-15}", "Начислено баллов:", cc.CountBonuses(totalSum));
            Console.WriteLine("{0,-25}{1,-15}", "Списано баллов:", prch.bonusesUsed);
            Console.WriteLine("{0,-25}{1,-15}", "Баланс баллов:", cc.bonuses + cc.CountBonuses(totalSum));
            Console.WriteLine(bl.BuildLineCenter("", '-'));
            decimal vat10 = 0;
            decimal vat20 = 0;
            for (int i = 0; i < pr.Names.Length; i++)
            {
                if (pr.Vats[i] == 0.1f)
                {
                    vat10 += bl.CountVat(pr.Totals[i], pr.Vats[i]);
                }
                else if (pr.Vats[i] == 0.2f)
                {
                    vat20 += bl.CountVat(pr.Totals[i], pr.Vats[i]);
                }
            }
            Console.WriteLine("{0,-26}{1,26:f2}    {2,-26}{3,26:f2}", "Сумма НДС 20%: ", vat20, "Сумма НДС 10%: ", vat10);
            Console.WriteLine(bl.BuildLineCenter("", '-'));
            Console.WriteLine(bl.BuildLineCenter("Спасибо за покупку!", ' '));
        }
    }
}
