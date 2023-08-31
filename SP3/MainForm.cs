using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls.WebParts;
using static SP3.Models.Instrument;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading;

namespace SP3
{
    public partial class MainForm : Form
    {
		private RestClient restClient = new RestClient();
        private string accessTokenUrl = "https://api.tdameritrade.com/v1/oauth2/token";
        private string ClientId = "YEWS0GKZUU6E5Q7NPXFB21UWXWMZGJGY";
		private string AccessToken;
		private string RefreshToken;

        Microsoft.Extensions.Logging.ILogger logProvider;

		public MainForm()
        {
            InitializeComponent();
            //var loggerFactory = new LoggerFactory();
            //var loggerConfig = new LoggerConfiguration()
            //                        .WriteTo.Console()
             //                       .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
             //                       .CreateLogger();
            //loggerFactory.AddSerilog(loggerConfig);

            //logProvider = loggerFactory.CreateLogger<MainForm>();
            //logProvider.LogInformation("Logger created");
        }

  //      private void Submit_Click(object sender, EventArgs e)
  //      {
		//	var input = textBox1.Text.ToUpperInvariant();
		//	GetQuote(input);
		//}

		private Quote GetQuote(string input)
        {
            logProvider.LogInformation($"Getting quote for {input}");
            var getQuoteUrl = $"https://api.tdameritrade.com/v1/marketdata/{input}/quotes";
			var request = FormRequest(Method.Get, getQuoteUrl);
			var result = ExecuteRequest(request);
			var temp = result.Content.Substring(result.Content.IndexOf(':') + 1);
			var temp2 = temp.Substring(0, temp.Length - 1);
			Quote quote = JsonConvert.DeserializeObject<Quote>(temp2);
            logProvider.LogInformation($"Quote for {input} : {temp2}");
			return quote;
		}

