using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHider : MonoBehaviour {
	[SerializeField]
	public GameObject canvas;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.H)) {
			canvas.SetActive(!canvas.activeSelf);
		}
	}
}
