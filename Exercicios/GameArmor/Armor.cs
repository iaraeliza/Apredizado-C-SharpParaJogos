public class Armor
{
	public string Name { get; private set; }
	public int Block { get; private set; }
	public char Rank { get; private set; }

	public Armor(string name, int block)
	{
		Name = name;
		Block = block;
		Rank = GetRank(block);
	}

	public void BlockDamage(int damage)
	{
		Block -= damage;
	}

	public static char GetRank(int damage)
	{
		if (damage >= 50)
		{
			return 'S';
		}
		else if (damage >= 35)
		{
			return 'A';
		}
		else if (damage >= 15)
		{
			return 'B';
		}
		return 'C';
	}







}
