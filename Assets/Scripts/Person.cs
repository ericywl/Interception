using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

	private int p1Suspicion;
	private int p2Suspicion;
	private Vector3 location;

	public void AddP1Suspicion() {
		p1Suspicion++;
	}

	public int GetP1Suspicion() {
		return p1Suspicion;
	}

	public void AddP2Suspicion() {
		p2Suspicion++;
	}

	public int GetP2Suspicion() {
		return p2Suspicion;
	}
}
