using UnityEngine;
using System.Collections;

public class Paddle_Input_Arduino : MonoBehaviour 
{
	public bool AcceptingInput = true;
	public float Speed = 5f;
	

	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!AcceptingInput)
		{
			return;	
		}


		//Debug.Log (Controller.Instance.getAnalog ());
        
	}
	

}
