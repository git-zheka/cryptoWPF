using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrypto.Models
{
	public class CoinsWallet
	{
		public string name { get; set; }
		public double sum { get; set; }
		public double dollars { get; set; }

		public CoinsWallet(string name, double sum, double dollars) 
		{
			this.name = name;
			this.sum = sum;
			this.dollars = dollars;
		}
	}
}
