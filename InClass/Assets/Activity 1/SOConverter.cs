using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SOConverter
{
	[SerializeField]
	int dataIntValue;
	string dataAccName;
	string dataAccPass;
	string playerInput;
	
	public SOConverter (PlayerData so) {
		dataIntValue = so.accountNum;
		dataAccName = so.accountName;
		dataAccPass = so.accountPass;
		playerInput = so.playerInput;
	}
}
