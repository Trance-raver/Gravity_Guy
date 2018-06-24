using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{

	public float maxtime;
	public float minswipedis;

	public bool vertical = false;
	Vector3 startpos;
	Vector3 endpos;

	float starttime;
	float endtime;

	float swipedis;
	float swipetime;
	public int side;



	// Use this for initialization
	void Start ()
	{
		side = 1;
	

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//getting touchinput
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Began) {
				starttime = Time.time;  //start time
				startpos = touch.position;  //start position
		
			} else if (touch.phase == TouchPhase.Ended) {  // when we lift finger up touch ends
				endtime = Time.time;   //end time
				endpos = touch.position;  // end position vector

				swipedis = (endpos - startpos).magnitude;
				swipetime = (endtime - starttime);

				if (swipetime < maxtime && swipedis > minswipedis) {
					swipe ();  //function call
				}


			}
		}
		Rotation ();
	}

	void swipe ()
	{
			
		Vector2 distance = endpos - startpos;
		if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {
			if (distance.y > 0) {
				Debug.Log (" up ");
				Physics2D.gravity = new Vector2 (0f, +39.81f);
				side = 2;
			} else if (distance.y < 0) {
				Physics2D.gravity = new Vector2 (0f, -39.81f);
				Debug.Log ("down");
				side = 1;
			}

			vertical = false;       //top & down grounds movement is horizontal

		} else if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y)) {
			
			if (distance.x > 0) {
				Physics2D.gravity = new Vector2 (39.81f, 0);
				Debug.Log ("right");
				side = 3;
			} else if (distance.x < 0) {
				Physics2D.gravity = new Vector2 (-39.81f, 0);
				Debug.Log ("left");
				side = 4;
			}

			vertical = true;  //left & right ground movement is vertical
		}
	}
	//for changing the player angle
	void Rotation()
	{
		if (side == 2) {
			transform.eulerAngles = new Vector3 (0, 0, 180);
		} else if (side == 1) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
		} else if (side == 4) {
			transform.eulerAngles = new Vector3 (0, 0, -90);
		} else if (side == 3) {
			transform.eulerAngles = new Vector3 (0, 0, 90);
		}
			
	}
			
}