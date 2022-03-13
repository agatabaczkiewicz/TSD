using TSD.Linq.Task1.Lib;
using System.Linq;
using TSD.Linq.Task1.Lib.Model;


using System;
namespace TSD.Linq.Task1.App
{
    public class GoldApp
    {

        // Main Method
        static public void Main()
        {

            //.WriteLine("Hello, World!");
            var goldenClient = new GoldClient();
          //  FindTop3HighestPrice(goldenClient);
           // FindTop3HighestPriceQuery(goldenClient);
            // FindTop3LowestPrice(goldenClient);
            //CheckIfCanEarned(goldenClient);
            //FindSecendTenOfThePricesTop3(goldenClient);

        }

        public List<GoldPrice> FindSecendTenOfThePricesTop3(GoldClient goldenClient)
        {
            DateTime dateStart = new DateTime(2019, 1, 1);
            DateTime date2 = new DateTime(2021, 10, 5);
            DateTime dateEnd = dateStart.AddDays(93);
            var daysbeetween = (date2 - dateStart).Days;
            var prices = new List<GoldPrice>();
            // Console.Write($"Data:{daysbeetween}\n ");
            while (daysbeetween >= 93)
            {

                //Console.Write($"{dateStart}\n");
                List<GoldPrice> pricesPart = goldenClient.GetGoldPrices(dateStart, dateEnd).GetAwaiter().GetResult();
                List<GoldPrice> pricesPartSort = pricesPart.OrderByDescending(n => n.Price).Take(13).ToList();
                foreach (GoldPrice element in pricesPartSort)
                {
                    prices.Add(element);
                }
                daysbeetween -= 93;
                if (daysbeetween >= 93)
                {
                    dateStart = dateStart.AddDays(93);
                    dateEnd = dateEnd.AddDays(93);
                }

            }
            //Console.Write($"Data:{prices.Count}\n ");
            dateStart = dateStart.AddDays(daysbeetween);
            dateEnd = dateEnd.AddDays(daysbeetween);
            List<GoldPrice> pricesPartEnd = goldenClient.GetGoldPrices(dateStart, dateEnd).GetAwaiter().GetResult();
            List<GoldPrice> pricesPartSortEnd = pricesPartEnd.OrderByDescending(n => n.Price).Take(13).ToList();
            foreach (GoldPrice element in pricesPartSortEnd)
            {
                prices.Add(element);
            }
            List<GoldPrice> result = prices.OrderByDescending(n => n.Price).Take(3).ToList();
            return result;
           
        }

        public List<GoldPrice> FindSecendTenOfThePricesTop3Query(GoldClient goldenClient)
        {
            DateTime dateStart = new DateTime(2019, 1, 1);
            DateTime date2 = new DateTime(2021, 10, 5);
            DateTime dateEnd = dateStart.AddDays(93);
            var daysbeetween = (date2 - dateStart).Days;
            var prices = new List<GoldPrice>();
            // Console.Write($"Data:{daysbeetween}\n ");
            while (daysbeetween >= 93)
            {

                //Console.Write($"{dateStart}\n");
                List<GoldPrice> pricesPart = goldenClient.GetGoldPrices(dateStart, dateEnd).GetAwaiter().GetResult();
                List<GoldPrice> pricesPartSort = (from pricePart in pricesPart
                                                  orderby pricePart.Price descending
                                                  select pricePart).Take(13).ToList();
                foreach (GoldPrice element in pricesPartSort)
                {
                    prices.Add(element);
                }
                daysbeetween -= 93;
                if (daysbeetween >= 93)
                {
                    dateStart = dateStart.AddDays(93);
                    dateEnd = dateEnd.AddDays(93);
                }

            }
            //Console.Write($"Data:{prices.Count}\n ");
            dateStart = dateStart.AddDays(daysbeetween);
            dateEnd = dateEnd.AddDays(daysbeetween);
            List<GoldPrice> pricesPartEnd = goldenClient.GetGoldPrices(dateStart, dateEnd).GetAwaiter().GetResult();
            List<GoldPrice> pricesPartSortEnd = (from pricePart in pricesPartEnd
                                     orderby pricePart.Price descending
                                     select pricePart).ToList(); 
            foreach (GoldPrice element in pricesPartSortEnd)
            {
                prices.Add(element);
            }
            List<GoldPrice> result = (from price in prices
             orderby price.Price descending
             select price).Take(3).ToList();
            return result;
            
        }

        public List<GoldPrice> CheckIfCanEarned(GoldClient goldenClient)
        {
            DateTime date1 = new DateTime(2020, 1, 1);
            DateTime date2 = new DateTime(2020, 1, 31);
            Console.Write($"Data:{date1 - date2}  ");
            var priceWhenBuy = goldenClient.GetCurrentGoldPrice().GetAwaiter().GetResult();
            Console.Write($"Data:{priceWhenBuy.Date} Cena: {priceWhenBuy.Price}\n ");
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();

            List<GoldPrice> pricesBest = prices.Select(n => n).Where(n => 5 < 100 * (priceWhenBuy.Price - n.Price) / n.Price).ToList();
            return pricesBest;
         
        }

        public List<GoldPrice> CheckIfCanEarnedQuery(GoldClient goldenClient)
        {
            DateTime date1 = new DateTime(2020, 1, 1);
            DateTime date2 = new DateTime(2020, 1, 31);
            Console.Write($"Data:{date1 - date2}  ");
            var priceWhenBuy = goldenClient.GetCurrentGoldPrice().GetAwaiter().GetResult();
            Console.Write($"Data:{priceWhenBuy.Date} Cena: {priceWhenBuy.Price}\n ");
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();

            List<GoldPrice> pricesBest = (from price in prices 
                             where 5 < 100 * (priceWhenBuy.Price - price.Price) / price.Price
                             select price).ToList();
            return pricesBest;
           
        }

        public List<GoldPrice> FindTop3LowestPrice(GoldClient goldenClient)
        {

            DateTime date1 = new DateTime(2021, 1, 1);
            DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
            Console.Write($"Data:{prices.Count}\n ");
            List<GoldPrice> pricesTop3 = prices.OrderBy(n => n.Price).Take(3).ToList();
            return pricesTop3;
            //  Console.WriteLine(pricesTop3.ToString());



        }

        public List<GoldPrice> FindTop3HighestPrice(GoldClient goldenClient)
        {

            DateTime date1 = new DateTime(2021, 1, 1);
            DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
            Console.Write($"Data:{prices.Count}\n ");
            List<GoldPrice> pricesTop3 = prices.OrderByDescending(n => n.Price).Take(3).ToList();

            return pricesTop3;

        }

        public List<GoldPrice> FindTop3HighestPriceQuery(GoldClient goldenClient)
        {

            DateTime date1 = new DateTime(2021, 1, 1);
            DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
            Console.Write($"Data:{prices.Count}\n ");
            List<GoldPrice> pricesTop3 = (from price in prices
                              orderby price.Price descending
                              select price).Take(3).ToList();

            return pricesTop3;
    


        }

        public List<GoldPrice> FindTop3LowestPriceQuery(GoldClient goldenClient)
        {

            DateTime date1 = new DateTime(2021, 1, 1);
            DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
            Console.Write($"Data:{prices.Count}\n ");
            List<GoldPrice> pricesTop3 = (from price in prices
                                          orderby price.Price 
                                          select price).Take(3).ToList();

            return pricesTop3;       


        }
    }
}
