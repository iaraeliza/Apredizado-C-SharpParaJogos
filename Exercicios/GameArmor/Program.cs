using UnityEngine;
public class Program : MonoBehaviour
{

	private Character _player1;
	private Character _player2;

	void Start()
	{
		var armor1 = new Armor("Armadura", 30);
		var sword = new Weapon("Sword", 8);
		_player1 = new Character("Lex", 100, sword, armor1);


		var armor2 = new Armor("Armadura", 40);
		var dagger = new Weapon("Dagger", 6);
		_player2 = new Character("Ana", 100, dagger, armor2);
	}




	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			_player1.Attack(_player2);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_player1.SharpenWeapon();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_player1.UnequiWeapon();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			_player1.EquipWeapon(new Weapon("Weapon", Random.Range(5, 10)));
		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			_player2.Attack(_player1);
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			_player2.SharpenWeapon();
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			_player2.UnequiWeapon();
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			_player2.EquipWeapon(new Weapon("Weapon", Random.Range(5, 10)));
		}
	}
}