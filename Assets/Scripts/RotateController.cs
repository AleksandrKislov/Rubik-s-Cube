using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {

	float rotationAngle = 1;
	public int inputSide;

	public Quaternion originalRedRotation, originalYellowRotation, originalGreenRotation, originalBlueRotation, originalPurpleRotation, originalWhiteRotation;

	public Rigidbody rbRed, rbYellow, rbGreen, rbBlue, rbPurple, rbWhite;

	public GameObject redSide;
	public GameObject yellowSide;
	public GameObject greenSide;
	public GameObject blueSide;
	public GameObject purpleSide;
	public GameObject whiteSide;

	public List<GameObject> redSideList = new List<GameObject> ();
	public List<GameObject> yellowSideList = new List<GameObject> ();
	public List<GameObject> greenSideList = new List<GameObject> ();
	public List<GameObject> blueSideList = new List<GameObject> ();
	public List<GameObject> purpleSideList = new List<GameObject> ();
	public List<GameObject> whiteSideList = new List<GameObject> ();

	void Start () {

		RedSideScript redSideScript = redSide.GetComponent<RedSideScript>();
		redSideList = redSideScript.RedCubeTrigger;
		rbRed = redSideScript.GetComponent<Rigidbody> ();
		originalRedRotation = redSide.transform.rotation;

		YellowSideScript yellowSideScript = yellowSide.GetComponent<YellowSideScript>();
		yellowSideList = yellowSideScript.YellowCubeTrigger;
		rbYellow = yellowSideScript.GetComponent<Rigidbody> ();
		originalYellowRotation = yellowSide.transform.rotation;

		GreenSideScript greenSideScript = greenSide.GetComponent<GreenSideScript>();
		greenSideList = greenSideScript.GreenCubeTrigger;
		rbGreen = greenSideScript.GetComponent<Rigidbody> ();
		originalGreenRotation = greenSide.transform.rotation;

		BlueSideScript blueSideScript = blueSide.GetComponent<BlueSideScript>();
		blueSideList = blueSideScript.BlueCubeTrigger;
		rbBlue = blueSideScript.GetComponent<Rigidbody> ();
		originalBlueRotation = blueSide.transform.rotation;

		PurpleSideScript purpleSideScript = purpleSide.GetComponent<PurpleSideScript>();
		purpleSideList = purpleSideScript.PurpleCubeTrigger;
		rbPurple = purpleSideScript.GetComponent<Rigidbody> ();
		originalPurpleRotation = purpleSide.transform.rotation;

		WhiteSideScript whiteSideScript = whiteSide.GetComponent<WhiteSideScript>();
		whiteSideList = whiteSideScript.WhiteCubeTrigger;
		rbWhite = whiteSideScript.GetComponent<Rigidbody> ();
		originalWhiteRotation = whiteSide.transform.rotation;
	}

	void FixedUpdate () { 
		if (Input.GetKeyDown (KeyCode.Alpha1)) InputSideRotationChecker(1);
		if (Input.GetKeyDown (KeyCode.Alpha2)) InputSideRotationChecker(2);
		if (Input.GetKeyDown (KeyCode.Alpha3)) InputSideRotationChecker(3);
		if (Input.GetKeyDown (KeyCode.Alpha4)) InputSideRotationChecker(4);
		if (Input.GetKeyDown (KeyCode.Alpha5)) InputSideRotationChecker(5);
		if (Input.GetKeyDown (KeyCode.Alpha6)) InputSideRotationChecker(6);
			
		if (inputSide == 1) {
			if (Input.GetKeyDown (KeyCode.F) && originalWhiteRotation == whiteSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.down, whiteSideList, whiteSide, originalWhiteRotation, rbWhite));

			if (Input.GetKeyDown (KeyCode.G) && originalWhiteRotation == whiteSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.up, whiteSideList, whiteSide, originalWhiteRotation, rbWhite));
		}

		if (inputSide == 2) {
			if (Input.GetKeyDown (KeyCode.F) && originalRedRotation == redSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.right, redSideList, redSide, originalRedRotation, rbRed));

			if (Input.GetKeyDown (KeyCode.G) && originalRedRotation == redSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.left, redSideList, redSide, originalRedRotation, rbRed));
		}

		if (inputSide == 3) {
			if (Input.GetKeyDown (KeyCode.F) && originalBlueRotation == blueSide.transform.rotation)
				StartCoroutine (Rotate (new Vector3 (0, 0, 1), blueSideList, blueSide, originalBlueRotation, rbBlue));

			if (Input.GetKeyDown (KeyCode.G) && originalBlueRotation == blueSide.transform.rotation)
				StartCoroutine (Rotate (new Vector3 (0, 0, -1), blueSideList, blueSide, originalBlueRotation, rbBlue));
		}

		if (inputSide == 4) {
			if (Input.GetKeyDown (KeyCode.F) && originalGreenRotation == greenSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.left, greenSideList, greenSide, originalGreenRotation, rbGreen));

			if (Input.GetKeyDown (KeyCode.G) && originalGreenRotation == greenSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.right, greenSideList, greenSide, originalGreenRotation, rbGreen));
		}
			
		if (inputSide == 5) {
			if (Input.GetKeyDown (KeyCode.F) && originalYellowRotation == yellowSide.transform.rotation)
				StartCoroutine (Rotate (new Vector3 (0, 0, -1), yellowSideList, yellowSide, originalYellowRotation, rbYellow));

			if (Input.GetKeyDown (KeyCode.G) && originalYellowRotation == yellowSide.transform.rotation)
				StartCoroutine (Rotate (new Vector3 (0, 0, 1), yellowSideList, yellowSide, originalYellowRotation, rbYellow));
		}

		if (inputSide == 6) {
			if (Input.GetKeyDown (KeyCode.F) && originalPurpleRotation == purpleSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.up, purpleSideList, purpleSide, originalPurpleRotation, rbPurple));

			if (Input.GetKeyDown (KeyCode.G) && originalPurpleRotation == purpleSide.transform.rotation)
				StartCoroutine (Rotate (Vector3.down, purpleSideList, purpleSide, originalPurpleRotation, rbPurple));
		}
	}

	void InputSideRotationChecker(int inputSideRC){
		if (originalWhiteRotation == whiteSide.transform.rotation && originalRedRotation == redSide.transform.rotation && 
			originalBlueRotation == blueSide.transform.rotation && originalGreenRotation == greenSide.transform.rotation && 
			originalYellowRotation == yellowSide.transform.rotation && originalPurpleRotation == purpleSide.transform.rotation)
		inputSide = inputSideRC;
	}

	IEnumerator Rotate(Vector3 direction, List<GameObject> CubeTrigger, GameObject side, Quaternion originalRotation, Rigidbody rb){

		for (int i = 0; i < CubeTrigger.Count; i++) {
			CubeTrigger [i].GetComponent<FixedJoint> ().connectedBody = rb;
		}

		for(;;){

			if (rotationAngle == 90) {
				rotationAngle = 1;

				if (side == redSide)
					originalRedRotation = side.transform.rotation;
				if (side == yellowSide)
					originalYellowRotation = side.transform.rotation;
				if (side == greenSide)
					originalGreenRotation = side.transform.rotation;
				if (side == blueSide)
					originalBlueRotation = side.transform.rotation;
				if (side == purpleSide)
					originalPurpleRotation = side.transform.rotation;
				if (side == whiteSide)
					originalWhiteRotation = side.transform.rotation;
				break;
			}

			rotationAngle++;

			Quaternion rotationX = Quaternion.AngleAxis (rotationAngle, direction);
			side.transform.rotation = originalRotation * rotationX;

			yield return new WaitForFixedUpdate ();
		}
	}
}
