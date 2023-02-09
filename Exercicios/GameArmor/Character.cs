using UnityEngine;
public class Character
{
	public string Name { get; private set; }
	public int Life { get; private set; }

	public bool IsAlive { get => Life > 0; }

	public Armor Armor { get; private set; }

	public Weapon Weapon { get; private set; }



	public Character(string name, int life, Weapon weapon, Armor armor)
	{
		Name = name;
		Life = life;
		Weapon = weapon;
		Armor = armor;

	}

	public void Attack(Character other)
	{
		if (!CheckAlive()) return;

		if (!other.IsAlive)
		{
			Debug.Log($"{other.Name} já está morto.");
			return;
		}
		if (!HasWeapon()) return;

		Debug.Log($"{Name} atacou {other.Name} com sua {Weapon.Name}.");
		other.DealDamage(Weapon.Damage);

	}

	public void SharpenWeapon()
	{
		if (!CheckAlive()) return;

		if (!HasWeapon()) return;

		Debug.Log($"{Name} afiou sua {Weapon.Name}");
		Weapon.Sharpen();
	}

	public void UnequiWeapon()
	{
		if (!CheckAlive()) return;

		if (!HasWeapon()) return;

		Debug.Log($"{Name} desequipou sua {Weapon.Name}.");
		Weapon = null;
	}

	public void EquipWeapon(Weapon weapon)
	{
		if (!CheckAlive()) return;

		if (Weapon != null)
		{
			Debug.Log($"{Name} ja tem uma arma equipada.");
		}

		else
		{
			Weapon = weapon;
			Debug.Log($"{Name} equipou uma {Weapon.Name} (Dano: {Weapon.Damage} - Rank: {Weapon.Rank}).");
			Weapon = null;
		}

	}

	private void DealDamage(int ammount)
	{
		Armor.BlockDamage(ammount);
		if (Armor.Block >= 0)
		{
			Debug.Log($"Dano bloqueado. Armadura restante: {Armor.Block}");
		}
		if (Armor.Block <= 0)
		{
			Life -= ammount;
		}

		Debug.Log($"{Name} tomou {ammount} de dano.\n"
			+ $"Vida atual de {Name}: {Life}");

		CheckAlive();
	}



	private bool CheckAlive()
	{
		if (!IsAlive)
		{
			Debug.Log($"{Name} está Morto.");
		}

		return IsAlive;
	}

	private bool HasWeapon()
	{
		if (Weapon == null)
		{
			Debug.Log($"{Name} não tem uma arma.");
		}

		return Weapon != null;
	}

}