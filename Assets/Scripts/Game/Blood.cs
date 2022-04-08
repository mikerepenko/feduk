using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

	private float timer;
	void FixedUpdate () {
		timer += 0.05f;
		if (timer > 2) {
			timer = 0;
			gameObject.SetActive (false);
		}
	}
}
