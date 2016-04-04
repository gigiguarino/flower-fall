using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// things to add:
// leaderboard
// way to keep track of high scores
// play again button


public class playerScript : MonoBehaviour 
{
	private int health;
	private int points;
	private int count;
	private bool done;
	private bool gameStart;

	public float speed;

	// health point
	public GameObject healthPoint;
	private Vector3 healthPos;
	bool healthDropped;

	// positive points
	public GameObject posPoint1;
	public GameObject posPoint2;
	public GameObject posPoint3;
	public GameObject posPoint4;
	public GameObject posPoint5;
	public GameObject posPoint6;
	public GameObject posPoint7;
	private Vector3 pos1;
	private Vector3 pos2;
	private Vector3 pos3;
	private Vector3 pos4;
	private Vector3 pos5;
	private Vector3 pos6;
	private Vector3 pos7;


	// negative points
	public GameObject negPoint1;
	public GameObject negPoint2;
	public GameObject negPoint3;
	public GameObject negPoint4;
	public GameObject negPoint5;
	public GameObject negPoint6;
	public GameObject negPoint7;
	public Vector3 neg1;
	private Vector3 neg2;
	private Vector3 neg3;
	private Vector3 neg4;
	private Vector3 neg5;
	private Vector3 neg6;
	private Vector3 neg7;

	// players
	public GameObject player;
	public Sprite upPlayer;
	public Sprite downPlayer;
	public Sprite leftPlayer;
	public Sprite rightPlayer;

	// texts
	public Text scoreAndHealthText;
	public Text negHealthText;
	public Text posPointsText;
	public Text gameOverText;
	public Text clickToBegin;
	
	void Start () 
	{
		// player starts off with 10 health
		// the score is 0
		gameStart = false;
		health = 10;
		points = 0;
		count = 0;
		//titleText.text = "";
		//negHealthText.text = "";
		//posPointsText.text = "";
		gameOverText.text = "";
		clickToBegin.text = "CLICK ANYWHERE TO BEGIN.";
		scoreAndHealthText.text = "Score: 0   Health: 10";
		done = false;
		neg1 = negPoint1.transform.position;
		neg2 = negPoint2.transform.position;
		neg3 = negPoint3.transform.position;
		neg4 = negPoint4.transform.position;
		neg5 = negPoint5.transform.position;
		neg6 = negPoint6.transform.position;
		neg7 = negPoint7.transform.position;
		pos1 = posPoint1.transform.position;
		pos2 = posPoint2.transform.position;
		pos3 = posPoint3.transform.position;
		pos4 = posPoint4.transform.position;
		pos5 = posPoint5.transform.position;
		pos6 = posPoint6.transform.position;
		pos7 = posPoint7.transform.position;
		healthPos = healthPoint.transform.position;
		healthDropped = false;
	}
	
	void gameOver()
	{
		Destroy (this.gameObject);
		string s = points.ToString ();
		gameOverText.text = "GAME OVER.\n Your Score: " + s;
		scoreAndHealthText.text = "";
		done = true;
	}
	
	void updateScore()
	{
		string s = points.ToString ();
		string s1 = health.ToString ();
		
		if (points <= 0) 
		{
			scoreAndHealthText.text = "Score: 0   Health: " + s1;
			points = 0;
		} 
		
		else 
		{
			if (!done)
			{
				scoreAndHealthText.text = "Score: " + s + "   Health: " + s1;
			}
		}
	}
	
	void updateHealth()
	{
		string s = health.ToString ();
		string s1 = points.ToString ();

		if (health <= 0) 
		{
			scoreAndHealthText.text = "Score: " + s1 + "   Health: 0";
			health = 0;
			gameOver ();
		} 
		
		else 
		{
			scoreAndHealthText.text = "Score: " + s1 + "   Health: " + s;
		}
	}
	
	void addPoints()
	{
		// if the player collects a flower
		// health stays the same
		// points increase by 5
		
		points += 5;
		updateScore ();
	}
	
	void negHealth()
	{
		// if the player collects a skull
		// health decreases by 2
		// points decrease by 1
		
		health -= 2;
		points -= 1;
		
		updateHealth();
		updateScore ();
	}

