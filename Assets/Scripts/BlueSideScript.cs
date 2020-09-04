using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSideScript : MonoBehaviour {

	public List<GameObject> BlueCubeTrigger = new List<GameObject> ();

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != GameObject.Find ("MainCubeRed") && other.gameObject != GameObject.Find ("MainCubeWhite") && 
			other.gameObject != GameObject.Find ("MainCubePurple") && other.gameObject != GameObject.Find ("MainCubeGreen"))
			BlueCubeTrigger.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		BlueCubeTrigger.Remove (other.gameObject);
	}
}
