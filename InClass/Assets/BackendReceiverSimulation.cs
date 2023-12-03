using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackendReceiverSimulation : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerData myScriptableObject;
    private byte[] receivedData;
    void Start()
    {
	    // setup
    }

    // Update is called once per frame
    void Update()
    {
        if (FrontendSenderSimulation.dataSent)
        {
            receivedData = FrontendSenderSimulation.NetworkReceive();
            FrontendSenderSimulation.dataSent = false;

            //unpackedData = BitPacker.UnpackData(receivedData); UnpackData returns a bool, not a byte[] for deCompression, so I can't actually process anything here
            //uncompressedData = DataCompression.DecompressData(unpackedData);
            //decryptedData = EncryptedInputSender.DecryptData(uncompressedData); //Once again, even if I had a byte[] to work with, there is no decrypt method
            //myScriptableObject = ScriptableObjectSerializer.DeserializeScriptableObject(decryptedData); //This is where I would update the SO with changed info
            //and processed input (assuming input wasn't just checking for "space" as it is in this test

            //I hope the general idea here is enough, it doesn't feel particularly good to have to write out solely comments for the latter
            //half of an assignment, but I am unsure how to change the Unpacker to return the unpacked bytes instead of just a bool,
            //as I have not seen how packing and unpacking data works before.
        }
	    // data received from server
	    // unpack, decompress, deserialize, decrypt
	    
	    // interpolate into updated game events
	    
    }
}
