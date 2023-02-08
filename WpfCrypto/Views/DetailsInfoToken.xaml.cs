using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCrypto.Models;
using WpfCrypto.VirtualBD;



namespace WpfCrypto.Views
{
	/// <summary>
	/// Interaction logic for DetailsInfoToken.xaml
	/// </summary>
	public partial class DetailsInfoToken : Page
	{
		DB connectionDB = new DB();
		LoginedHuman logined = new LoginedHuman();
		HttpClient client = new HttpClient();
		
		public DetailsInfoToken()
		{
			InitializeComponent();
			LoadTraidingToken();
		}

		public async Task LoadTraidingToken()
		{
			GetToken tokenName = new GetToken();
			string url = "https://cryptingup.com/api/assets/" + tokenName.GetKey();
			
			try
			{
				var httpResponseMeessage = await client.GetAsync(url);
				string jsonResponse = await httpResponseMeessage.Content.ReadAsStringAsync();

				string json = jsonResponse;
				Root root = JsonConvert.DeserializeObject<Root>(json);

				if (root.asset.name == "")
				{
					PriceLableText.Content = "Price" + "(" + root.asset.asset_id + ")";
				}
				else
				{
					PriceLableText.Content = root.asset.name +  " Price " + "(" + root.asset.asset_id + ")";
				}
				
				if (root.asset.name == "")
				{
					root.asset.name = "No info Name";
					errorLable.Content = "We have little information about this menetto, try a more popular one";
				}

				NameLable.Content = root.asset.name;
				symbolLable.Content = root.asset.asset_id;
				dataGridView1.Items.Add(root.asset);
				PriceLable.Content = "$" + Math.Round(root.asset.price, 2);

				PrintBalance();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}


		public void PrintBalance()
		{
			string tokenName;
			for (int i = 0; i < DB.People.Count; i++)
			{
				if (connectionDB.GetHumans(i).GetName() == logined.GetName() && connectionDB.GetHumans(i).GetLastName() == logined.GetLastName())
				{
					var coins = new List<CoinsWallet>(connectionDB.GetHumans(i).GetCoins());
					for (int j = 0; j < coins.Count; j++)
					{
						tokenName = coins[j].name;
						if (tokenName == "USDT")
						{
							BalanceLable.Content = "Your Balance: " + coins[j].sum + " USDT";
						}
						
					}

				}
			}
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			

			if (logined.GetName() == null)
			{
				LoginandRegit loginandRegit = new LoginandRegit();
				NavigationService.Navigate(loginandRegit);
			}
			else
			{
				CoinsWallet buyToken;
			
				double result;
				string tokenName = symbolLable.Content.ToString();
				double sizeBuy = Convert.ToDouble(HowBuy.Text.ToString());

				string url = "https://cryptingup.com/api/assets/" + tokenName;

				var httpResponseMeessage = await client.GetAsync(url);
				string jsonResponse = await httpResponseMeessage.Content.ReadAsStringAsync();

				string json = jsonResponse;
				Root root = JsonConvert.DeserializeObject<Root>(json);

					for (int i = 0; i < DB.People.Count; i++)
					{
						if (connectionDB.GetHumans(i).GetName() == logined.GetName() && connectionDB.GetHumans(i).GetLastName() == logined.GetLastName())
						{
							var coins = new List<CoinsWallet>(connectionDB.GetHumans(i).GetCoins());
							for (int j = 0; j < coins.Count; j++)
							{
								tokenName = coins[j].name;
								if (tokenName == "USDT")
								{
									result = coins[j].sum - (root.asset.price * sizeBuy);
									if (result > 0)
									{
										coins[j].sum = result;
										connectionDB.GetHumans(i).AddCoins(new CoinsWallet(root.asset.asset_id, sizeBuy, (root.asset.price * sizeBuy)));
									}
									else
									{
										errorLable.Content = "You don't have money for buy size";
									}
								}
								break;

							}

						}

					}

				}

		}
	}
	
}