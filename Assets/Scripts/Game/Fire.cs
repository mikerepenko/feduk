using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject four;

	private GameObject visibleObject;
	private int number;
	public AudioSource fireSound;

	void Start(){
		if (PlayerPrefs.GetInt ("Choose") == 1)
			number = 1;
		if (PlayerPrefs.GetInt ("Choose") == 2)
			number = 2;
		if (PlayerPrefs.GetInt ("Choose") == 3)
			number = 3;
		if (PlayerPrefs.GetInt ("Choose") == 4)
			number = 4;
	}
		
	public void Push(){
		fireSound.Play ();
		transform.position = new Vector3(transform.position.x, -7f, transform.position.z);
		if(number == 1 && visibleObject == null)
			visibleObject = Instantiate(one, transform.position, transform.rotation);
		if(number == 2 && visibleObject == null)
			visibleObject = Instantiate(two, transform.position, transform.rotation);
		if(number == 3 && visibleObject == null)
			visibleObject = Instantiate(three, transform.position, transform.rotation);
		if(number == 4 && visibleObject == null)
			visibleObject = Instantiate(four, transform.position, transform.rotation);
		Debug.Log ("WEll");
	}
}
