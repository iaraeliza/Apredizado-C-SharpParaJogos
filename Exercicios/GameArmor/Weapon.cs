using UnityEngine;
public class Weapon
{
	public string Name { get; private set; }
	public int Damage { get; private set; }
	public char Rank { get; private set; }

	public Weapon(string name, int damage)
	{
		Name = name;
		Damage = damage;
		Rank = GetRank(damage);
	}

	public void Sharpen()
	{
		Damage++;
		Debug.Log($"{Name} foi afiada! Dano aumentou para {Damage}.");

		var newRank = Weapon.GetRank(Damage);
		if (newRank != Rank)
		{
			Rank = newRank;
			Debug.Log($"Rank da {Name} aumentou para {Rank}!");
		}

	}

	public static char GetRank(int damage)
	{
		if (damage >= 10)
		{
			return 'S';
		}
		else if (damage >= 7)
		{
			return 'A';
		}
		else if (damage >= 4)
		{
			return 'B';
		}
		return 'C';
	}
}