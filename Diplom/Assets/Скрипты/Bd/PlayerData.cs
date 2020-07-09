using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public string player_name;
	public PlayerData(Player player)
	{
		player_name = player.player_name;
	}
}
