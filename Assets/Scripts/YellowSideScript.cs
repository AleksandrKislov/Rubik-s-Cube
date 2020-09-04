using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowSideScript : MonoBehaviour {

	public List<GameObject> YellowCubeTrigger = new List<GameObject> ();

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != GameObject.Find ("MainCubeRed") && other.gameObject != GameObject.Find ("MainCubeWhite") && 
			other.gameObject != GameObject.Find ("MainCubePurple") && other.gameObject != GameObject.Find ("MainCubeGreen"))
		YellowCubeTrigger.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		YellowCubeTrigger.Remove (other.gameObject);
	}
}
