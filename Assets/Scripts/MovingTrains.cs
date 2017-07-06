using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrains : MonoBehaviour {

	public List<GameObject> alltrains;
	public bool trainsin = false;
	//Rigidbody rigid;
	public GameObject test;
	bool linecreated = false;

	// Use this for initialization
	void Start () {
		//rigid = alltrains [0].GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (alltrains.Count != null) {
			GameObject Scripts = GameObject.Find ("Scripts");
			pointclickcreate citylocations = Scripts.GetComponent<pointclickcreate> ();
			//alltrains [0].transform.rotation = Quaternion.LookRotation (new Vector3(citylocations.line1[0].location.x,citylocations.line1[0].location.y, citylocations.line1[0].location.z));
			//rigid.AddForce (transform.forward*5);
			if (citylocations.line1.Count > 0 && alltrains.Count > 0 && linecreated == false) {
				test.transform.position = citylocations.line1 [1].location;
				print ("This is going");
				if (Mathf.Approximately (citylocations.line1 [0].location.x, alltrains [0].transform.position.x)) {
					alltrains [0].transform.LookAt (test.transform);
				}
				alltrains [0].transform.Translate (transform.forward * Time.deltaTime * 0.5f, relativeTo: Space.Self);
				linecreated = true;
			}
			//print (citylocations.line1 [1].location);
			/*if (Mathf.Approximately(citylocations.line1 [1].location.x, alltrains [0].transform.position.x)) {
				test.transform.position = citylocations.line1 [0].location;
				alltrains [0].transform.LookAt (test.transform);
				print ("Location reached");
			}
			*/
		}
	}
}
