using System;
using System.Windows;
using System.Windows.Controls;
using WpfCrypto.Models;
using WpfCrypto.VirtualBD;

namespace WpfCrypto.Views
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class LoginandRegit : Page
	{
		DB connectVDB = new DB();

		public LoginandRegit()
		{
			InitializeComponent();
		}

		private void btn_createAc(object sender, RoutedEventArgs e)
		{

			if (StringIsDigits(RegitAge.Text)) {
				Human human = new Human(RegitName.Text,RegitLastName.Text, Convert.ToInt32(RegitAge.Text));
				connectVDB.SetHuman(human);
				MessageBox.Show("New account created", "Information", MessageBoxButton.OK,MessageBoxImage.Information);
				
				RegitName.Text = "";
				RegitLastName.Text = "";
				RegitAge.Text = "";
			}
			else
			{
				ErrorlableCreate.Content = "Error in age";
			}
		}

		bool StringIsDigits(string s)
		{
			foreach (var item in s)
			{
				if (!char.IsDigit(item))
				{
					return false;
				}	
			}
			return true;
		}

		private void btn_login_Click(object sender, RoutedEventArgs e)
		{
			string Name = LoginName.Text;
			string LastName = LastNamelogin.Text;

			for (int i = 0; i < DB.People.Count; i++)
			{
				if (DB.People[i].GetName() == Name && DB.People[i].GetLastName() == LastName)
				{
					MessageBox.Show("You Logined", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
					
					LoginedHuman log = new LoginedHuman(DB.People[i].GetName(), DB.People[i].GetLastName());
					
					HomePage page = new HomePage();
					NavigationService.Navigate(page);

					break;
				}
				else
				{
					Errorlable.Content = "Error Name or LastName";
				}
			}
		}
	}
}
