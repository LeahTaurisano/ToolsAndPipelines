using UnityEngine;

public class NetworkPositionReceiver : MonoBehaviour
{
	private Vector3 targetPosition;
	private float interpolationFactor = 0.1f; // Interpolation factor to control the smoothness of movement

	private void Update()
	{
		// Simulate receiving network position data (Replace with your network reception code)
		Vector3 receivedPosition = ReceiveNetworkPosition();

		// Interpolate towards the received position
		targetPosition = Vector3.Lerp(targetPosition, receivedPosition, interpolationFactor);

		// Update the GameObject position
		transform.position = targetPosition;
	}

	private Vector3 ReceiveNetworkPosition()
	{
		// Simulated method to receive the network position data
		// Replace this method with your actual network reception code
		return new Vector3(1.0f, 0.0f, 2.0f); // Return a sample position for demonstration
	}
}
