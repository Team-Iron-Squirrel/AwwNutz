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
	public void ControlsNext()
	{
		Application.LoadLevel (4);
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
