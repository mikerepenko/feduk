using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI.Image;
using UnityEngine.UI;

public class Change : MonoBehaviour {

	public Sprite one, two, three, four;

	void Start () {
		if(PlayerPrefs.GetInt ("Choose") == 1)
			this.GetComponent<Image> ().sprite = one;
		if(PlayerPrefs.GetInt ("Choose") == 2)
			this.GetComponent<Image> ().sprite = two;
		if(PlayerPrefs.GetInt ("Choose") == 3)
			this.GetComponent<Image> ().sprite = three;
		if(PlayerPrefs.GetInt ("Choose") == 4)
			this.GetComponent<Image> ().sprite = four;
	}
}
