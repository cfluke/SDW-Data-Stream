using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfInfluence : MonoBehaviour {
	[SerializeField]
	float timeOfEvent;
	[SerializeField]
	float fastestSpeed;
	[SerializeField]
	float slowestSpeed;
	[SerializeField]
	float lateralSpeed;

	[SerializeField]
	Vector3 origin;
	[SerializeField]
	Vector3 direction;

	public void Start() {
		timeOfEvent = Time.realtimeSinceStartup;
	}

	public void Update() {
		projectTime(Time.realtimeSinceStartup);
	}

	/***
	 * Sets the objects position to where it would be at a given time
	 */
	public void projectTime(float time) {
		if (time < timeOfEvent) {
			//SetActive(false);
			return;
		}

		//SetActive(true);

		float dT = time - timeOfEvent;

		// Distance of point furtherst from the sun
		float furthestPoint = fastestSpeed * dT;
		// Distance of point closest to the sun
		float closestPoint = slowestSpeed * dT;
		float radius = lateralSpeed * dT;

		float height = furthestPoint - closestPoint;

		transform.localScale = new Vector3(radius * 2, height/2, radius * 2);

		transform.position = origin + Vector3.Normalize(direction) * (height / 2 + closestPoint);
		transform.rotation = Quaternion.Euler(direction + new Vector3(90, 0, 90));
	}
}
