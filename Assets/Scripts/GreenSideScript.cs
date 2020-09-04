using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSideScript : MonoBehaviour {

	public List<GameObject> GreenCubeTrigger = new List<GameObject> ();

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != GameObject.Find ("MainCubeYellow") && other.gameObject != GameObject.Find ("MainCubeWhite") && 
			other.gameObject != GameObject.Find ("MainCubePurple") && other.gameObject != GameObject.Find ("MainCubeBlue"))
			GreenCubeTrigger.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		GreenCubeTrigger.Remove (other.gameObject);
	}
}
