using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public float Distance = 28f;
	public float maxDistance = 300f;
	public float addition = 120;
	public GameObject sets;
	public GameObject pickUp;
	public int Chance;
	public CameraMovement cm;
	public GameObject Player;
	public Detector dt;
	public float incSpee = 25f;
	public bool stope = false;
	public GM gm;

	private MovePlayer mp;
	private GameObject[] go;
	private int count = 0;
	private int i = 0;


	// Use this for initialization
	void Start () {
		mp = Player.GetComponent<MovePlayer> ();
		go = new GameObject[100];
	}

	// Update is called once per frame
	void Update () {

		if (Distance < maxDistance) {

			Chance = Random.Range (0, 10);
			go[count] = Instantiate (sets, new Vector3 (0, 0, Distance), sets.transform.rotation) as GameObject;
			if (count >= 99) {
				count = 0;
			} 
			else
			{
				count++;
			}
			if (Chance < 3) 
			{
				Instantiate (pickUp, new Vector3 (-1, 1, Distance), sets.transform.rotation);
			}
			else if (Chance > 7) 
			{
				Instantiate (pickUp, new Vector3 (1, 1, Distance), sets.transform.rotation);
			}
			else if (Chance == 3 || Chance == 7) 
			{
				Instantiate (pickUp, new Vector3 (0, 1, Distance), sets.transform.rotation);
			}


			Distance += 6f;

		}

		if (Player.transform.position.z > incSpee) 
		{
			incSpee *= 2;
			cm.speed += 2f;
			dt.speed += 2f;
			mp.speed += 2f;

		}

		if (!stope) 
		{
			showScore ();
		}
		else
		{
			cm.speed = 0;
			dt.speed = 0;
			mp.speed = 0;
		}

		if (Distance - Player.transform.position.z < addition) 
		{
			maxDistance += addition;
			clear ();
		}

	}

	void clear()
	{
		int j = i;
		for (; i <= j + 20 && i<100; i++) 
		{
			Destroy (go [i]);
		}
		if (i >= 99) 
		{
			i = 0;
		}
	}

	void showScore()
	{
		gm.Score ((int)(cm.speed/2));
	}
}
