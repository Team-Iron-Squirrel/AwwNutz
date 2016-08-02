using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RestartLevel()
    {
        Application.LoadLevel(1);
    }

    public void ExitLevel()
    {
        Application.LoadLevel(0);
    }
    public void Play()
    {
        Application.LoadLevel(2);
    }
	public void StoryNext()
	{
		Application.LoadLevel (3);
	}
	public void Story1Next()
	{
		Application.LoadLevel (4);
	}
	public void Story2Next()
	{
		Application.LoadLevel (5);
	}
	public void Story3Next()
	{
		Application.LoadLevel (6);
	}
	public void Story4Next()
	{
		Application.LoadLevel (7);
	}
	public void Story5Next()
	{
		Application.LoadLevel (1);
	}
	public void ControlsNext()
	{
		Application.LoadLevel (5);
	}
	public void WarningPlay()
	{
		Application.LoadLevel (1);
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
