using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public float speed = 3f;
	public KeyCode L;
	public KeyCode R;
	public int lanNo = 2;
	public GM gm;

	private Rigidbody rb;
	private Vector3 fp;   
	private Vector3 lp;  
	private float dragDistance;  


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		dragDistance = Screen.height * 15 / 200;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector3 (0, 0, speed);

		#if UNITY_ANDROID

		if (Input.touchCount == 1) 
		{
			Touch touch = Input.GetTouch(0); 
			if (touch.phase == TouchPhase.Began) 
			{
				fp = touch.position;
				lp = touch.position;
			}
			else if (touch.phase == TouchPhase.Moved) 
			{
				lp = touch.position;
			}
			else if (touch.phase == TouchPhase.Ended) 
			{
				lp = touch.position;  

				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
				{
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
					{  
						if ((lp.x > fp.x)) 
						{   
							float j = lanNo - 1;
							transform.position = new Vector3 (j, 1, transform.position.z);
							lanNo += 1;
						}
						else
						{   
							float i = lanNo - 3;
							transform.position = new Vector3 (i, 1, transform.position.z);
							lanNo -= 1;
						}
					}
					else
					{  
						if (lp.y > fp.y)  
						{   
							Debug.Log("Up Swipe");
						}
						else
						{   
							Debug.Log("Down Swipe");
						}
					}
				}
				else
				{   
					Debug.Log("Tap");
				}
			}
		}

		#endif


		if (Input.GetKeyDown (L) && lanNo > 1) {
		
			float i = lanNo - 3;
			transform.position = new Vector3 (i, 1, transform.position.z);
			lanNo -= 1;
		}

		if (Input.GetKeyDown (R) && lanNo < 3) {
			float j = lanNo - 1;
			transform.position = new Vector3 (j, 1, transform.position.z);
			lanNo += 1;
		}
	}


	void OnTriggerEnter(Collider o)
	{
		if (o.GetComponent<Collider>().CompareTag ("PickUpp")) 
		{
			Destroy (o.gameObject);
			gm.Bones (5);
				}
	}
		
}