	void addHealth()
	{
		// if the player collects a health flower

		health += 5;
		updateHealth ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0)) 
		{
			gameStart = true;
			clickToBegin.text = "";
		}

		// points falling
		if (!done && gameStart) 
		{
			generation ();
		}

		// player's movement --------------------------------

		Vector3 position = player.transform.position;

		
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			player.GetComponent<SpriteRenderer>().sprite = leftPlayer;
			position.x -= speed;
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			player.GetComponent<SpriteRenderer>().sprite = rightPlayer;
			position.x += speed;
		}
		
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			player.GetComponent<SpriteRenderer>().sprite = upPlayer;
			position.y += speed;
		}
		
		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			player.GetComponent<SpriteRenderer>().sprite = downPlayer;
			position.y -= speed;
		}
		
		// if x < -2.21
		// if y > 1.76
		// if x > 2.22
		// if y < -0.95

		if (position.x < -2.21f)
		{
			position.x = -2.21f;
		}

		if (position.y > 1.76f)
		{
			position.y = 1.76f;
		}

		if (position.x > 2.22f)
		{
			position.x = 2.22f;
		}

		if (position.y < -0.95f)
		{
			position.y = -0.95f;
		}

		player.transform.position = position;

		//-------------------------------------------------


	}




	// START A SKULL TO FALL

	void activateNegPoint(int i)
	{
		Rigidbody2D rb;
		
		if (i == 1)
		{
			rb = negPoint1.GetComponent<Rigidbody2D>();
			rb.WakeUp();
			negPoint1 = Instantiate (negPoint1, neg1, Quaternion.identity) as GameObject;
		}
		
		else if (i == 2)
		{
			rb = negPoint2.GetComponent<Rigidbody2D>();
			rb.WakeUp();
			negPoint2 = Instantiate (negPoint2, neg2, Quaternion.identity) as GameObject;
		}
		
		else if (i == 3)
		{
			rb = negPoint3.GetComponent<Rigidbody2D>();
			rb.WakeUp();
			negPoint3 = Instantiate (negPoint3, neg3, Quaternion.identity) as GameObject;
		}
		
		else if (i == 4)
		{
			rb = negPoint4.GetComponent<Rigidbody2D>();
			rb.WakeUp();
			negPoint4 = Instantiate (negPoint4, neg4, Quaternion.identity) as GameObject;
		}
		
		else if (i == 5)
		{
			rb = negPoint5.GetComponent<Rigidbody2D>();
			rb.WakeUp();
			negPoint5 = Instantiate (negPoint5, neg5, Quaternion.identity) as GameObject;
		}
		
		else if (i == 6)
		{
			rb = negPoint6.GetComponent<Rigidbody2D>();
			rb.WakeUp();
			negPoint6 = Instantiate (negPoint6, neg6, Quaternion.identity) as GameObject;
		}
		
		else
		{
			rb = negPoint7.GetComponent<Rigidbody2D>();
			rb.WakeUp();
			negPoint7 = Instantiate (negPoint7, neg7, Quaternion.identity) as GameObject;
		}
	}



	// START A FLOWER TO FALL

	void activatePosPoint(int i)
	{
		Rigidbody2D rb;

		if (i == 1) 
		{
			rb = posPoint1.GetComponent<Rigidbody2D> ();
			rb.WakeUp ();
			posPoint1 = Instantiate (posPoint1, pos1, Quaternion.identity) as GameObject;
		} 

		else if (i == 2) 
		{
			rb = posPoint2.GetComponent<Rigidbody2D> ();
			rb.WakeUp ();
			posPoint2 = Instantiate (posPoint2, pos2, Quaternion.identity) as GameObject;
		} 

		else if (i == 3) 
		{
			rb = posPoint3.GetComponent<Rigidbody2D> ();
			rb.WakeUp ();
			posPoint3 = Instantiate (posPoint3, pos3, Quaternion.identity) as GameObject;
		} 

		else if (i == 4) 
		{
			rb = posPoint4.GetComponent<Rigidbody2D> ();
			rb.WakeUp ();
			posPoint4 = Instantiate (posPoint4, pos4, Quaternion.identity) as GameObject;
		} 

		else if (i == 5) 
		{
			rb = posPoint5.GetComponent<Rigidbody2D> ();
			rb.WakeUp ();
			posPoint5 = Instantiate (posPoint5, pos5, Quaternion.identity) as GameObject;
		} 

		else if (i == 6) 
		{
			rb = posPoint6.GetComponent<Rigidbody2D> ();
			rb.WakeUp ();
			posPoint6 = Instantiate (posPoint6, pos6, Quaternion.identity) as GameObject;
		} 

		else if (i == 7) 
		{
			rb = posPoint7.GetComponent<Rigidbody2D> ();
			rb.WakeUp ();
			posPoint7 = Instantiate (posPoint7, pos7, Quaternion.identity) as GameObject;
		} 

		else 
		{
			rb = healthPoint.GetComponent<Rigidbody2D>();
			rb.WakeUp ();
			healthPoint = Instantiate (healthPoint, healthPos, Quaternion.identity) as GameObject;
		}
	}




	// POINT GENERATION

	void generation()
	{
		int r1, r2, r3, r4, r5;
		bool secondHealth = false;

		if (points >= 400 & healthDropped == false)
		{
			// drops a health point
			activatePosPoint (8);
			healthDropped = true;
			secondHealth = true;
		}

		if (points >= 700 && secondHealth == true) 
		{
			// turns healthDropped to false
			// so next round will drop a health point
			healthDropped = false;
			secondHealth = false;
		}


		if (count < 500) 
		{
			if (count % 100 == 0) 
			{
				r1 = Random.Range (1, 8);
				activatePosPoint (r1);
			}
		} 

		else if (count < 1500) 
		{
			if (count % 100 == 0) 
			{
				r1 = Random.Range (1, 8);
				r2 = Random.Range (1, 8);
				r3 = Random.Range (1, 8);
				activatePosPoint (r1);
				activatePosPoint (r2);
				activateNegPoint (r3);
			}
		} 

		else if (count < 3000) 
		{
			if (count % 100 == 0) 
			{
				r1 = Random.Range (1, 8);
				r2 = Random.Range (1, 8);
				r3 = Random.Range (1, 8);
				r4 = Random.Range (1, 8);

				activatePosPoint (r1);
				activatePosPoint (r2);
				activatePosPoint (r3);
				activateNegPoint (r4);
			}
		} 

		else if (count < 10000) 
		{
			if (count % 50 == 0) 
			{
				r1 = Random.Range (1, 8);
				r2 = Random.Range (1, 8);
				r3 = Random.Range (1, 8);
				r4 = Random.Range (1, 8);

				activatePosPoint (r1);
				activatePosPoint (r2);
				activateNegPoint (r3);
				activateNegPoint (r4);
			}
		} 

		else if (count < 20000) 
		{
			if (count % 50 == 0) 
			{
				r1 = Random.Range (1, 8);
				r2 = Random.Range (1, 8);
				r3 = Random.Range (1, 8);
				r4 = Random.Range (1, 8);
				r5 = Random.Range (1, 8);

				activatePosPoint (r1);
				activatePosPoint (r2);
				activatePosPoint (r3);
				activateNegPoint (r4);
				activateNegPoint (r5);
			}
		} 

		else if (count < 60000) 
		{
			if (count % 25 == 0) 
			{
				r1 = Random.Range (1, 8);
				r2 = Random.Range (1, 8);
				r3 = Random.Range (1, 8);
				r4 = Random.Range (1, 8);
				r5 = Random.Range (1, 8);

				activatePosPoint (r1);
				activatePosPoint (r2);
				activateNegPoint (r3);
				activateNegPoint (r4);
				activateNegPoint (r5);
			}
		} 

		else if (count < 100000) 
		{
			if (count % 25 == 0) 
			{
				r1 = Random.Range (1, 8);
				r2 = Random.Range (1, 8);
				r3 = Random.Range (1, 8);
				r4 = Random.Range (1, 8);
				r5 = Random.Range (1, 8);
				
				activatePosPoint (r1);
				activatePosPoint (r2);
				activateNegPoint (r3);
				activateNegPoint (r4);
				activateNegPoint (r5);
			}
		} 

		else 
		{
			if (count % 10 == 0) 
			{
				r1 = Random.Range (1, 8);
				r2 = Random.Range (1, 8);
				r3 = Random.Range (1, 8);
				r4 = Random.Range (1, 8);
				r5 = Random.Range (1, 8);
				
				activatePosPoint (r1);
				activatePosPoint (r2);
				activateNegPoint (r3);
				activateNegPoint (r4);
				activateNegPoint (r5);
			}
		}

		count += 1;
	}




	// POINT COLLECTION

	void OnTriggerEnter2D (Collider2D other)
	{ 
		if (other.gameObject.CompareTag ("posPoint1") ||
			other.gameObject.CompareTag ("posPoint2") ||
			other.gameObject.CompareTag ("posPoint3") ||
			other.gameObject.CompareTag ("posPoint4") ||
			other.gameObject.CompareTag ("posPoint5") ||
			other.gameObject.CompareTag ("posPoint6") ||
			other.gameObject.CompareTag ("posPoint7")) 
		{
			Destroy (other.gameObject);
			addPoints ();
		} 

		else if (other.gameObject.CompareTag ("negPoint1") ||
			other.gameObject.CompareTag ("negPoint2") ||
			other.gameObject.CompareTag ("negPoint3") ||
			other.gameObject.CompareTag ("negPoint4") ||
			other.gameObject.CompareTag ("negPoint5") ||
			other.gameObject.CompareTag ("negPoint6") ||
			other.gameObject.CompareTag ("negPoint7")) 
		{
			Destroy (other.gameObject);
			negHealth ();
		} 

		else if (other.gameObject.CompareTag ("health")) 
		{
			Destroy(other.gameObject);
			addHealth ();
		}
	}
}