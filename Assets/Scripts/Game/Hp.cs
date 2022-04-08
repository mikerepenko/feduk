using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI.Image;

public class Hp : MonoBehaviour {

	private float count;
	private float max = 300;
	public Game game;

	void Start () {
		PlayerPrefs.SetFloat("Hp", 130);
		count = PlayerPrefs.GetFloat("Hp");
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 20);
	}
	void FixedUpdate(){
		count += 0.2f;
		if (count > max) {
			count = max;
		}
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 20);
		gameObject.GetComponent<Image>().color = new Color32(138,6,255,255);

		if (count > 150)
			game.SpeedOne ();
		else if (count > 80)
			game.SpeedTwo ();
		else if (count > 5)
			game.SpeedThree ();
	}
	public void MinusHp(){
		count -= 30;
		if (count < 5) {
			count = 5;
			game.Fine ();
			gameObject.SetActive (false);
		}
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 20);
		gameObject.GetComponent<Image>().color = new Color32(255,0,5,255);
	}
}
