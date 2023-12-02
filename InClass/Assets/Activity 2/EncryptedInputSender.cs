using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public class EncryptedInputSender : MonoBehaviour
{
	public static string sharedKey = "MySharedKey12345"; // Shared secret key for encryption and decryption

	private void Update()
	{
		// Simulate input
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Get input data
			string inputData = "Space";

			// Encrypt the input data
			byte[] encryptedData = EncryptData(inputData);

			// Send the encrypted data over the network (Replace with your network transmission code)
			SendDataOverNetwork(encryptedData);
		}
	}

	public static byte[] EncryptData(string data)
	{
		byte[] encryptedData;

		using (Aes aes = Aes.Create())
		{
			// Derive a key and initialization vector (IV) from the shared key
			byte[] keyBytes = Encoding.UTF8.GetBytes(sharedKey);
			byte[] iv = new byte[aes.BlockSize / 8];
			Array.Copy(keyBytes, iv, iv.Length);

			// Set AES settings
			aes.Key = keyBytes;
			aes.IV = iv;
			aes.Mode = CipherMode.CBC;

			// Create an encryptor to perform the AES encryption
			ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

			// Convert the input string to bytes
			byte[] dataBytes = Encoding.UTF8.GetBytes(data);

			// Encrypt the data
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
				{
					cryptoStream.Write(dataBytes, 0, dataBytes.Length);
					cryptoStream.FlushFinalBlock();
				}

				encryptedData = memoryStream.ToArray();
			}
		}

		return encryptedData;
	}

	public static void SendDataOverNetwork(byte[] data)
	{
		// Replace this method with your network transmission code to send the encrypted data
		// over the network to the intended recipient(s)
		Debug.Log("Sending encrypted data over the network...");
		Debug.Log("Encrypted Data: " + BitConverter.ToString(data));
	}
}
