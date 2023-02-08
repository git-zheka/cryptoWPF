using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrypto
{
	class GetToken
	{
		public static string Key;

		public void SetKey(string token)
		{
			Key = token;
		}

		public string GetKey()
		{
			return Key;
		}
	}
}
