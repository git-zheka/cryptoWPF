using System;

public class Asset
{
	public Quote quote { get; set; }
	public string asset_id { get; set; }
	public string name { get; set; }
	public string description { get; set; }
	public string website { get; set; }
	public string ethereum_contract_address { get; set; }
	public string pegged { get; set; }
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double change_1h { get; set; }
	public double change_24h { get; set; }
	public double change_7d { get; set; }
	public double total_supply { get; set; }
	public double circulating_supply { get; set; }
	public int max_supply { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
	public string status { get; set; }
	public DateTime created_at { get; set; }
	public DateTime updated_at { get; set; }
}

public class AUD
{
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
}

public class CAD
{
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
}

public class EUR
{
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
}

public class GBP
{
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
}

public class JPY
{
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
}

public class NZD
{
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
}

public class Quote
{
	public AUD AUD { get; set; }
	public EUR EUR { get; set; }
	public JPY JPY { get; set; }
	public USD USD { get; set; }
	public CAD CAD { get; set; }
	public NZD NZD { get; set; }
	public GBP GBP { get; set; }
}

public class Root
{
	public Asset asset { get; set; }
}

public class USD
{
	public double price { get; set; }
	public double volume_24h { get; set; }
	public double market_cap { get; set; }
	public double fully_diluted_market_cap { get; set; }
}

