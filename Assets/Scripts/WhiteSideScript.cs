using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSideScript : MonoBehaviour {

	public List<GameObject> WhiteCubeTrigger = new List<GameObject> ();

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != GameObject.Find ("MainCubeYellow") && other.gameObject != GameObject.Find ("MainCubeRed") && 
			other.gameObject != GameObject.Find ("MainCubeGreen") && other.gameObject != GameObject.Find ("MainCubeBlue"))
			WhiteCubeTrigger.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		WhiteCubeTrigger.Remove (other.gameObject);
	}
}
