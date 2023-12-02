using UnityEngine;

public class DataPreparation : MonoBehaviour
{
	public PlayerData myScriptableObject; // Reference to the ScriptableObject data

	private void Start()
	{

	}

	public byte[] PrepareData(string data)
	{
        byte[] serializedData = ScriptableObjectSerializer.SerializeScriptableObject(myScriptableObject);

        // Compress the data
        byte[] compressedData = DataCompression.CompressData(serializedData);

        // Pack the data for sending
        byte[] packedData = BitPacker.PackData(compressedData.Length, compressedData);

		return packedData;
    }

	private void Update()
	{
		 //   if (Input.GetKeyDown(KeyCode.Space))
		 //   {
			//	PrepareData();
			//}
		//	// Get data from the ScriptableObject
		//	//SaveDataBinaryManager.Save(myScriptableObject);
		//	//SaveDataBinaryManager.Load(myScriptableObject);

		//	// Pack the data for sending
		//	//byte[] packedData = BitPacker.PackData(serializedData.Length, serializedData);

		//	// Now you can send the packedData over the network or perform any required action with it
		//	// ...

		//	// Example: Sending the packed data as a debug log
		//	Debug.Log("Packed Data: " + System.Convert.ToBase64String(packedData));
		//}
    }
}



