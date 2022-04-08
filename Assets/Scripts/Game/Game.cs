using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public float speed;
	private int width = 1;
	public float jump = 0;
	public bool isJump;
	public GameObject blood;
	private int recordCount;
	private int rund;
	public Text score;
	public Hp hp;

	//Звуки
	public AudioSource bol1, bol2;
	public AudioSource music;

	Rigidbody2D man;

	//Объекты для Fine панели
	public GameObject reviews;
	public AudioSource fineSound;
	public Ads ads;
	public GameObject pushBtn;
	public GameObject shopBtn;
	public Text record;
	public GameObject fine;
	public Text top;
	public GameObject notification;
	public Health health;

	//Объекты для Gameover панели
	public AudioSource krik;
	public GameObject gameover;

	void Start(){
		man = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
		recordCount ++;
		score.text = recordCount.ToString ();
	}
	void Update () {
		if(width == 1)
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(-7f, transform.localPosition.y, transform.localPosition.z), speed * Time.deltaTime);
		if(width == 2)
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(7f, transform.localPosition.y, transform.localPosition.z), speed * Time.deltaTime);
		if (gameObject.transform.localPosition.x >= 7f)
			width = 1;
		if (gameObject.transform.localPosition.x <= -7f)
			width = 2;
		if (isJump) {
			man.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
		}
		if(gameObject.transform.localPosition.y >= 1.5f)
			isJump = false;
		if(rund == 1)
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.position.x, 2.7F, transform.localPosition.z), speed * Time.deltaTime);
		else if(rund == 2)
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.position.x, 2.0F, transform.localPosition.z), speed * Time.deltaTime);
		else if(rund == 3)
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.position.x, 0.5F, transform.localPosition.z), speed * Time.deltaTime);
		else if(rund == 4)
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.position.x, -1.0F, transform.localPosition.z), speed * Time.deltaTime);
		
	}
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "up")
			isJump = true;
	}
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "fire") {
			blood.SetActive (true);
			Destroy (c.gameObject);
			//health.MinusHealth ();
			//Минус популярность
			hp.MinusHp();
			rund = Random.Range (1, 5);
			switch (rund) {
			case 1:
				bol1.Play ();
				break;
			case 2:
				bol2.Play ();
				break;
			case 3:
				bol1.Play ();
				break;
			case 4:
				bol2.Play ();
				break;
			}
		}
	}
	public void SpeedOne(){
		speed = 10;
	}
	public void SpeedTwo(){
		speed = 15;
	}
	public void SpeedThree(){
		speed = 20;
	}
	public void GameOver(){
		gameover.SetActive (true);
		pushBtn.SetActive (false);
		shopBtn.SetActive (false);
		ads.StartInterstitial ();
		gameObject.SetActive (false);
		krik.Play ();
		music.Pause ();
	}
	public void Fine(){
		if(PlayerPrefs.GetInt ("Record") > recordCount || PlayerPrefs.GetInt ("Record") == 0)
			PlayerPrefs.SetInt ("Record", recordCount);
		music.Pause ();
		fine.SetActive (true);
		record.text = "Время: " + recordCount.ToString () + "сек";
		pushBtn.SetActive (false);
		shopBtn.SetActive (false);
		ads.StartInterstitial ();
		gameObject.SetActive (false);
		fineSound.Play ();
		PlayerPrefs.SetInt ("Money",PlayerPrefs.GetInt ("Money") + 100);
		//Отзыв
		if (PlayerPrefs.GetInt ("Reviews") <= 3) {
			PlayerPrefs.SetInt ("Reviews", PlayerPrefs.GetInt ("Reviews") + 1);
			if (PlayerPrefs.GetInt ("Reviews") == 3) {
				reviews.SetActive (true);
			}
		}
		//Рекорд
		int topNow = (PlayerPrefs.GetInt("Record"));
		if (topNow < 17402) {
			int[] mas = new int[50] {
				77,
				269,
				540,
				604,
				740,
				850,
				985,
				1001,
				1002,
				1123,
				1332,
				1523,
				1931,
				1993,
				2123,
				2321,
				2521,
				2724,
				2900,
				3002,
				3021,
				3120,
				3404,
				3707,
				3918,
				4002,
				4023,
				4321,
				4508,
				4721,
				5043,
				5221,
				5704,
				6234,
				6504,
				6894,
				7121,
				7409,
				7893,
				8432,
				8700,
				9021,
				10321,
				11003,
				12392,
				13503,
				15203,
				17012,
				17402,
				topNow
			};

			//Сортировка массива
			for (int i = 0; i < 50 - 1; i++) {
				for (int j = 0; j < 50 - 1; j++) {
					if (mas [j] > mas [j + 1]) {
						int tmp = mas [j];
						mas [j] = mas [j + 1];
						mas [j + 1] = tmp;
					}
				}
			}

			for (int i = 0; i < 50 - 1; i++) {
				if (mas [i] == topNow) {
					int topPosition = i + 1;
					top.text = "Вы на " + topPosition.ToString () + " месте" + "\r\n" + "в топе";
					notification.SetActive (true);
				}
			}
		}

	}
}