        private void GetOptionChain(string symbol, string strikePrice, string expDate, string contractType)
        {
            var exdate = DateTime.Parse(expDate).ToString("yyyy-MM-dd");
            logProvider.LogInformation($"Getting option chain for {symbol}");
            var getOptionChaiUrl = $"https://api.tdameritrade.com/v1/marketdata/chains?apikey=YEWS0GKZUU6E5Q7NPXFB21UWXWMZGJGY&symbol={symbol}&strike={strikePrice}&fromDate={exdate}&toDate={exdate}&contractType={contractType}";
            var request = FormRequest(Method.Get, getOptionChaiUrl);
            var result = ExecuteRequest(request);
            var temp = result.Content.Substring(result.Content.IndexOf(':') + 1);
            var temp2 = temp.Substring(0, temp.Length - 1);

            result.Content.ToList();

            var res = result.Content.Substring(result.Content.IndexOf("putCall")-3);
            var res1 = res.Substring(0, res.IndexOf("}") + 2);

            var optionChain = JsonConvert.DeserializeObject<DataTable>(res1);

            var src = TransposeDataTable(optionChain);

            dataGridView1.DataSource = src;
        }
		private void Decipher_Click(object sender, EventArgs e)
		{
            RefreshToken = LoadRefreshToken();
            var resp = RefreshAccessToken();
            var tokens = JsonConvert.DeserializeObject<TokenResponse>(resp.Content);
            AccessToken = tokens.AccessToken;
            Resource1.AccessToken = tokens.AccessToken;
            try
            {
                var parts = messageText.Text.Split(' ');
                if (parts.Length == 5)
                {
                    ExpiryDate.Text = DateTime.Parse(parts[0]).ToShortDateString();
                    TickerSymbol.Text = parts[1].ToUpperInvariant();
                    StrikePrice.Text = parts[2].Substring(0, parts[2].Length - 1);
                    if (parts[2].EndsWith("c"))
                    {
                        orderType.Text = "C";
                    }
                    else
                    {
                        orderType.Text = "P";
                    }
                    alertPrice.Value = decimal.Parse(parts[4]);
                    upperLimit.Value = alertPrice.Value + (alertPrice.Value / 4);
                    lowerLimit.Value = alertPrice.Value - decimal.Divide(alertPrice.Value, decimal.Parse("3.33"));

                    numberOfContracts.Value = GetNumberOfContracts(alertPrice.Value);


                }
                else if (parts.Length == 4)
                {
                    ExpiryDate.Text = DateTime.Parse(parts[0]).ToShortDateString();
                    TickerSymbol.Text = parts[1].ToUpperInvariant();
                    StrikePrice.Text = parts[2].Substring(0, parts[2].Length - 1);
                    if (parts[2].EndsWith("c"))
                    {
                        orderType.Text = "C";
                    }
                    else
                    {
                        orderType.Text = "P";
                    }
                    alertPrice.Value = decimal.Parse(parts[3]);
                    upperLimit.Value = alertPrice.Value + (alertPrice.Value / 4);
                    lowerLimit.Value = alertPrice.Value - decimal.Divide(alertPrice.Value, decimal.Parse("3.33"));

                    numberOfContracts.Value = GetNumberOfContracts(alertPrice.Value);
                }
                else if (parts.Length == 3)
                {
                    var date = DateTime.Now.ToLongDateString();

                    // Find the next Friday.
                    // Get the number of days between the_date's
                    // day of the week and Friday.
                    int num_days = System.DayOfWeek.Friday - DateTime.Now.DayOfWeek;
                    if (num_days < 0) num_days += 7;

                    // Add the needed number of days.
                    DateTime friday = DateTime.Now.AddDays(num_days);

                    // Display the result.
                    ExpiryDate.Text = friday.ToShortDateString();

                    TickerSymbol.Text = parts[0].ToUpperInvariant();
                    StrikePrice.Text = parts[1].Substring(0, parts[1].Length - 1);
                    if (parts[1].EndsWith("c"))
                    {
                        orderType.Text = "C";
                    }
                    else
                    {
                        orderType.Text = "P";
                    }
                    alertPrice.Value = decimal.Parse(parts[2]);
                    upperLimit.Value = alertPrice.Value + (alertPrice.Value / 4);
                    lowerLimit.Value = alertPrice.Value - decimal.Divide(alertPrice.Value, decimal.Parse("3.33"));

                    numberOfContracts.Value = GetNumberOfContracts(alertPrice.Value);
                }
                else
                {
                    logProvider.LogWarning($"Could not decipher. Please check the input text: {messageText.Text}");
                }
            }
            catch (Exception ex)
            {
                logProvider.LogError($"Failed to decipher input text. Error: {ex.Message}, {ex.InnerException}");
            }

            GetOptionChain(TickerSymbol.Text, StrikePrice.Text, ExpiryDate.Text, orderType.Text == "C" ? "CALL" : "PUT");
            //int i = 1;
            //while (i < 10)
            //{
            //    Decipher_Click(sender, e);
            //    i++;
            //    //GetOptionChain(TickerSymbol.Text, StrikePrice.Text, ExpiryDate.Text, orderType.Text == "C" ? "CALL" : "PUT");
            //    //logProvider.LogInformation($"Fetching option chain for {TickerSymbol.Text}");
            //    //Thread.Sleep(1000);
            //    //i++;
            //}           

            
            //var table = JsonConvert.DeserializeObject<DataTable>("json");

            //dataGridView1.DataSource = table;
		}

        private int GetNumberOfContracts(decimal value)
        {
            return (int)Math.Floor(decimal.Divide(decimal.Parse("4.5"), value));
        }

        /// <summary>
        /// Creates a new DataTable with row count = column count of original table
        ///  and column count = row count of original table. 
        /// </summary>
        /// <param name="dt">Original DataTable to transpose</param>
        /// <returns>A transposed DataTable</returns>
        public DataTable TransposeDataTable(DataTable dt)
        {
            DataTable transposedTable = new DataTable();

            DataColumn firstColumn = new DataColumn(dt.Columns[0].ColumnName);
            transposedTable.Columns.Add(firstColumn);

            //Add a column for each row in first data table
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataColumn dc = new DataColumn(dt.Rows[i][0].ToString());
                transposedTable.Columns.Add(dc);
            }

            for (int j = 1; j < dt.Columns.Count; j++)
            {
                DataRow dr = transposedTable.NewRow();
                dr[0] = dt.Columns[j].ColumnName;

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    dr[k + 1] = dt.Rows[k][j];
                }

                transposedTable.Rows.Add(dr);
            }

