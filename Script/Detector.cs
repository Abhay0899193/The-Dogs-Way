using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector : MonoBehaviour {

	private Rigidbody rb;

	public float speed = 3f;
	public GM gm;
	public Generator gen;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector3 (0, 0, speed);
	}

	void OnTriggerEnter(Collider o)
	{
		if (o.transform.CompareTag ("PickUpp")) 
		{
			Debug.Log ("GameOver");
			gen.stope = true;
			gm.Save ();
			SceneManager.LoadScene (1);
		}

	}
}
