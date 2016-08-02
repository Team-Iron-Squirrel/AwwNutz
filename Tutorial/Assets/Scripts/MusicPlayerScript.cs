using UnityEngine;
using System.Collections;
using System;

public class MusicPlayerScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake()
	{
		GameObject gameMusic = GameObject.Find ("GameMusic");
		if (gameMusic)
		{
			Destroy (gameMusic);
		}
		DontDestroyOnLoad(gameObject);
	}


}
