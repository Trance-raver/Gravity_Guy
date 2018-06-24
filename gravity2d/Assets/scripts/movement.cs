using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	private SpriteRenderer r;
	public float speed;
	public bool lpressed = false;  //left button
	public bool rpressed = false;  //right button
	private Animator anime;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
		anime = GetComponent<Animator> ();
		r = GetComponent<SpriteRenderer> ();
		transform.eulerAngles = new Vector3 (0, 180, 0);

	}



	
	// Update is called once per frame
	void Update () {
		touch script = GetComponent<touch> ();//getting groundcheck from touch script
		if (lpressed == true && script.vertical == false && script.side == 1) {  //if left and horizontal
			//transform.eulerAngles = new Vector3 (0, 180, 0);
			rb.velocity = new Vector2 (-speed, 0);
			r.flipX = true;
		} else if (rpressed == true && script.vertical == false && script.side == 1) {	//right and horizontal
			rb.velocity = new Vector2 (speed, 0);
			//transform.eulerAngles = new Vector3 (0, 0, 0);
			r.flipX = false;
		} else if (lpressed == true && script.vertical == false && script.side == 2) {  //if left and horizontal side up
			//transform.eulerAngles = new Vector3 (0, 0, 180);
			rb.velocity = new Vector2 (-speed, 0);
			r.flipX = false;
		} else if (rpressed == true && script.vertical == false && script.side == 2) {	//right and horizontal side up
			rb.velocity = new Vector2 (speed, 0);
			//transform.eulerAngles = new Vector3 (0, 180, 180);
			r.flipX = true;
		} else if (lpressed == true && script.vertical == true && script.side == 4) {  //left and verticalm side left
			rb.velocity = new Vector2 (0, speed);
			//transform.eulerAngles = new Vector3 (180, 0, -90);
			r.flipX = true;
		} else if (rpressed == true && script.vertical == true && script.side == 4) {	//right and vertical side left
			rb.velocity = new Vector2 (0, -speed);
			//transform.eulerAngles = new Vector3 (0, 0, -90);
			r.flipX = false;
		} else if (lpressed == true && script.vertical == true && script.side == 3) {  //left and vertical side right
			rb.velocity = new Vector2 (0, -speed);
			//transform.eulerAngles = new Vector3 (180, 0, 90);
			r.flipX = true;
		} else if (rpressed == true && script.vertical == true && script.side == 3) {	//right and vertical side right
			rb.velocity = new Vector2 (0, speed);
			//transform.eulerAngles = new Vector3 (0, 0, 90);
			r.flipX = false;
		}
			
	
	}

	public void left()
	{
		lpressed = true;//left
		anime.SetBool("runleft", true);
		anime.SetBool("irunning",true);
	}
	public void right()
	{
		rpressed = true;  // right
		anime.SetBool("runright", true);
		anime.SetBool("irunning",true);

		}
	public void nothing()
	{
		
		lpressed = false;
		rpressed = false;

		anime.SetBool ("runleft", false);
		anime.SetBool("runright",false);
		anime.SetBool("irunning",false);
	}

}
