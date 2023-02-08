using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCrypto.Models;

namespace WpfCrypto.VirtualBD
{
	public class DB
	{
		static public List<Human> People = new List<Human>();

		public void SetHuman(Human human)
		{
			People.Add(human);
		}

		public Human GetHumans(int id) 
		{
			return People[id];
		}

	}
}
