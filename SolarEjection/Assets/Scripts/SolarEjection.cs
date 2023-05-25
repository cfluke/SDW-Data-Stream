using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EjectionComponent {
	public float minSpeed;
	public float maxSpeed;
	public float maxLateralSpeed;
	public Vector3 direction;

	public GameObject prefab;
}

public class SolarEjection {
	public float startTime;
	public Vector3 originPoint;
	public EjectionComponent[] ejectionComponents;

	public SolarEjection(float start, Vector3 origin, EjectionComponent[] components) {
		startTime = start;
		originPoint = origin;
		ejectionComponents = components;	
	}
}