            return transposedTable;
        }

        private void Buy_Click(object sender, EventArgs e)
		{
            RefreshToken = LoadRefreshToken();
            var resp = RefreshAccessToken();
            var tokens = JsonConvert.DeserializeObject<TokenResponse>(resp.Content);
            AccessToken = tokens.AccessToken;
            Resource1.AccessToken = tokens.AccessToken;
            var quote = GetQuote(TickerSymbol.Text.ToUpperInvariant());

            var d = DateTime.Parse(ExpiryDate.Text).ToString("MMddyy");

            var x = $"{quote.Symbol}_{d}{orderType.Text}{StrikePrice.Text}";

            OptionInstrument instrument = new OptionInstrument()
            {
                Symbol = x,
                AssetType = "OPTION"
            };
            
            OptionOrderLegCollection[] orderLegCollections = new OptionOrderLegCollection[1];
            //working stock orderlegcollection
            OptionOrderLegCollection orderLegCollection = new OptionOrderLegCollection()
            {
                Instrument = instrument,
                Instruction = "BUY_TO_OPEN",
                Quantity = 1
            };
            orderLegCollections[0] = orderLegCollection;
            
            OptionOrder order = new OptionOrder()
            {
                Session = "NORMAL",
                Duration = "DAY",
                OrderType = "LIMIT",
                ComplexOrderStrategyType = "NONE",
                Price = alertPrice.Value,
                OrderLegCollection = orderLegCollections,
                OrderStrategyType = "SINGLE"
            };
            var request = FormRequest(Method.Post, "https://api.tdameritrade.com/v1/accounts/498708818/orders");
            var json = JsonConvert.SerializeObject(order);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            //request.AddJsonBody(order);
            try
            {
                var response = ExecuteRequest(request);
            }
            catch (Exception ex)
            {
                logProvider.LogError($"Failed to execute request: {ex.Message} Order request: {request.Parameters}, {json}");
            }
        }

        private void buyStopLimit_Click(object sender, EventArgs e)
        {
            RefreshToken = LoadRefreshToken();
            var resp = RefreshAccessToken();
            var tokens = JsonConvert.DeserializeObject<TokenResponse>(resp.Content);
            AccessToken = tokens.AccessToken;
            Resource1.AccessToken = tokens.AccessToken;
            var quote = GetQuote(TickerSymbol.Text.ToUpperInvariant());

            var d = DateTime.Parse(ExpiryDate.Text).ToString("MMddyy");

            var x = $"{quote.Symbol}_{d}{orderType.Text}{StrikePrice.Text}";

            OptionInstrument instrument = new OptionInstrument()
            {
                Symbol = x,
                AssetType = "OPTION"
            };
            
            OptionOrderLegCollection[] orderLegCollections = new OptionOrderLegCollection[1];
            //working stock orderlegcollection
            OptionOrderLegCollection orderLegCollection = new OptionOrderLegCollection()
            {
                Instrument = instrument,
                Instruction = "BUY_TO_OPEN",
                Quantity = (long)numberOfContracts.Value
                //Quantity = (long)numberOfContracts.Value
            };
            orderLegCollections[0] = orderLegCollection;

            OrderLegCollection[] childOrderLegCollection = new OrderLegCollection[1];
            OrderLegCollection orderLegCollection1 = new OrderLegCollection()
            {
                Instruction = "SELL_TO_CLOSE",
                Quantity = (long)numberOfContracts.Value,
                Instrument = instrument
            };
            childOrderLegCollection[0] = orderLegCollection1;

            ChildOrderStrategy[] childOrderStrategiees = new ChildOrderStrategy[2];
            childOrderStrategiees[0] = new ChildOrderStrategy()
            {
                OrderStrategyType = "SINGLE",
                Session = "NORMAL",
                Duration = "GOOD_TILL_CANCEL",
                OrderType = "MARKET",
                Price = double.Parse(upperLimit.Text),
                OrderLegCollection = childOrderLegCollection
            };
            childOrderStrategiees[1] = new ChildOrderStrategy()
            {
                OrderStrategyType = "SINGLE",
                Session = "NORMAL",
                Duration = "GOOD_TILL_CANCEL",
                OrderType = "STOP",
                Price = double.Parse(lowerLimit.Text),
                StopPrice = double.Parse(lowerLimit.Text),
                OrderLegCollection = childOrderLegCollection
            };


            ChildOrderStrategies[] childOrderStrategies = new ChildOrderStrategies[1];
            ChildOrderStrategies childOrderStrategies1 = new ChildOrderStrategies()
            {
                OrderStrategyType = "OCO",
                ChildOrderStrategiees = childOrderStrategiees
            };
            childOrderStrategies[0] = childOrderStrategies1;

            OptionOrder order = new OptionOrder()
            {
                Session = "NORMAL",
                Duration = "DAY",
                OrderType = "LIMIT",
                Price = alertPrice.Value,
                OrderLegCollection = orderLegCollections,
                OrderStrategyType = "TRIGGER",
                ChildOrderStrategies = childOrderStrategies
            };
            var request = FormRequest(Method.Post, "https://api.tdameritrade.com/v1/accounts/498708818/orders");
            var json = JsonConvert.SerializeObject(order);
            logProvider.LogInformation($"Order built for {order.OrderLegCollection[0].Instrument.Symbol}: {json}");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            //request.AddJsonBody(order);
            try
            {
                var response = ExecuteRequest(request);
                logProvider.LogInformation($"Request Executed. Response: {response.StatusCode} {response.Content}");
            }
            catch (Exception ex)
            {
                logProvider.LogError($"Error executing request. Error: {ex.Message}. {ex.InnerException}");
            }
        }
        private void buyStock_Click(object sender, EventArgs e)
        {
            RefreshToken = LoadRefreshToken();
            var resp = RefreshAccessToken();
            var tokens = JsonConvert.DeserializeObject<TokenResponse>(resp.Content);
            AccessToken = tokens.AccessToken;
            Resource1.AccessToken = tokens.AccessToken;
            var quote = GetQuote(TickerSymbol.Text.ToUpperInvariant());
            //working stock instrument
            ShortInstrument instrument = new ShortInstrument()
            {
                Symbol = quote.Symbol,
                AssetType = "EQUITY"
            };

            //ShortInstrument instrument = new ShortInstrument()
            //{
            //    Symbol = quote.Symbol,
            //    AssetType = "OPTION"
            //};


            ShortOrderLegCollection[] orderLegCollections = new ShortOrderLegCollection[1];
            //working stock orderlegcollection
            ShortOrderLegCollection orderLegCollection = new ShortOrderLegCollection()
            {
                //LegId = 0,
                Instrument = instrument,
                Instruction = "BUY",
                Quantity = 1
            };
            //ShortOrderLegCollection orderLegCollection = new ShortOrderLegCollection()
            //{
            //    Instruction = "BUY_TO_OPEN",
            //    Instrument = instrument,
            //    Quantity = 1
            //};
            orderLegCollections[0] = orderLegCollection;
            
            ShortOrder order = new ShortOrder()
            {
                Session = "SEAMLESS",
                Duration = "GOOD_TILL_CANCEL",
                OrderType = "LIMIT",
                ComplexOrderStrategyType = "NONE",
                Price = alertPrice.Value,
                OrderLegCollection = orderLegCollections,
                OrderStrategyType = "SINGLE"
            };
            var request = FormRequest(Method.Post, "https://api.tdameritrade.com/v1/accounts/498708818/orders");
            var json = JsonConvert.SerializeObject(order);

            request.AddParameter("application/json",json, ParameterType.RequestBody);
            //request.AddJsonBody(order);
            try
            {
                var response = ExecuteRequest(request);
            }
            catch (Exception ex)
            {
                logProvider.LogError($"Failed to execute request: {ex.Message}. Order request: {request.Parameters}, {json}");
            }
        }
        private void buyStockStopLimit_Click(object sender, EventArgs e)
        {
            RefreshToken = LoadRefreshToken();
            var resp = RefreshAccessToken();
            var tokens = JsonConvert.DeserializeObject<TokenResponse>(resp.Content);
            AccessToken = tokens.AccessToken;
            Resource1.AccessToken = tokens.AccessToken;
            var quote = GetQuote(TickerSymbol.Text.ToUpperInvariant());

            var d = DateTime.Parse(ExpiryDate.Text).ToString("MMddyy");
            if (orderType.Text.StartsWith("C"))
            {

            }
            //var x = $"{quote.Symbol}_{d}{orderType.Text}{StrikePrice.Text}";

            OptionInstrument instrument = new OptionInstrument()
            {
                Symbol = quote.Symbol,
                AssetType = "EQUITY"
            };

            OptionOrderLegCollection[] orderLegCollections = new OptionOrderLegCollection[1];
            //working stock orderlegcollection
            OptionOrderLegCollection orderLegCollection = new OptionOrderLegCollection()
            {
                Instrument = instrument,
                Instruction = "BUY_TO_OPEN",
                Quantity = (long)numberOfContracts.Value
            };
            orderLegCollections[0] = orderLegCollection;

            OrderLegCollection[] childOrderLegCollection = new OrderLegCollection[1];
            OrderLegCollection orderLegCollection1 = new OrderLegCollection()
            {
                Instruction = "SELL_TO_CLOSE",
                Quantity = (long)numberOfContracts.Value,
                Instrument = instrument
            };
            childOrderLegCollection[0] = orderLegCollection1;

            ChildOrderStrategy[] childOrderStrategiees = new ChildOrderStrategy[2];
            childOrderStrategiees[0] = new ChildOrderStrategy()
            {
                OrderStrategyType = "SINGLE",
                Session = "NORMAL",
                Duration = "GOOD_TILL_CANCEL",
                OrderType = "LIMIT",
                Price = double.Parse(upperLimit.Text),
                OrderLegCollection = childOrderLegCollection
            };
            childOrderStrategiees[1] = new ChildOrderStrategy()
            {
                OrderStrategyType = "SINGLE",
                Session = "NORMAL",
                Duration = "GOOD_TILL_CANCEL",
                OrderType = "STOP_LIMIT",
                StopPrice = double.Parse(lowerLimit.Text),
                OrderLegCollection = childOrderLegCollection
            };


            ChildOrderStrategies[] childOrderStrategies = new ChildOrderStrategies[1];
            ChildOrderStrategies childOrderStrategies1 = new ChildOrderStrategies()
            {
                OrderStrategyType = "OCO",
                ChildOrderStrategiees = childOrderStrategiees
            };
            childOrderStrategies[0] = childOrderStrategies1;

            OptionOrder order = new OptionOrder()
            {
                Session = "NORMAL",
                Duration = "DAY",
                OrderType = "LIMIT",
                Price = alertPrice.Value,
                OrderLegCollection = orderLegCollections,
                OrderStrategyType = "TRIGGER",
                ChildOrderStrategies = childOrderStrategies
            };
            var request = FormRequest(Method.Post, "https://api.tdameritrade.com/v1/accounts/498708818/orders");
            var json = JsonConvert.SerializeObject(order);

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            //request.AddJsonBody(order);
            try
            {
                var response = ExecuteRequest(request);
            }
            catch (Exception ex)
            {
                logProvider.LogError($"Failed to execute request: {ex.Message} Order request: {request.Parameters}, {json}");
            }
        }


        private string LoadAccessToken()
        {
            string path = @"C:\Users\Ashley Moura\Documents\Vish\SP3\Tokens\Token.txt";
            if (File.Exists(path))
            {
                return File.ReadLines(path).ElementAtOrDefault(0);
            }
            else
            {
                return null;
            }
        }

        private string LoadRefreshToken()
        {
            return Resource1.RefreshToken;
        }

        private void SaveAccessTokenAndRefreshToken(string accessToken, string refreshToken)
        {
            string path = @"C:\Users\Ashley Moura\Documents\Vish\SP3\Tokens\Token.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.Create(path).Dispose();
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(accessToken);
                tw.WriteLine(refreshToken);
            }
        }

        //----------Utility Methods----------

        //private IRestResponse GetAccessToken()
        //{
        //    RestRequest request = new RestRequest(accessTokenUrl, Method.POST);
        //    request.AddParameter("grant_type", "authorization_code");
        //    request.AddParameter("client_id", ClientId);
        //    request.AddParameter("client_secret", ClientSecret);
        //    request.AddParameter("code", AuthorizationCode);
        //    request.AddParameter("redirect_uri", redirectUri);
        //    return restClient.Execute(request);
        //}

        private RestResponse RefreshAccessToken()
        {
            RestRequest request = new RestRequest(accessTokenUrl, Method.Post);
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("client_id", ClientId);
            request.AddParameter("refresh_token", RefreshToken);
            return restClient.Execute(request);
        }
        private RestRequest FormRequest(Method rtype, string data)
        {
            var request = new RestRequest(data, rtype);
            request.AddHeader("Accept", "application/json");

            return request;
        }
        private RestResponse ExecuteRequest(RestRequest request)
        {
            //AccessToken = Resource1.AccessToken;
            //AccessToken = "ZAzgGJh1h4hqNwNopM6NO26GozN9iDGRxYOzaGsKi5uOZcggpLhEPpF6su118CQM4K/pqaGRwpfRBCceBjuSB4Ljqh1sa8oSD2utP0qF2ZhQ+Bqr20jZ8/KDT8kn88KnoQu3m0tKNDygZRxi8y65Yaf/nvQM0pGmm2JCiFE2hVEA81ElTJTX3+WHSTSSC+D2c4fXsgQTAasdaGPX32ZMkS1+oroqFzSRdJPHPJaXb/W30NlNBTixUNWoRG4hi9Y/wnq03TzJroVp6pJ8TmKlGwivYkzzejOnb+lBnC0Ao+1bgZ9cQvwp7vWTTKKQu3dTFXzIE2COG5UL8LuwlPLmrkK91VyitIT5YDAj9S++dnsFfZS8MXG3AHMu40Lvb7L0zDRWJ/GEaO6J8Q28JmWScT2Hvlc2x/DqflCAyUD0RdnvoZMIbXIS+VrZ4Bkg5GHIeE2Pqv07Zm5UDRL5zzoHvGSth1o6BbO/7KDT7piuVW685toZT3KfhSZ1VWfLG/IEqpK+0euh4PFJKm508T3q1VZNpKXkUlfiFgz37Zk5oKsJLBeBZ9ZJM6Kc7ZB100MQuG4LYrgoVi/JHHvlGlKllQ5iGYCBqhVM5Ddco5oL0VU+RxUj7JUMdZxf7/k+ZoEgwMcDmrjaXVguP5EHYznzoMDuvGyzZIV9zAPt/Pcakgn+FmJnqEEbfJtiRF0WjOD+RqMVzEnQroK+bvpr8/adZbdM42lSiUcCnyQJuzZ2tO6shR/MF3s5XZFMs61m6icZlkEt/JZki+CeY9SywalWZqzzyP9VgRFDYlFlez7G2WQgEj4+KEb3E2plX3rcGVCwJNSANyqgtOqGosfDB+PODcYaJ6Eg0PZ7wAXAN01KpEwgxXsDqD2noxoNDTamChKFJCTPWMd/KajkFgx/hINl2fNLLQ3hd2qHq90XiFlp4NRLcgB1NND9xHeqUZJU7DX6MsYrn+fmBs9SkKaqvIqB6R0tcmfHiBSxmkdMus+/svNbR+i1lXdSPSBXYZPHSBXZpokmmHLGQICAIurFcXVVwMDwkSRI3OAGPR4CTAugN7R/aCS7fpCZG/tJrvG8EHaFw1R5WbWrTKYqYqEJsJBnOgAtCoe4TlmkHIQN/MBzTMYU5ZYes+FJFSPh0lTR1zOGM0gdFr8TADU=212FD3x19z9sWBHDJACbC00B75E";
            if (request.Timeout == 0)
            {
                request.Timeout = 1000 * 60 * 10;
            }

            request.AddHeader("Authorization", $"Bearer {AccessToken}");
            return restClient.Execute(request);
        }
        private enum RestType
        {
            None,      //none
            Get,      //Rest Get Request
            Post,      //Rest Post Request
            Put,      //Rest Put Request
            Delete,      //Rest Delete Request
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                logProvider.LogInformation("Updating AlertPrice");
                alertPrice.Value = decimal.Parse(dataGridView1.CurrentCell.Value.ToString());
                upperLimit.Value = alertPrice.Value + (alertPrice.Value / 4);
                lowerLimit.Value = alertPrice.Value - decimal.Divide(alertPrice.Value, decimal.Parse("3.33"));
            }
            catch(Exception ex)
            {
                logProvider.LogInformation($"Could not update Alert Price with: {dataGridView1.CurrentCell.Value} Error: {ex.Message} {ex.StackTrace}");
            }
        }
    }
}
