using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSideScript : MonoBehaviour {

	public List<GameObject> RedCubeTrigger = new List<GameObject> ();

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != GameObject.Find ("MainCubeYellow") && other.gameObject != GameObject.Find ("MainCubeWhite") && 
			other.gameObject != GameObject.Find ("MainCubePurple") && other.gameObject != GameObject.Find ("MainCubeBlue"))
		RedCubeTrigger.Add (other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		RedCubeTrigger.Remove (other.gameObject);
	}
}
