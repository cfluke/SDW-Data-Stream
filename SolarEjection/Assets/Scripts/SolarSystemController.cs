using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemController : MonoBehaviour {
	[SerializeField]
	Transform Sun;
	[SerializeField]
	Transform Earth;

	public long time;

	public bool heliocentric = true;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	private Vector3 GetEarthPosition(long time) {
		Vector3 ret = new Vector3();



		return ret;
	}
}