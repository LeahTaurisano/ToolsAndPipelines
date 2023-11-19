using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontendSenderSimulation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    // setup
    }

    // Update is called once per frame
    void Update()
    {
	    // game events happen here
	    // lockstep events to queue them for sending
	    // encrypt, serialize, compress, pack
	    NetworkSend();
    }
    
	private void NetworkSend(){
		
		Debug.Log("sending packet to backend..."); 
	}
}
