using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontendSenderSimulation : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerData myScriptableObject;

    private string playerInput;

    public static bool dataSent = false;

    private static byte[] packedData;
    void Start()
    {
	    // setup
    }

    // Update is called once per frame
    void Update()
    {
        // game events happen here
        LockstepManager.InitiateLockstep();

        if (LockstepManager.processed) //Only implemented so the NetworkSend doesn't spam the DebugLog
        {
            foreach (InputData inputData in LockstepManager.inputBuffer)
            {
                myScriptableObject.playerInput = inputData.input; //Catches the last input
            }

            // encrypt, serialize, compress, pack
            byte[] serializedData = ScriptableObjectSerializer.SerializeScriptableObject(myScriptableObject);

            string serializedString = BitConverter.ToString(serializedData);

            byte[] encryptedData = EncryptedInputSender.EncryptData(serializedString);

            byte[] compressedData = DataCompression.CompressData(encryptedData);

            packedData = BitPacker.PackData(compressedData.Length, compressedData);

            if (LockstepManager.processed && LockstepManager.hadInput) //Once again, only to prevent DebugLog spam for readability and testing
            {
                NetworkSend();
            }
        }
    }
    
	private void NetworkSend(){
		
		Debug.Log("sending packet to backend...");
        LockstepManager.processed = false; 
        LockstepManager.hadInput = false;
        dataSent = true;

    }

    public static byte[] NetworkReceive()
    {
        return packedData;
    }
}
