using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {

	GameObject[] stars;

	public int count=0;

	public static bool changeAllowed=true;

	float lineTime = 0;

	int goalCount=1;

	LineRenderer lr;

	// Use this for initialization
	void Start () {
		stars = GameObject.FindGameObjectsWithTag ("Star");
		lr = gameObject.GetComponent<LineRenderer> ();
		lr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		List<Vector3> lit=new List<Vector3>();
		int id = 0;
		int binVal = 1;

		foreach(GameObject star in stars){
			if (star.GetComponent<StarLighting> ().lit) {
				id += binVal;
				lit.Add (star.transform.position);
			}
			binVal *= 2;
		}

		count = lit.Count;

		if (count == Mathf.Min(Mathf.Max(3,goalCount),5) && lineTime<0) {

			string con="";
			switch (id) 
			{
			case 7:
				con = "Aries";
				break;
			case 11:
				con = "Libra";
				break;
			case 13:
				con="Taurus";
				break;
			case 14:
				con = "Scorpio";
				break;
			case 15:
				con = "Orien";
				break;
			case 19:
				con = "Virgo";
				break;
			case 21:
				con = "Pisces";
				break;
			case 22:
				con = "Cancer";
				break;
			case 23:
				con = "Ursa Min.";
				break;
			case 25:
				con = "Capricorn";
				break;
			case 26:
				con = "Leo";
				break;
			case 27:
				con = "Draco";
				break;
			case 28:
				if (Abduction.main.Captured ()) {
					con = "Gemini";
					Abduction.main.DropBall ();
				}
				else 
					con = "Pisces";
				break;
			case 29:
				con = "Centaurus";
				break;
			case 30:
				con = "Cygnus";
				break;
			case 31:
				con = "Ursa Maj.";
				break;
			}

			lineTime = 10;
			lr.positionCount=(Mathf.Min(Mathf.Max(3,goalCount),5));
			lr.SetPositions (lit.ToArray());
			lr.enabled = true;
			changeAllowed = false;
			ScoreSystem.MessageManager.SetMessage (con+" SKY",10);
			ScoreSystem.IncreaseScore (500*goalCount);
			if (goalCount < 5)
				goalCount++;
			else
				goalCount = 1;
		}


		lineTime -= Time.deltaTime;

		if (lineTime < 0 && lr.enabled) {
			changeAllowed = true;
			lr.enabled = false;
			TurnOffStars ();
		}
	}

	void TurnOffStars(){
		foreach(GameObject star in stars){
			star.GetComponent<StarLighting> ().SetLit (false);
		}
	}
}
