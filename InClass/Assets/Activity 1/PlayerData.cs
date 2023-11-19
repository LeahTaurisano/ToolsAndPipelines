using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
	public int accountNum;
	public string accountName;
	public string accountPass;
}
