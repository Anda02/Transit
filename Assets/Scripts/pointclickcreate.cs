using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointclickcreate : MonoBehaviour {

	public GameObject startobj;
	public GameObject endobj;
	public GameObject selector;
	GameObject selector2;
	public GameObject line;
	GameObject BuildSelection;
	GameObject canvasobj;
	GameObject plane;
	GameObject train;
	public LineRenderer dragline;
	bool MouseRelease = false;
	GameObject cityselect;
	GameObject cityselect2;
	Vector3 mousepos;
	Vector3 yaxis = new Vector3(0,0.11f,0);
	RaycastHit hit;
	Ray ray;
	public LineRenderer TrainLine1;
	public LineRenderer TrainLine2;
	public LineRenderer TrainLine3;
	public LineRenderer TrainLine4;
	public LineRenderer TrainLine5;
	//Sets up LinkedList for rail lines
	//List<Vector3> line1;
	public List<Lines> line1 = new List<Lines>();
	Vector3 tempvector1;
	Vector3 tempvector2;
	bool remove1 = true;
	bool line1created = false;
	bool line2created = false;
	bool line3created = false;
	bool line4created = false;
	bool line5created = false;
	public int numtrains = 0;
	public GameObject Tutorial1;
	public GameObject Tutorial2;
	public GameObject Tutorial3;

	// Use this for initialization
	void Start () {
		//Finding GameObjects in the scene
		canvasobj = GameObject.Find ("Canvas");
		selector2 = GameObject.Find ("Select2");
		plane = GameObject.Find ("plane_sized");
		train = GameObject.Find ("train_sized");
		BuildSelection = canvasobj.transform.Find ("BuildSelection").gameObject;
		line1.Add (new Lines(new Vector3 (0, -50, 0)));


	}
	
	// Update is called once per frame
	void Update () {


		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Raytraced used to selecting cities
		if(Physics.Raycast(ray,out hit)){
			//Selects city first clicked on, stores its location, and puts a marker underneath it.
			if (Input.GetMouseButtonDown(0) && hit.transform.gameObject.tag == "City") {

				cityselect = hit.transform.gameObject;
				selector.transform.position = new Vector3 (cityselect.transform.position.x, cityselect.transform.position.y, cityselect.transform.position.z);
				dragline.SetPosition(0, new Vector3 (cityselect.transform.position.x, cityselect.transform.position.y, cityselect.transform.position.z));

				}
			//Selects city first clicked on, stores its location, and puts a marker underneath it. Then creates line between first and second and opens UI
			if (Input.GetMouseButtonUp(0) && hit.transform.gameObject.tag == "City" ) {
				cityselect2 = hit.transform.gameObject;
				print ("Works3");
				MouseRelease = false;
				dragline.SetPosition(1, new Vector3 (cityselect2.transform.position.x, cityselect2.transform.position.y, cityselect2.transform.position.z));
				selector2.transform.position = new Vector3 (cityselect2.transform.position.x, cityselect2.transform.position.y, cityselect2.transform.position.z);
				BuildSelection.SetActive (true);
				Tutorial1.SetActive(false);
				Tutorial2.SetActive (false);
			}
				

		}


		mousepos = Input.mousePosition;

	}
	//Turns off build menu and removes line from map
	public void BuildOff()
	{
		BuildSelection.SetActive (false);
		dragline.SetPosition(0, new Vector3 (0, -50, 0));
		dragline.SetPosition(1, new Vector3 (0, -50, 0));
		selector.transform.position = new Vector3 (0, -50, 0);
		selector2.transform.position = new Vector3 (0, -50, 0);
	}
	//Spawns plane, orients it towards a city, moves it back and forth between the locations.
	public void QuickPlane(){
		Instantiate (plane, new Vector3(cityselect.transform.position.x, 2, cityselect.transform.position.z),Quaternion.LookRotation(new Vector3(7, 2, 8)));
			
	}
	public void QuickTrain(){
		//creates a train on the spot
		Tutorial3.SetActive(false);
		if (line1created == false) {
			GameObject temptrain;
			temptrain = Instantiate (train, new Vector3(cityselect.transform.position.x, cityselect.transform.position.y, cityselect.transform.position.z),Quaternion.LookRotation(new Vector3(cityselect2.transform.position.x, cityselect2.transform.position.y, cityselect2.transform.position.x)));
			temptrain.name = "Train"+(numtrains+1);
			line1created = true;
			print ("Train created");
			numtrains++;
			GameObject Scripts = GameObject.Find ("Scripts");
			MovingTrains movingtrains = Scripts.GetComponent<MovingTrains> ();
			movingtrains.alltrains.Add (temptrain);
			movingtrains.trainsin = true;
			print (movingtrains.alltrains [0]);
		}
		//sets temporary City selection line
		TrainLine1.SetPosition (0, new Vector3 (cityselect.transform.position.x, cityselect.transform.position.y, cityselect.transform.position.z));
		TrainLine1.SetPosition (1, new Vector3 (cityselect2.transform.position.x, cityselect2.transform.position.y, cityselect2.transform.position.z));
		tempvector1 = new Vector3(cityselect.transform.position.x, cityselect.transform.position.y, cityselect.transform.position.z);
		tempvector2 = new Vector3 (cityselect2.transform.position.x, cityselect2.transform.position.y, cityselect2.transform.position.z);
		//double checks in Vector3s are already in the list
		if (line1.Contains (new Lines(tempvector1)) == true && line1.Contains (new Lines(tempvector2)) == true) {
		} 
		//If the list is empty, sets up the list with new Vector3s
		else if (line1.Count == 1) {
			if (remove1 == true) {
				line1.Clear();
				remove1 = false;
				Debug.Log ("Removed Successfully");
			} 
			print ("Second if worked");
			line1.Add (new Lines (tempvector1));
			line1.Add (new Lines (tempvector2));
			print (line1[0].location);
			print (line1 [1].location);
			if (line1[0].location == tempvector1){
				print ("This somehow works");

				}
		}
		//Appends or preppends Vector3s depending on selected line
		else {
			print ("Else worked");
			//Expands train line Line renderer by one
			TrainLine1.numPositions = TrainLine1.numPositions +1;
			print ("Waypoint added");
			int loops = 0;
			if (line1 [0].location == tempvector1) {
				line1.Insert (0, new Lines(tempvector2));
				print ("Append");
			}
			else if (line1 [0].location == tempvector2) {
				line1.Insert (0, new Lines (tempvector1));
				print ("Append 2");
			}
			else if (line1 [line1.Count - 1].location == tempvector1) {
				line1.Insert (line1.Count, new Lines(tempvector2));
				print ("Preppend");
			}
			else if (line1 [line1.Count - 1].location == tempvector2) {
				line1.Insert (line1.Count, new Lines(tempvector1));
				print ("Preppend 2");
			}
			//Adds contents of list to TrainLine Line Renderer
			while (loops != line1.Count) {
				TrainLine1.SetPosition (loops, line1 [loops].location);
				loops++;
				print ("loopin away: " + loops);
				//Vector3 vectmp1 = (Vector3)line1 [0];
				//Vector3 vectmp2 = (Vector3)line1 [1];
				//Vector3 vectmp3 = (Vector3)line1 [2];
				print (line1[0].location);
				print (line1 [1].location);
				print (line1 [2].location);
			}
		}

	}
}
