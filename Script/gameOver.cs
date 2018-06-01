using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {


	public GM gm;

	// Use this for initialization
	void Start () {
		gm.Load ();
	}

	public void Retry()
	{
		SceneManager.LoadScene (0);
	}

}
