using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour {

	// Use this for initialization

	public  void Loadlevel()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
