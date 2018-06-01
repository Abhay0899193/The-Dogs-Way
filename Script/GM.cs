using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public Text scoreText;
	public float score = 0;
	public Text boneText;
	public float bone = 0;


	void Start()
	{
		
	}

	public void Load()
	{
		float[] loadedStats = SaveLoad.LoadPlayer ();
		score = loadedStats [0];
		bone = loadedStats [1];
		scoreText.text = score.ToString ();
		boneText.text = bone.ToString ();	
	}

	public void Score(float value)
	{
		score += value;
		scoreText.text = score.ToString ();

	}

	public void Bones(float value)
	{
		bone += value;
		boneText.text = bone.ToString ();

	}

	public void Save()
	{
		SaveLoad.SavePlayer (this);
	}


}
