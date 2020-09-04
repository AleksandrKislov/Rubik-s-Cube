using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleSideScript : MonoBehaviour {

	public List<GameObject> PurpleCubeTrigger = new List<GameObject> ();

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != GameObject.Find ("MainCubeYellow") && other.gameObject != GameObject.Find ("MainCubeRed") && 
			other.gameObject != GameObject.Find ("MainCubeGreen") && other.gameObject != GameObject.Find ("MainCubeBlue"))
			PurpleCubeTrigger.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		PurpleCubeTrigger.Remove (other.gameObject);
	}
}
