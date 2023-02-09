using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Program : MonoBehaviour
{



	private Character _player1;
	private Character _player2;

	private List<Character> listPlayers = new List<Character>();

	public static event Action<List<Character>> OnCharacter;

	void Start()
	{
		var armor1 = new Armor("Prata", 30);
		var sword = new Weapon("Sword", 8);
		_player1 = new Character("Lex", 100, sword, armor1);


		var armor2 = new Armor("Ouro", 40);
		var dagger = new Weapon("Dagger", 6);
		_player2 = new Character("Ana", 100, dagger, armor2);

		listPlayers.Add(_player1);
		listPlayers.Add(_player2);
	}




	void Update()
	{
		Player1Control();

		Player2Control();

	}

	public void Player1Control()
	{
		bool key1Pressed = Input.GetKeyDown(KeyCode.Alpha1);
		bool key2Pressed = Input.GetKeyDown(KeyCode.Alpha2);
		bool key3Pressed = Input.GetKeyDown(KeyCode.Alpha3);
		bool key4Pressed = Input.GetKeyDown(KeyCode.Alpha4);

		if (key1Pressed)
		{
			_player1.Attack(_player2);
			OnCharacter?.Invoke(listPlayers);
		}
		else if (key2Pressed)
		{
			_player1.SharpenWeapon();
			OnCharacter?.Invoke(listPlayers);
		}
		else if (key3Pressed)
		{
			_player1.UnequiWeapon();
			OnCharacter?.Invoke(listPlayers);
		}
		else if (key4Pressed)
		{

			_player1.EquipWeapon(new Weapon("Weapon", Random.Range(5, 10)));
			OnCharacter?.Invoke(listPlayers);
		}

	}

	public void Player2Control()
	{
		bool keyQPressed = Input.GetKeyDown(KeyCode.Q);
		bool keyWPressed = Input.GetKeyDown(KeyCode.W);
		bool keyEPressed = Input.GetKeyDown(KeyCode.E);
		bool keyRPressed = Input.GetKeyDown(KeyCode.R);

		if (keyQPressed)
		{
			_player2.Attack(_player1);
			OnCharacter?.Invoke(listPlayers);
		}
		else if (keyWPressed)
		{
			_player2.SharpenWeapon();
			OnCharacter?.Invoke(listPlayers);
		}
		else if (keyEPressed)
		{
			_player2.UnequiWeapon();
			OnCharacter?.Invoke(listPlayers);
		}
		else if (keyRPressed)
		{
			_player2.EquipWeapon(new Weapon("Weapon", Random.Range(5, 10)));
			OnCharacter?.Invoke(listPlayers);
		}

	}
}