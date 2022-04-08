using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnGame : MonoBehaviour {

	public Text money;
	public Text score;
	public GameObject rewiews;

	void Update ()
	{
		money.text = PlayerPrefs.GetInt ("Money").ToString ();

	}
	public void Shop ()
	{
		GameObject.Find ("Click").GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene ("Main");
	}
	public void Exit(){
		Application.Quit ();
	}
	public void Replay()
	{
		GameObject.Find ("Click").GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene ("Game");
	}
	public void SoundClick(){
		GameObject.Find ("Click").GetComponent<AudioSource> ().Play ();
	}
	public void Review(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.newsgames.pinkwine&hl=ru");
		PlayerPrefs.SetInt ("Money",PlayerPrefs.GetInt ("Money") + 1000);
		rewiews.SetActive (false);
	}
}
