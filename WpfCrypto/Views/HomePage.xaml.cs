using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfCrypto.Views
{
	/// <summary>
	/// Interaction logic for HomePage.xaml
	/// </summary>
	public partial class HomePage : Page
	{
		string url = "https://api.coingecko.com/api/v3/search/trending";
		HttpClient client = new HttpClient();

		public HomePage()
		{
			InitializeComponent();
			LoadTraidingToken();
		}

		public async Task LoadTraidingToken()
		{
			try
			{
				var httpResponseMeessage = await client.GetAsync(url);
				string jsonResponse = await httpResponseMeessage.Content.ReadAsStringAsync();

				RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsonResponse);

				foreach (var coin in obj.coins)
				{
					dataGridView1.Items.Add(coin.item);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DataGrid grid = (DataGrid)sender;
			Item selectedItem = (Item)grid.SelectedItem;

			GetToken key = new GetToken();
			key.SetKey(selectedItem.symbol);

			DetailsInfoToken detailinfo = new DetailsInfoToken();
			this.NavigationService.Navigate(detailinfo);
		}

		private void Button_ClickAsync(object sender, System.Windows.RoutedEventArgs e)
		{
			var SerachToken = SeachInput.Text;

			GetToken key = new GetToken();
			key.SetKey(SerachToken);

			DetailsInfoToken detailinfo = new DetailsInfoToken();
			NavigationService.Navigate(detailinfo);
		}


	}
}
