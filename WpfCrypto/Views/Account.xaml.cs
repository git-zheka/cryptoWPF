using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfCrypto.Models;
using WpfCrypto.VirtualBD;

namespace WpfCrypto.Views
{
	public partial class Account : Page
	{
		DB connection = new DB();
		LoginedHuman logined = new LoginedHuman();
		public Account()
		{
			InitializeComponent();
			LoadYourToken();
		}

		public async Task LoadYourToken()
		{
			List<CoinsWallet> coins;
			HttpClient client = new HttpClient();
			string tokenName;
			CoinsWallet token = new CoinsWallet("",0,0);

			

			for (int i = 0; i < DB.People.Count; i++)
			{
				if (connection.GetHumans(i).GetName() == logined.GetName() || connection.GetHumans(i).GetLastName() == logined.GetLastName()) 
				{
					Hello.Content = "Hello " + connection.GetHumans(i).GetName() + " it's your coins";
					coins = new List<CoinsWallet>(connection.GetHumans(i).GetCoins());
					for (int j = 0; j < coins.Count; j++)
					{
						tokenName = coins[j].name;
						string url = "https://cryptingup.com/api/assets/" + tokenName;

						try
						{
							var httpResponseMeessage = await client.GetAsync(url);
							string jsonResponse = await httpResponseMeessage.Content.ReadAsStringAsync();

							string json = jsonResponse;
							Root root = JsonConvert.DeserializeObject<Root>(json);

							token.name = coins[j].name;
							token.dollars = Math.Round(coins[j].sum * root.asset.price,2);
							token.sum = Math.Round(coins[j].sum,2);
							dataGridView1.Items.Add(token);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}

					}
				}
			}
			
		}
	}
}
