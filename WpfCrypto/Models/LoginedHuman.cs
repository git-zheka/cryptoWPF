namespace WpfCrypto.Models
{
	public class LoginedHuman
	{
		private static string Name;
		private static string LastName;

		public LoginedHuman(string name, string lastname) 
		{
			Name = name;
			LastName = lastname;
		}

		public LoginedHuman() { }

		public string GetName() { return Name; }
		public string GetLastName() { return LastName; }
	}


}
