using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectionController : MonoBehaviour {
	[SerializeField]
	public TimeController timeController;
	[SerializeField]
	public GameObject ejectionPrefab;

	private List<SolarEjection> ejections = new List<SolarEjection>();

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		ProjectEjectionsAtTime(timeController.currentTime);
	}

	public void CreateEjection() {
		ejections.Add(new SolarEjection(timeController.currentTime, transform.position, new EjectionComponent[] {
			new EjectionComponent {
				minSpeed = 1,
				maxSpeed = 1.5f,
				maxLateralSpeed = 1,
				direction = new Vector3(1,Random.Range(-0.2f,0.2f),Random.Range(-0.2f,0.2f)).normalized,
				prefab = Instantiate(ejectionPrefab)
			},
			new EjectionComponent {
				minSpeed = 10,
				maxSpeed = 11,
				maxLateralSpeed = 1.5f,
				direction = new Vector3(1,Random.Range(-0.2f,0.2f),Random.Range(-0.2f,0.2f)).normalized,
				prefab = Instantiate(ejectionPrefab)
			},
			new EjectionComponent {
				minSpeed = 100,
				maxSpeed = 150,
				maxLateralSpeed = 3,
				direction = new Vector3(1,Random.Range(-0.2f,0.2f),Random.Range(-0.2f,0.2f)).normalized,
				prefab = Instantiate(ejectionPrefab)
			}
		}));

	}

	public void ProjectEjectionsAtTime(float time) {
		foreach (SolarEjection se in ejections) {
			float relativeTime = time - se.startTime;
			foreach (EjectionComponent eC in se.ejectionComponents) {
				eC.prefab.transform.rotation = Quaternion.Euler(eC.direction+new Vector3(0,0,90));

				eC.prefab.transform.localScale = new Vector3(
					eC.maxLateralSpeed * relativeTime,
					(eC.maxSpeed * relativeTime - eC.minSpeed * relativeTime) / 2,
					eC.maxLateralSpeed * relativeTime
				);

				eC.prefab.transform.position = se.originPoint + eC.direction * relativeTime * (eC.minSpeed + (eC.maxSpeed * relativeTime - eC.minSpeed * relativeTime) / 2);
			}
		}
	}
}
