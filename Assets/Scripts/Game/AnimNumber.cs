using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimNumber : MonoBehaviour {

	public float speed;

	void Update () {
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, 6f, transform.localPosition.z), speed * Time.deltaTime);
		if (gameObject.transform.localPosition.y >= 6) {
			Destroy (gameObject);
			GameObject.Find ("Han").GetComponent<Health> ().MinusHealth ();
		}
	}
}
