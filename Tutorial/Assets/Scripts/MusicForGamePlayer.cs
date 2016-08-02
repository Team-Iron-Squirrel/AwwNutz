using UnityEngine;
using System.Collections;

public class MusicForGamePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake()
	{
		GameObject menuMusic = GameObject.Find ("MenuMusic");
		if (menuMusic)
		{
			Destroy (menuMusic);
		}
		DontDestroyOnLoad(gameObject);
	}
}
