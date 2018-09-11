using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWarp : MonoBehaviour {

	// Use this for initialization
	public Virus_Movement suction;
	public Camera_Movement tracker;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "virus2") {
			suction.propulsion = 50000f;
			tracker.IsWarping = true;
		}
	}

}
