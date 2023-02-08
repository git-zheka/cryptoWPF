using System.Windows;
using WpfCrypto.Models;
using WpfCrypto.Views;
using WpfCrypto.VirtualBD;

namespace WpfCrypto
{
	
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		DB DBconcection= new DB();
		public MainWindow()
		{
			InitializeComponent();
			HomePage index = new HomePage();
			Main.NavigationService.Navigate(index);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			LoginedHuman loginand = new LoginedHuman();

			if (DB.People.Count == 0 )
			{
				Human testHuman = new Human("a","a",20);
				CoinsWallet testcoin = new CoinsWallet("USDT",1000,1000);
				testHuman.AddCoins(testcoin);
				DBconcection.SetHuman(testHuman);
			}

			if (loginand.GetName() == null)
			{
				LoginandRegit loginRegit = new LoginandRegit();
				Main.NavigationService.Navigate(loginRegit);
			}
			else
			{
				Account account = new Account();
				Main.NavigationService.Navigate(account);
			}

		}

		private void HomeClick(object sender, RoutedEventArgs e)
		{
			HomePage index = new HomePage();
			Main.NavigationService.Navigate(index);
		}
    }
}
