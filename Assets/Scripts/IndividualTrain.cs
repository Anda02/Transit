using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualTrain : MonoBehaviour {
	public GameObject traintarget;
	int citycoords = 0;
	//numberof city in line list
	int citynumber = 1;
	bool moveforward = true;
	public bool collided = false;
	bool backwards = false;
	bool lookatcheck = true;

	/*
	void Update(){
		GameObject Scripts = GameObject.Find ("Scripts");
		pointclickcreate citylocations = Scripts.GetComponent<pointclickcreate> ();
		print ("Collided");

		if (other.name == traintarget.name) {
			//moves train forward along the line
			if (citycoords != citylocations.line1.Count && moveforward == true) {
				traintarget.transform.position = citylocations.line1 [citynumber].location;
				transform.LookAt (traintarget.transform);
				citynumber++;
			}
			if (citycoords == 0) {
				moveforward = true;
				citycoords++;
			}
			//Detects if it is on the last city, then reverses the order
			else if (citycoords == citylocations.line1.Count) {
				moveforward = false;
				citynumber--;
				traintarget.transform.position = citylocations.line1 [citynumber].location;
				transform.LookAt (traintarget.transform);

			}
		}
	}
	*/
	void Start(){
		traintarget = GameObject.Find ("traintarget");
		GameObject Scripts = GameObject.Find ("Scripts");
		pointclickcreate citylocations = Scripts.GetComponent<pointclickcreate> ();
		traintarget.transform.position = citylocations.line1 [1].location;
		transform.LookAt (traintarget.transform);
	}

	void Update(){
		transform.Translate (transform.forward * Time.deltaTime * 1.0f, relativeTo: Space.World);
		//absence of this if statement makes the train do bizzares orbits to get to its destination
		if (lookatcheck == true) {
			transform.LookAt (traintarget.transform);
			lookatcheck = false;
		}

	}

	void OnTriggerEnter (Collider other){
		GameObject Scripts = GameObject.Find ("Scripts");
		pointclickcreate citylocations = Scripts.GetComponent<pointclickcreate> ();
		print ("Bad collision");
		if (other.gameObject.transform.tag == "target") {
			print ("Collided");
			lookatcheck = true;
			//moves train forward along the line
			if (citynumber != citylocations.line1.Count && backwards == false) {
				citynumber++;
				print ("Citycoords: " + citycoords + " City Number: " + citynumber + " Lin Count: " + citylocations.line1.Count);
				traintarget.transform.position = citylocations.line1 [citynumber].location;
				transform.LookAt (traintarget.transform);
				citycoords++;
				if (citynumber == citylocations.line1.Count - 1) {
					backwards = true;
					print ("Backwards was triggered");
				}
			}
			//when the train hits the first city in the line again, it turns back around
			else if (citynumber == 0) {
				//moveforward = true;
				citynumber++;
				backwards = false;
				lookatcheck = true;
				print ("Backwards fix triggers");
			}
			//Detects if it is on the last city, then reverses the order
			else if (backwards == true) {
				//moveforward = false;
				citynumber--;
				/*
				if (citynumber == 0) {
					traintarget.transform.position = citylocations.line1 [citynumber+1].location;
				}
				*/
				traintarget.transform.position = citylocations.line1 [citynumber].location;
				transform.LookAt (traintarget.transform);
				print ("Citycoords: " + citycoords + " City Number: " + citynumber + " Lin Count: " + citylocations.line1.Count);
				print ("Backwards happened");
			}
		}


	}
}
