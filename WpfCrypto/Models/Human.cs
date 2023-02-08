using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrypto.Models
{
	public class Human
	{
		private string Name;
		private string LastName;
		private int Age;

		private List<CoinsWallet> coins = new List<CoinsWallet>();	

		public Human(string name, string lastName, int age)
		{
			Name = name;
			LastName = lastName;
			Age = age;
		}

		public string GetName () { return Name; }
		public string GetLastName() { return LastName; }
		public int GetAge() { return Age; }

		public void AddCoins (CoinsWallet coin)
		{
			coins.Add(coin);
		}
		public List<CoinsWallet> GetCoins() { return coins; }
	}


}
