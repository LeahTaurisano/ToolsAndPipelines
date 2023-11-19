using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ScriptableObjectSerializer
{
	public static byte[] SerializeScriptableObject(PlayerData scriptableObject)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		using (MemoryStream stream = new MemoryStream())
		{
			SOConverter data = new SOConverter(scriptableObject);
			formatter.Serialize(stream, data);
			return stream.ToArray();
		}
	}

	public static T DeserializeScriptableObject<T>(byte[] data) where T : PlayerData
	{
		BinaryFormatter formatter = new BinaryFormatter();
		using (MemoryStream stream = new MemoryStream(data))
		{
			return formatter.Deserialize(stream) as T;
		}
	}
}
