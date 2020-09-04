using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimations : MonoBehaviour {
	
	int ctrlChecker;

	public GameObject controller;
	public GameObject red;
	public GameObject yellow;
	public GameObject green;
	public GameObject blue;
	public GameObject purple;
	public GameObject white;

	RotateController controllerScript;

	RectTransform recRed, recYellow, recGreen, recBlue, recPurple , recWhite;

	Vector3 leftRedBorder, rightRedBorder, leftYellowBorder, rightYellowBorder, leftGreenBorder, rightGreenBorder,
	leftBlueBorder, rightBlueBorder, leftPurpleBorder, rightPurpleBorder, leftWhiteBorder, rightWhiteBorder, 
	presentPositionRed, presentPositionYellow, presentPositionGreen, presentPositionBlue, presentPositionPurple, presentPositionWhite;

	void Start () {
		
		controllerScript = controller.GetComponent<RotateController> ();

		recRed = red.GetComponent<RectTransform> ();
		recYellow = yellow.GetComponent<RectTransform> ();
		recGreen = green.GetComponent<RectTransform> ();
		recBlue = blue.GetComponent<RectTransform> ();
		recPurple = purple.GetComponent<RectTransform> ();
		recWhite = white.GetComponent<RectTransform> ();

		rightRedBorder = recRed.transform.position;
		rightYellowBorder = recYellow.transform.position;
		rightGreenBorder = recGreen.transform.position;
		rightBlueBorder = recBlue.transform.position;
		rightPurpleBorder = recPurple.transform.position;
		rightWhiteBorder = recWhite.transform.position;

		leftRedBorder = rightRedBorder - new Vector3 (20.0f,0.0f,0.0f);
		leftYellowBorder = rightYellowBorder - new Vector3 (20.0f,0.0f,0.0f);
		leftGreenBorder = rightGreenBorder - new Vector3 (20.0f,0.0f,0.0f);
		leftBlueBorder = rightBlueBorder - new Vector3 (20.0f,0.0f,0.0f);
		leftPurpleBorder = rightPurpleBorder - new Vector3 (20.0f, 0.0f, 0.0f);
		leftWhiteBorder = rightWhiteBorder - new Vector3 (20.0f,0.0f,0.0f);

	}

	void Update () {

		presentPositionWhite = recWhite.transform.position;
		presentPositionRed = recRed.transform.position;
		presentPositionBlue = recBlue.transform.position;
		presentPositionGreen = recGreen.transform.position;
		presentPositionYellow = recYellow.transform.position;
		presentPositionPurple = recPurple.transform.position;

		if (presentPositionWhite.x == presentPositionRed.x && presentPositionWhite.x == presentPositionYellow.x &&
			presentPositionWhite.x == presentPositionGreen.x && presentPositionWhite.x == presentPositionPurple.x &&
			presentPositionWhite.x == presentPositionBlue.x) {

			rightWhiteBorder.x = rightBlueBorder.x = rightGreenBorder.x = rightPurpleBorder.x = rightRedBorder.x = rightYellowBorder.x = presentPositionWhite.x;
			leftWhiteBorder.x = leftBlueBorder.x = leftGreenBorder.x = leftPurpleBorder.x = leftRedBorder.x = leftYellowBorder.x = presentPositionWhite.x - 20.0f;
		}

		if (presentPositionWhite.y != rightWhiteBorder.y) {

			rightWhiteBorder.y = leftWhiteBorder.y = presentPositionWhite.y;
			rightRedBorder.y = leftRedBorder.y = rightWhiteBorder.y - 70.0f;
			rightBlueBorder.y = leftBlueBorder.y = rightRedBorder.y - 70.0f;
			rightGreenBorder.y = leftGreenBorder.y = rightBlueBorder.y - 70.0f;
			rightYellowBorder.y = leftYellowBorder.y = rightGreenBorder.y - 70.0f;
			rightPurpleBorder.y = leftPurpleBorder.y = rightYellowBorder.y - 70.0f;
		}

		PlaceChecker (presentPositionRed, rightRedBorder, leftRedBorder, "Red");
		PlaceChecker (presentPositionYellow, rightYellowBorder, leftYellowBorder, "Yellow");
		PlaceChecker (presentPositionGreen, rightGreenBorder, leftGreenBorder, "Green");
		PlaceChecker (presentPositionBlue, rightBlueBorder, leftBlueBorder, "Blue");
		PlaceChecker (presentPositionPurple, rightPurpleBorder, leftPurpleBorder, "Purple");
		PlaceChecker (presentPositionWhite, rightWhiteBorder, leftWhiteBorder, "White");

		ctrlChecker = controllerScript.inputSide;

		if (ctrlChecker == 1) {
			MoveOtherBack ("White");
			Move (recWhite, presentPositionWhite, leftWhiteBorder);
		}

		if (ctrlChecker == 2) {
			MoveOtherBack ("Red");
			Move (recRed, presentPositionRed, leftRedBorder);
		}

		if (ctrlChecker == 3) {
			MoveOtherBack ("Blue");
			Move (recBlue, presentPositionBlue, leftBlueBorder);
		}

		if (ctrlChecker == 4) {
			MoveOtherBack ("Green");
			Move (recGreen, presentPositionGreen, leftGreenBorder);
		}

		if (ctrlChecker == 5) {
			MoveOtherBack ("Yellow");
			Move (recYellow, presentPositionYellow, leftYellowBorder);
		}

		if (ctrlChecker == 6) {
			MoveOtherBack ("Purple");
			Move (recPurple, presentPositionPurple, leftPurpleBorder);
		}
	}

	void MoveOtherBack(string immun){

		if (presentPositionRed != rightRedBorder && immun != "Red") Move (recRed, presentPositionRed, rightRedBorder);

		if (presentPositionYellow != rightYellowBorder && immun != "Yellow") Move (recYellow, presentPositionYellow, rightYellowBorder);

		if (presentPositionGreen != rightGreenBorder && immun != "Green") Move (recGreen, presentPositionGreen, rightGreenBorder);

		if (presentPositionBlue != rightBlueBorder && immun != "Blue") Move (recBlue, presentPositionBlue, rightBlueBorder);
		
		if (presentPositionPurple != rightPurpleBorder && immun != "Purple") Move (recPurple, presentPositionPurple, rightPurpleBorder);

		if (presentPositionWhite != rightWhiteBorder && immun != "White") Move (recWhite, presentPositionWhite, rightWhiteBorder);
	}

	void Move (RectTransform rec, Vector3 presentPosition, Vector3 point){
		rec.transform.position = Vector3.MoveTowards (presentPosition, point, Time.deltaTime * 1000);
	}
		
	void PlaceChecker(Vector3 presentPosition, Vector3 rightBorder, Vector3 leftBorder, string colorChecker){

		if (presentPosition.x < leftWhiteBorder.x && presentPosition.x < leftYellowBorder.x &&
		    presentPosition.x < leftGreenBorder.x && presentPosition.x < leftPurpleBorder.x &&
		    presentPosition.x < leftBlueBorder.x && presentPosition.x < leftRedBorder.x) {

			BorderMover (colorChecker, presentPosition);
		}

		if (presentPosition.x > rightWhiteBorder.x && presentPosition.x > rightYellowBorder.x &&
			presentPosition.x > rightGreenBorder.x && presentPosition.x > rightPurpleBorder.x &&
			presentPosition.x > rightBlueBorder.x && presentPosition.x > rightRedBorder.x) {

			BorderMover (colorChecker, presentPosition);
		}
	}

	void BorderMover(string colorChecker, Vector3 presentPosition){
		
		if (colorChecker == "White") {
			leftWhiteBorder = presentPosition;
			rightWhiteBorder = presentPosition + new Vector3 (20.0f, 0.0f, 0.0f);
			rightBlueBorder.x = rightGreenBorder.x = rightPurpleBorder.x = rightRedBorder.x = rightYellowBorder.x = rightWhiteBorder.x;
			leftBlueBorder.x = leftGreenBorder.x = leftPurpleBorder.x = leftRedBorder.x = leftYellowBorder.x = rightWhiteBorder.x - 20.0f;
		}

		if (colorChecker == "Red") {
			leftRedBorder = presentPosition;
			rightRedBorder = presentPosition + new Vector3 (20.0f, 0.0f, 0.0f);
			rightBlueBorder.x = rightGreenBorder.x = rightPurpleBorder.x = rightWhiteBorder.x = rightYellowBorder.x = rightRedBorder.x;
			leftBlueBorder.x = leftGreenBorder.x = leftPurpleBorder.x = leftWhiteBorder.x = leftYellowBorder.x = rightRedBorder.x - 20.0f;
		}

		if (colorChecker == "Blue") {
			leftBlueBorder = presentPosition;
			rightBlueBorder = presentPosition + new Vector3 (20.0f, 0.0f, 0.0f);
			rightWhiteBorder.x = rightGreenBorder.x = rightPurpleBorder.x = rightRedBorder.x = rightYellowBorder.x = rightBlueBorder.x;
			leftWhiteBorder.x = leftGreenBorder.x = leftPurpleBorder.x = leftRedBorder.x = leftYellowBorder.x = rightBlueBorder.x - 20.0f;
		}

		if (colorChecker == "Green") {
			leftGreenBorder = presentPosition;
			rightGreenBorder = presentPosition + new Vector3 (20.0f, 0.0f, 0.0f);
			rightBlueBorder.x = rightWhiteBorder.x = rightPurpleBorder.x = rightRedBorder.x = rightYellowBorder.x = rightGreenBorder.x;
			leftBlueBorder.x = leftWhiteBorder.x = leftPurpleBorder.x = leftRedBorder.x = leftYellowBorder.x = rightGreenBorder.x - 20.0f;
		}

		if (colorChecker == "Yellow") {
			leftYellowBorder = presentPosition;
			rightYellowBorder = presentPosition + new Vector3 (20.0f, 0.0f, 0.0f);
			rightBlueBorder.x = rightGreenBorder.x = rightPurpleBorder.x = rightRedBorder.x = rightWhiteBorder.x = rightYellowBorder.x;
			leftBlueBorder.x = leftGreenBorder.x = leftPurpleBorder.x = leftRedBorder.x = leftWhiteBorder.x = rightYellowBorder.x - 20.0f;
		}

		if (colorChecker == "Purple") {
			leftPurpleBorder = presentPosition;
			rightPurpleBorder = presentPosition + new Vector3 (20.0f, 0.0f, 0.0f);
			rightBlueBorder.x = rightGreenBorder.x = rightWhiteBorder.x = rightRedBorder.x = rightYellowBorder.x = rightPurpleBorder.x;
			leftBlueBorder.x = leftGreenBorder.x = leftWhiteBorder.x = leftRedBorder.x = leftYellowBorder.x = rightPurpleBorder.x - 20.0f;
		}
	}
}
