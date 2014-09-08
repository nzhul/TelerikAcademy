namespace Cars.XMLSearcher
{
    using Cars.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    class Program
    {
        static void Main()
        {
            // This is quite a mess. It is not working properly.
            // It was too hard for me to solve this problem.
            // :(

            var db = new CarsDbContext();
            
            var xmlQueries = XElement.Load("../../../../QueriesData/queries.xml").Elements();
            var result = new XElement("search-results");

            foreach (var xmlQuery in xmlQueries)
            {
                var queryInCars = db.Cars.AsQueryable();

                var queryNodes = xmlQuery.Nodes();
                foreach (XElement node in queryNodes)
                {
                    Console.WriteLine(node.Name);
                    if (node.Name == "OrderBy")
                    {
                        string idValue = node.Value;
                        queryInCars = queryInCars.OrderBy(c => c.Id);
                    }

                    if (node.Name == "WhereClauses")
                    {
                        var allWhereClauses = node.Elements();
                        foreach (var whereClauseNode in allWhereClauses)
                        {
                            string PropertyName = whereClauseNode.Attribute("PropertyName").Value;
                            string CompareBy = whereClauseNode.Attribute("Type").Value;

                            if (PropertyName == "Year")
                            {
                                if (CompareBy == "GreaterThan")
                                {
                                    queryInCars.Where(c => c.Year > int.Parse(whereClauseNode.Value));
                                }
                                else if (CompareBy == "Equals")
                                {
                                    queryInCars.Where(c => c.Year == int.Parse(whereClauseNode.Value));
                                }
                            }
                            else if (PropertyName == "City")
                            {
                                if (CompareBy == "Equals")
                                {
                                    queryInCars.Where(c => c.Dealer.Cities.FirstOrDefault().Name == whereClauseNode.Value);
                                }
                            }
                        }
                    }
                }
                var resultSet = queryInCars
                .Select(c => new
                {
                Model = c.Model,
                TransmisionType = c.TransmisionType,
                Year = c.Year,
                Price = c.Price
                }).ToList();

                var xmlResultSet = new XElement("result-set");

                foreach (var carInResult in resultSet)
                {
                    var xmlReview = new XElement("Car");
                    xmlReview.Add(new XElement("Model", carInResult.Model));
                    xmlReview.Add(new XElement("TransmisionType", carInResult.TransmisionType));
                    xmlReview.Add(new XElement("Year", carInResult.Year));
                    xmlReview.Add(new XElement("Price", carInResult.Price));

                    xmlResultSet.Add(xmlReview);
                }

                result.Add(xmlResultSet);
            }

            result.Save("../../../../reviews-search-results.xml");
        }
    }
}
