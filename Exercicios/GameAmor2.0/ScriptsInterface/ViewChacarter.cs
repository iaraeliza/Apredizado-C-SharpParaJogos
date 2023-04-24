using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewChacarter : MonoBehaviour
{
	public List<TextMeshProUGUI> players = new List<TextMeshProUGUI>();

	public TextMeshProUGUI Action;



	private void Start()
	{
		Program.OnCharacter += TextView;
		Character.OnAction += ActionEvent;

	}

	private void TextView(List<Character> listPlayer)
	{
		for (int i = 0; i < players.Count; i++)
		{
			TextMeshProUGUI infoPlayer = players[i];
			infoPlayer.text = listPlayer[i].Name + "\n";
			infoPlayer.text += listPlayer[i].Life <= 0 ? "Morreu\n" : listPlayer[i].Life + "\n";
			infoPlayer.text += listPlayer[i].Weapon == null ? "Sem arma\n" : "Arma: " + listPlayer[i].Weapon.Name + "\n" + " Dano: " + listPlayer[i].Weapon.Damage + "\n";
			infoPlayer.text += listPlayer[i].Armor == null ? "Sem armadura\n" : "Tipo de Armadura: " + listPlayer[i].Armor.Name + "\n" + " Armadura Restante: " + listPlayer[i].Armor.Block + "\n";
		}
	}

	private void ActionEvent(string action)
	{
		Action.text = action;
	}

}
