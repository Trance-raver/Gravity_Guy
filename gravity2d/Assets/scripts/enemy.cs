using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public Transform[] movespots;		//movespots for enemy
	public float speed;
	private int randomspot;
	public float startwaitTime;
	private float waitTime;
	private Animator anime1;



	public LineRenderer lineofsight; // lineofsightofenemy
	public float distance;

	// Use this for initialization
	void Start () {
		waitTime = startwaitTime; // equal
		randomspot = Random.Range(0,movespots.Length); //choosing first random spot
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector2.MoveTowards (transform.position, movespots [randomspot].position, speed * Time.deltaTime); //moving towards the random spot
		if(Vector2.Distance(transform.position,movespots[randomspot].position)< 0.2F) //checking if spot is reaches
		{
			if (waitTime <= 0) { //checking waitTime
				randomspot = Random.Range(0,movespots.Length);  //changing the spot
				waitTime = startwaitTime;
			} else {
				waitTime -= Time.deltaTime;
			}
	}

		RaycastHit2D hitinfo = Physics2D.Raycast(transform.position,transform.up,distance); //RayCast method to find the object in front
		if (hitinfo.collider != null) {  //tofind the hit objec
			lineofsight.SetPosition (1, hitinfo.point);
			if (hitinfo.collider.CompareTag ("player")) { //destroying the player object
				Destroy (hitinfo.collider.gameObject);
			}
		} else {
			lineofsight.SetPosition (1, transform.position + (transform.up) * distance);
		}
		lineofsight.SetPosition (0, transform.position);
				
}
}
