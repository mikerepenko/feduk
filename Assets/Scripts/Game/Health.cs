using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour {

	private float count = 160;
	private float deltaCount;
	//public GameObject gameOver;
	private float max = 160;
	public Game game;

	void Start () {
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 20);
	}
	void Update(){
		count += 0.1f;
		if (count > max)
			count = max;
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 20);
		//Проверка для скорости
		if (count >= 95)
			game.SpeedOne ();
		else if (count >= 30)
			game.SpeedTwo ();
		else if (count >= -50)
			game.SpeedThree ();
			
	}
	public void MinusHealth(){
		deltaCount = 120;
		count = count - deltaCount;
		if (count < -50) {
			count = -50;
			game.GameOver ();
		}
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 20);
		gameObject.GetComponent<Image>().color = new Color32(255,0,5,255);
	}
}
