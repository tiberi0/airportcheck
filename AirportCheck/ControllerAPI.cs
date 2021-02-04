using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AirportCheck
{
    class ControllerAPI
    {
        //Auxiliar URl's
        private string urlInfoAirport = "https://api.flightradar24.com/common/v1/airport.json?code={0}&plugin[]=details&plugin[]=runways&plugin[]=satelliteImage&plugin[]=scheduledRoutesStatistics&plugin[]=weather&plugin-setting[satelliteImage][scale]=1&token=";
        private string urlArrivalsDepartures = "https://api.flightradar24.com/common/v1/airport.json?code={0}&plugin[]=schedule&plugin-setting[schedule][mode]={1}&plugin-setting[schedule][timestamp]={2}&page=1&limit=15&token=";

        /// <summary>
        /// Consuming web api
        /// </summary>
        /// <param name="url"></param>
        /// <returns>json document</returns>
        public BsonDocument getJsonData(string url)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.104 Safari/537.36");
            client.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            //string code = Properties.Settings.Default.aeroporto;
            //string url = "https://api.flightradar24.com/common/v1/airport.json?code=" + code + "&plugin[]=details&plugin[]=runways&plugin[]=satelliteImage&plugin[]=scheduledRoutesStatistics&plugin[]=weather&plugin-setting[satelliteImage][scale]=1&token=";
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            //Console.WriteLine(s);
            data.Close();
            reader.Close();

            BsonDocument jsonValue = BsonDocument.Parse(s);
            return jsonValue;
        }

        /// <summary>
        /// Get airport information 
        /// </summary>
        /// <returns>{"wind":"", "temperature":"", "conditions": ""}</returns>
        public BsonDocument getAirportInfo()
        {
            BsonDocument doc = new BsonDocument()
            {
                {"wind","" },
                {"temperature","" },
                {"conditions","" },
            };

            try
            {
                string urlTemp = String.Format(urlInfoAirport, Properties.Settings.Default.AirportCode);
                BsonDocument tempInfo = getJsonData(urlTemp);

                if (tempInfo.Contains("result"))
                {
                    var result = tempInfo["result"].AsBsonDocument;
                    if (result.Contains("response"))
                    {
                        var response = result["response"].AsBsonDocument;
                        if (response.Contains("airport"))
                        {
                            var airport = response["airport"].AsBsonDocument;
                            if (airport.Contains("pluginData"))
                            {
                                airport = airport["pluginData"].AsBsonDocument;

                                if (airport.Contains("weather"))
                                {
                                    var weather = airport["weather"].AsBsonDocument;

                                    if (weather.Contains("temp"))
                                    {
                                        int weatherTempValue = weather["temp"].AsBsonDocument["celsius"].AsInt32;
                                        doc["temperature"] = weatherTempValue + "º C";
                                    }

                                    if (weather.Contains("wind"))
                                    {
                                        try
                                        {

                                            int degree = weather["wind"].AsBsonDocument["direction"].AsBsonDocument["degree"].AsInt32;
                                            int speed = weather["wind"].AsBsonDocument["speed"].AsBsonDocument["kts"].AsInt32;
                                            doc["wind"] = degree + "º " + speed + " kts";                                            
                                        }
                                        catch (Exception ae)
                                        {
                                            doc["wind"] = weather["wind"].AsBsonDocument["speed"].AsBsonDocument["text"].AsString;                                            
                                        }
                                    }

                                    if (weather.Contains("sky"))
                                    {
                                        string condText = weather["sky"].AsBsonDocument["condition"].AsBsonDocument["text"].AsString;
                                        doc["condition"] = condText;// conditionTranslate(condText);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception excp)
            {
                doc["message"] = excp.Message;
            }

            return doc;
        }

        /// <summary>
        /// Get last 15 Arrivals and departures
        /// </summary>
        /// <param name="opt"></param>
        /// <returns>Two Arrays : arrivals and departures</returns>
        public BsonDocument getArrivalsDepartures(string opt)
        {
            BsonDocument doc = new BsonDocument()
            {
                {"arrivals",new BsonArray() },
                {"departures",new BsonArray() }
            };

            string timeStamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();

            #region Arrivals
            if (opt == "arrivals")
            {
                string urlArrival = String.Format(urlArrivalsDepartures, Properties.Settings.Default.AirportCode, "arrivals", timeStamp);
                BsonDocument docArrival = getJsonData(urlArrival);
                if (docArrival.Contains("result"))
                {
                    var result = docArrival["result"].AsBsonDocument;
                    if (result.Contains("response"))
                    {
                        var response = result["response"].AsBsonDocument;
                        if (response.Contains("airport"))
                        {
                            var airport = response["airport"].AsBsonDocument;
                            if (airport.Contains("pluginData"))
                            {
                                airport = airport["pluginData"].AsBsonDocument;

                                if (airport.Contains("schedule"))
                                {
                                    var schedule = airport["schedule"].AsBsonDocument;

                                    if (schedule.Contains("arrivals"))
                                    {
                                        var arrivTemp = schedule["arrivals"].AsBsonDocument;

                                        if (arrivTemp.Contains("data"))
                                        {
                                            var listArriv = arrivTemp["data"].AsBsonArray;

                                            //just confirmed airplans
                                            foreach (BsonDocument bb in listArriv)
                                            {
                                                if (bb.Contains("flight"))
                                                {
                                                    if (bb["flight"].AsBsonDocument.Contains("status"))
                                                    {
                                                        var flight = bb["flight"].AsBsonDocument;
                                                        var flightStatus = bb["flight"].AsBsonDocument["status"].AsBsonDocument;
                                                        if (flightStatus.Contains("icon"))
                                                        {                                                            
                                                            if (!flightStatus["icon"].IsBsonNull && flightStatus["icon"].AsString == "green")
                                                            {
                                                                try
                                                                {
                                                                    string identification = "";
                                                                    if (flight.Contains("identification"))
                                                                    {
                                                                        var identAviao = flight["identification"].AsBsonDocument;
                                                                        if (identAviao.Contains("callsign"))
                                                                        {
                                                                            if (identAviao["callsign"].IsBsonNull)
                                                                                identification = flight["identification"].AsBsonDocument["number"].AsBsonDocument["default"].AsString.ToUpper();
                                                                            else
                                                                                identification = flight["identification"].AsBsonDocument["callsign"].AsString.ToUpper();
                                                                        }
                                                                    }
                                                                    string icao1 = flight["airline"].AsBsonDocument["code"].AsBsonDocument["icao"].AsString;
                                                                    BsonDocument docArr = new BsonDocument()
                                                                    {
                                                                        {"status", flight["status"].AsBsonDocument["generic"].AsBsonDocument["status"].AsBsonDocument["text"].AsString},
                                                                        {"identification",identification + " (" + flight["aircraft"].AsBsonDocument["model"].AsBsonDocument["code"].AsString + ")" },
                                                                        {"city",flight["airport"].AsBsonDocument["origin"].AsBsonDocument["position"].AsBsonDocument["region"].AsBsonDocument["city"].AsString },
                                                                        {"hour",UnixTimeStampToDateTime(flight["time"].AsBsonDocument["scheduled"].AsBsonDocument["arrival"].AsInt32) },
                                                                        {"iata","(" + flight["airport"].AsBsonDocument["origin"].AsBsonDocument["code"].AsBsonDocument["iata"].AsString + ")" },
                                                                        {"logo","https://www.flightradar24.com/static/images/data/operators/" + icao1 + "_logo0.png" }
                                                                    };

                                                                    doc["arrivals"].AsBsonArray.Add(docArr);
                                                                }catch(Exception ae)
                                                                {

                                                                }

                                                            }                                                                
                                                        }
                                                    }
                                                }                                                
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }

                }
            }

            #endregion

            #region Departures
            if (opt == "departures")
            {
                string urlDeparture = String.Format(urlArrivalsDepartures, Properties.Settings.Default.AirportCode, "departures", timeStamp);
                BsonDocument docDeparture = getJsonData(urlDeparture);

                if (docDeparture.Contains("result"))
                {
                    var result = docDeparture["result"].AsBsonDocument;
                    if (result.Contains("response"))
                    {
                        var response = result["response"].AsBsonDocument;
                        if (response.Contains("airport"))
                        {
                            var airport = response["airport"].AsBsonDocument;
                            if (airport.Contains("pluginData"))
                            {
                                airport = airport["pluginData"].AsBsonDocument;

                                if (airport.Contains("schedule"))
                                {
                                    var schedule = airport["schedule"].AsBsonDocument;

                                    if (schedule.Contains("departures"))
                                    {
                                        var dptTemp = schedule["departures"].AsBsonDocument;

                                        if (dptTemp.Contains("data"))
                                        {
                                            var listArriv = dptTemp["data"].AsBsonArray;

                                            foreach (var p in listArriv)
                                            {
                                                try {
                                                    if (p["flight"].AsBsonDocument.Contains("status"))
                                                    {
                                                        var flight = p["flight"].AsBsonDocument;
                                                        var flightStatus = p["flight"].AsBsonDocument["status"].AsBsonDocument;
                                                        if (!flightStatus["icon"].IsBsonNull && flightStatus["icon"].AsString == "green")
                                                        {
                                                            if (flightStatus["icon"].AsString == "green")
                                                            {
                                                                string identification = "";
                                                                if (flight.Contains("identification"))
                                                                {
                                                                    var ident = flight["identification"].AsBsonDocument;
                                                                    if (ident.Contains("callsign"))
                                                                    {
                                                                        if (ident["callsign"].IsBsonNull)
                                                                            identification = flight["identification"].AsBsonDocument["number"].AsBsonDocument["default"].AsString.ToUpper();
                                                                        else
                                                                            identification = flight["identification"].AsBsonDocument["callsign"].AsString.ToUpper();
                                                                    }
                                                                }
                                                                string icao1 = flight["airline"].AsBsonDocument["code"].AsBsonDocument["icao"].AsString;
                                                                BsonDocument docDep = new BsonDocument()
                                                                {
                                                                    {"status",flight["status"].AsBsonDocument["generic"].AsBsonDocument["status"].AsBsonDocument["text"].AsString },
                                                                    {"identification",identification + " (" + flight["aircraft"].AsBsonDocument["model"].AsBsonDocument["code"].AsString + ")" },
                                                                    {"hour",UnixTimeStampToDateTime(flight["time"].AsBsonDocument["scheduled"].AsBsonDocument["departure"].AsInt32) },
                                                                    {"city",flight["airport"].AsBsonDocument["destination"].AsBsonDocument["position"].AsBsonDocument["region"].AsBsonDocument["city"].AsString },
                                                                    {"iata","(" + flight["airport"].AsBsonDocument["destination"].AsBsonDocument["code"].AsBsonDocument["iata"].AsString + ")" },
                                                                    {"logo","https://www.flightradar24.com/static/images/data/operators/" + icao1 + "_logo0.png" },
                                                                };
                                                                doc["departures"].AsBsonArray.Add(docDep);
                                                            }
                                                        }
                                                    }
                                                }
                                                catch(Exception ae)
                                                {

                                                }
                                                
                                            }
                                            //departures.renderizarDecolagem(listArriv);
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

            }
            #endregion

            return doc;
        }

        /// <summary>
        /// Auxiliar funciont to translate conditions to portuguese
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public string conditionTranslate(string condition)
        {
            switch (condition)
            {
                case "Clear": condition = "Claro"; break;
                case "Overcast": condition = "Nublado"; break;
                case "Fog": condition = "Névoa"; break;
                case "Cloudy": condition = "Nublado"; break;
                case "Drizzle": condition = "Garoa"; break;
                case "Rain": condition = "Chuva"; break;
                case "Thunderstorm": condition = "Tempestade"; break;
            }
            return condition;
        }

        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.ToShortTimeString();
        }
    }
}
