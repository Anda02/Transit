using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class citymanagementconstructor {

	public string cityname;
	public Vector3 citylocation;
	public string citysize;
	public int citizenstolarge;
	public int citizenstomed;
	public int citizenstosmall;
	public int trainnumber;
	public string linecolor;
	public int planenumber;
	public string planesrtcity;
	public string planeendcity;
	public int passengernum;
	public string passengerlocation;
	public string passengerdest;
	public int passengertrain;
	public int passengerplane;
	public Vector3 location;

	public void CityConstructor(string newcityname, Vector3 newcitylocation, string newcitysize, int newcitizenstolarge, int newcitizenstomed, int newcitizenstosmall){
		cityname = newcityname;
		citylocation = newcitylocation;
		citysize = newcitysize;
		/*
		citizenstolarge = newcitizenstolarge;
		citizenstomed = newcitizenstomed;
		citizenstosmall = newcitizenstosmall;
		*/
	}

	public void TrainConstructor(int newtrainnumber, string newlinecolor){
		trainnumber = newtrainnumber;
		linecolor = newlinecolor;
	}

	public void AirConstructor(int newplanenumber, string newplanesrtcity, string newplaneendcity){
		planenumber = newplanenumber;
		planesrtcity = newplanesrtcity;
		planeendcity = newplaneendcity;
	}

	public void PassConstructor(int newpassengernum, string newpassengerlocation, string newpassengerdest, int newpassengertrain, int newpassengerplane){
		passengernum = newpassengernum;
		passengerlocation = newpassengerlocation;
		passengerdest = newpassengerdest;
		passengertrain = newpassengertrain;
		passengerplane = newpassengerplane;
	}

}
