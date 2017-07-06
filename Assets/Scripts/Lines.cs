using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines {

	public Vector3 location;

	public Lines(Vector3 newlocation){
		location = newlocation;
	}

	public Vector3 getLocation () {
		return location;
	}
}
