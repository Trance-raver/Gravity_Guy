using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	private SpriteRenderer r;
	public float speed;
	public bool lpressed = false;  //left button
	public bool rpressed = false;  //right button
	private Animator anime;

	private bool isgrounded;
	public Transform ground;
	public float checkradius;
	public LayerMask isGround;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
		anime = GetComponent<Animator> ();
		r = GetComponent<SpriteRenderer> ();
		transform.eulerAngles = new Vector3 (0, 180, 0);

	}



	
	// Update is called once per frame
	void FixedUpdate () {
		isgrounded = Physics2D.OverlapCircle (ground.position, checkradius, isGround);


		touch script = GetComponent<touch> ();//getting groundcheck from touch script


		if (lpressed == true && script.vertical == false && script.side == 1 && isgrounded == true) {  //if left and horizontal
			rb.velocity = new Vector2 (-speed, 0);
			r.flipX = true;
		} else if (rpressed == true && script.vertical == false && script.side == 1 && isgrounded == true) {	//right and horizontal
			rb.velocity = new Vector2 (speed, 0);
			r.flipX = false;
		} else if (lpressed == true && script.vertical == false && script.side == 2 && isgrounded == true) {  //if left and horizontal side up

			rb.velocity = new Vector2 (-speed, 0);
			r.flipX = false;
		} else if (rpressed == true && script.vertical == false && script.side == 2 && isgrounded == true) {	//right and horizontal side up
			rb.velocity = new Vector2 (speed, 0);

			r.flipX = true;
		} else if (lpressed == true && script.vertical == true && script.side == 4 && isgrounded == true) {  //left and verticalm side left
			rb.velocity = new Vector2 (0, speed);

			r.flipX = true;
		} else if (rpressed == true && script.vertical == true && script.side == 4 && isgrounded == true) {	//right and vertical side left
			rb.velocity = new Vector2 (0, -speed);
	
			r.flipX = false;
		} else if (lpressed == true && script.vertical == true && script.side == 3 && isgrounded == true) {  //left and vertical side right
			rb.velocity = new Vector2 (0, -speed);

			r.flipX = true;
		} else if (rpressed == true && script.vertical == true && script.side == 3 && isgrounded == true) {	//right and vertical side right
			rb.velocity = new Vector2 (0, speed);

			r.flipX = false;
		}
			
	
	}

	public void left()
	{
		Debug.Log (isgrounded);	
		if (isgrounded == true)
		{
			
		lpressed = true;//left
		anime.SetBool("irunning",true);
	}
	}
	public void right()
	{
		Debug.Log (isgrounded);	
		if(isgrounded == true)
		{
		rpressed = true;  // right
		anime.SetBool("irunning",true);

		}
}
	public void nothing()
	{
		
		lpressed = false;
		rpressed = false;
		anime.SetBool("irunning",false);
	}

}
