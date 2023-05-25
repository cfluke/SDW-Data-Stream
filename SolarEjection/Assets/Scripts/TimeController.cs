using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {
	[SerializeField]
	public Slider timeScale;

	public float currentTime = 0.0f;
	// Start is called before the first frame update
	void Start() {

	}

	void FixedUpdate() {
		currentTime += timeScale.value * Time.fixedDeltaTime;
		Debug.Log(currentTime);
	}
}
