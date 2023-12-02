using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontendSenderSimulation : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerData myScriptableObject;

    string playerInput;
    public static List<InputData> inputBuffer = new List<InputData>();

    void Start()
    {
	    // setup
    }

    // Update is called once per frame
    void Update()
    {
        // game events happen here
        inputBuffer = LockstepManager.InitiateLockstep();

        foreach (InputData inputData in inputBuffer)
        {
            myScriptableObject.playerInput = inputData.input; //Catches the last input
        }

        // encrypt, serialize, compress, pack
        byte[] encryptedData = EncryptedInputSender.EncryptData(myScriptableObject.playerInput); //This takes a string and returns a byte[]

        byte[] serializedData = ScriptableObjectSerializer.SerializeScriptableObject(myScriptableObject); //This takes a SO and returns a byte[]
                                                                                                          //How can they interact?
        byte[] compressedData = DataCompression.CompressData(serializedData);

        byte[] packedData = BitPacker.PackData(compressedData.Length, compressedData);

        NetworkSend();
    }
    
	private void NetworkSend(){
		
		Debug.Log("sending packet to backend..."); 
	}
}
