using UnityEngine;
using System.Collections;

public class hoverText : MonoBehaviour {
	public int levelToLoad;
	public AudioSource jumpSound;
	public bool QuitButton = false;
	public TextMesh mesh;
	public GameObject nutExplode;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<TextMesh> ();
	}

	void OnMouseEnter()
	{
		mesh.color = Color.cyan;
	}
	void OnMouseExit()
	{
		mesh.color = Color.blue;
	}
	void OnMouseUp()
	{
		if (QuitButton) 
		{
			Application.Quit ();
		} 

		else 
		{
			Vector3 nutSpawn = new Vector3 ();
			jumpSound.Play ();
			nutSpawn = GetComponent<Renderer> ().bounds.center;
			//nutSpawn.z += 1;
			Instantiate (nutExplode, nutSpawn, Quaternion.Euler (0, 0, 0));

			Invoke ("SwitchLevel", 1.2f);

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void SwitchLevel()
	{
		Application.LoadLevel(levelToLoad);
	}

}
