using TSD.Linq.Task1.Lib;
using System.Linq;
using TSD.Linq.Task1.Lib.Model;


using System;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace TSD.Linq.Task1.App
{
    public class GoldApp
    {

        // Main Method
        static public void Main()
        {

            //.WriteLine("Hello, World!");
            var goldenClient = new GoldClient();
            DateTime date1 = new DateTime(2021, 1, 1);
            DateTime date2 = new DateTime(2021, 12, 31);
            // SaveToXML(goldenClient, date1, date2);  
            FromXML();
            //    AveragePriceQuery(goldenClient);
            // Invest(goldenClient);
            //InvestQuery(goldenClient);
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
            while (daysbeetween >= 93)
            {


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

            while (daysbeetween >= 93)
            {


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
         
            var priceWhenBuy = goldenClient.GetCurrentGoldPrice().GetAwaiter().GetResult();
            Console.Write($"Data:{priceWhenBuy.Date} Cena: {priceWhenBuy.Price}\n ");
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();

            List<GoldPrice> pricesBest = (from price in prices
                                          where 5 < 100 * (priceWhenBuy.Price - price.Price) / price.Price
                                          select price).ToList();
            return pricesBest;

        }

        public List<GoldPrice> FindTop3LowestPrice(GoldClient goldenClient, int howMany, DateTime date1, DateTime date2)
        {

           // DateTime date1 = new DateTime(2021, 1, 1);
           // DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
       
            List<GoldPrice> pricesTop3 = prices.OrderBy(n => n.Price).Take(3).ToList();
            return pricesTop3;
            //  Console.WriteLine(pricesTop3.ToString());



        }

        public List<GoldPrice> FindTop3HighestPrice(GoldClient goldenClient, int howMany, DateTime date1, DateTime date2)
        {

           // DateTime date1 = new DateTime(2021, 1, 1);
           // DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
        
            List<GoldPrice> pricesTop3 = prices.OrderByDescending(n => n.Price).Take(3).ToList();

            return pricesTop3;

        }

        public List<GoldPrice> FindTop3HighestPriceQuery(GoldClient goldenClient, int howMany, DateTime date1, DateTime date2)
        {

           // DateTime date1 = new DateTime(2021, 1, 1);
           // DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
        
            List<GoldPrice> pricesTop3 = (from price in prices
                                          orderby price.Price descending
                                          select price).Take(3).ToList();

            return pricesTop3;



        }

        public List<GoldPrice> FindTop3LowestPriceQuery(GoldClient goldenClient, int howMany, DateTime date1, DateTime date2)
        {

           // DateTime date1 = new DateTime(2021, 1, 1);
           // DateTime date2 = new DateTime(2021, 12, 31);
            List<GoldPrice> prices = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
           
            List<GoldPrice> pricesTop3 = (from price in prices
                                          orderby price.Price
                                          select price).Take(howMany).ToList();

            return pricesTop3;


        }

        public Dictionary<int, double> AveragePrice(GoldClient goldenClient)
        {
            DateTime date1 = new DateTime(2019, 1, 1);
            DateTime date2 = new DateTime(2019, 12, 31);
            var result = new Dictionary<int, double>();
            for (int i = 0; i < 3; i++)
            {
                List<GoldPrice> pricesAll = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
                var avarage = pricesAll.Average(n => n.Price);
                result[date1.Year] = avarage;
                date1 = date1.AddYears(1);
                date2 = date1.AddYears(1);
            }
            return result;
        }

        public static void AveragePriceQuery(GoldClient goldenClient)
        {
            //Dictionary<int, double>
            DateTime date1 = new DateTime(2019, 1, 1);
            DateTime date2 = new DateTime(2019, 12, 31);
            var result = new Dictionary<int, double>();
            for (int i = 0; i < 3; i++)
            {
                List<GoldPrice> pricesAll = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
                var avarage = pricesAll.Average(n => n.Price);
              
                result[date1.Year] = avarage;
                date1 = date1.AddYears(1);
                date2 = date1.AddYears(1);
            }
            // return result;
        }
        
       
        public double Invest(GoldClient goldenClient)
        {
            DateTime date1 = new DateTime(2019, 1, 1);
            DateTime date2 = new DateTime(2019, 12, 31);
            GoldApp goldApp = new GoldApp();
            var pricesLowList = new List<GoldPrice>();
            var pricesHighList = new List<GoldPrice>();
            var result = new Dictionary<string, string>();
            for (int i = 0; i < 3; i++)
            {
                GoldPrice pricesHigh = goldApp.FindTop3HighestPrice(goldenClient, 1, date1, date2)[0];
                pricesHighList.Add(pricesHigh);
                GoldPrice pricesLow = goldApp.FindTop3LowestPrice(goldenClient, 1, date1, date2)[0];
                pricesLowList.Add(pricesLow);
            
                date1 = date1.AddYears(1);
                date2 = date1.AddYears(1);
            }
            DateTime date2022 = new DateTime(2022, 1, 1);
            GoldPrice pricesHighNow = goldApp.FindTop3HighestPrice(goldenClient, 1, date2022, DateTime.Today)[0];
            pricesHighList.Add(pricesHighNow);
            GoldPrice pricesLowNow = goldApp.FindTop3LowestPrice(goldenClient, 1, date1, DateTime.Today)[0];
            pricesLowList.Add(pricesHighNow);
            var sell = pricesHighList.MaxBy(n => n.Price);
           result["sell"] = $"{sell.Date}: {sell.Price}";
            var buy = pricesLowList.MinBy(n => n.Price);
            result["buy"] = $"{buy.Date}: {buy.Price}";
            result["investment"] = $"{(sell.Price - buy.Price)/ buy.Price * 100}%";
         
            return (sell.Price - buy.Price) / buy.Price * 100;
        }

        public double InvestQuery(GoldClient goldenClient)
        {
            DateTime date1 = new DateTime(2019, 1, 1);
            DateTime date2 = new DateTime(2019, 12, 31);
            GoldApp goldApp = new GoldApp();
            var pricesLowList = new List<GoldPrice>();
            var pricesHighList = new List<GoldPrice>();
            var result = new Dictionary<string, string>();
            for (int i = 0; i < 3; i++)
            {
                GoldPrice pricesHigh = goldApp.FindTop3HighestPriceQuery(goldenClient, 1, date1, date2)[0];
                pricesHighList.Add(pricesHigh);
                GoldPrice pricesLow = goldApp.FindTop3LowestPriceQuery(goldenClient, 1, date1, date2)[0];
                pricesLowList.Add(pricesLow);
              
                date1 = date1.AddYears(1);
                date2 = date1.AddYears(1);
            }
            DateTime date2022 = new DateTime(2022, 1, 1);
            GoldPrice pricesHighNow = goldApp.FindTop3HighestPriceQuery(goldenClient, 1, date2022, DateTime.Today)[0];
            pricesHighList.Add(pricesHighNow);
            GoldPrice pricesLowNow = goldApp.FindTop3LowestPriceQuery(goldenClient, 1, date1, DateTime.Today)[0];
            pricesLowList.Add(pricesHighNow);
            var sell = (from price in pricesHighList
             orderby price.Price descending
             select price).Take(1).ToList()[0];
            result["sell"] = $"{sell.Date}: {sell.Price}";
            var buy = (from price in pricesLowList
             orderby price.Price
             select price).Take(1).ToList()[0];
            result["buy"] = $"{buy.Date}: {buy.Price}";
            result["investment"] = $"{(sell.Price - buy.Price) / buy.Price * 100}%";
      
            return (sell.Price - buy.Price) / buy.Price * 100;
        }

        public static void SaveToXML(GoldClient goldenClient , DateTime date1, DateTime date2)
        {
            List<GoldPrice> pricesAll = goldenClient.GetGoldPrices(date1, date2).GetAwaiter().GetResult();
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Pricesrices to XML"),
                new XElement("Prices",
                from price in pricesAll
                select new XElement("GoldPrice", new XAttribute("hash", price.GetHashCode()),
                    new XElement("Price", price.Price),
                    new XElement("Date", price.Date))
                ));
            xmlDocument.Save(@"C:\Users\Agata\ListGoldPrices.xml");
        }

        public static void FromXML()
        {
            IEnumerable<XElement> fromXML = XDocument.Load(@"C:\Users\Agata\ListGoldPrices.xml").Root.Elements();
            foreach (var element in fromXML)
            {
                Console.WriteLine($"{element.Element("Price").Value} {element.Element("Date").Value}");
            }
          
        }
    }
    }
