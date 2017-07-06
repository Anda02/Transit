using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bacnknforth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-transform.right * Time.deltaTime * 1.0f, relativeTo: Space.World);
	}
}
