using System;

public class Character
{
	public string Name { get; private set; }
	public int Life { get; private set; }
	public bool IsAlive { get => Life > 0; }
	public Armor Armor { get; private set; }
	public Weapon Weapon { get; private set; }

	public static event Action<string> OnAction;

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
			OnAction?.Invoke($"{other.Name} já está morto.");
			return;
		}
		if (!HasWeapon()) return;

		OnAction?.Invoke($"{Name} atacou {other.Name} com sua {Weapon.Name}.");

		other.DealDamage(Weapon.Damage);
	}

	public void SharpenWeapon()
	{
		if (!CheckAlive()) return;

		if (!HasWeapon()) return;

		OnAction?.Invoke($"{Name} afiou sua {Weapon.Name}");

		ISharpenable sharpenable = Weapon as ISharpenable;
		sharpenable.Sharpen();
	}

	public void UnequiWeapon()
	{
		if (!CheckAlive()) return;

		if (!HasWeapon()) return;

		OnAction?.Invoke($"{Name} desequipou sua {Weapon.Name}.");
		Weapon = null;
	}

	public void EquipWeapon(Weapon weapon)
	{
		if (!CheckAlive()) return;

		if (Weapon != null)
		{
			OnAction?.Invoke($"{Name} já tem uma arma equipada.");
		}

		else
		{
			Weapon = weapon;
			OnAction?.Invoke($"{Name} equipou uma {Weapon.Name} (Dano: {Weapon.Damage} - Rank: {Weapon.Rank}).");
			Weapon = null;
		}
	}

	private void DealDamage(int amount)
	{
		Armor.BlockDamage(amount);
		if (Armor.Block >= 0)
		{
			OnAction?.Invoke($"Dano bloqueado. Armadura restante: {Armor.Block}");
		}
		if (Armor.Block <= 0)
		{
			Life -= amount;
			OnAction?.Invoke($"Sem Armadura");
		}

		OnAction?.Invoke($"{Name} tomou {amount} de dano.\n"
			+ $"Vida atual de {Name}: {Life}");

		CheckAlive();
	}

	private bool CheckAlive()
	{
		if (!IsAlive)
		{
			OnAction?.Invoke($"{Name} está Morto(a).");
		}

		return IsAlive;
	}

	private bool HasWeapon()
	{
		if (Weapon == null)
		{
			OnAction?.Invoke($"{Name} não tem uma arma.");
		}

		return Weapon != null;
	}
}
