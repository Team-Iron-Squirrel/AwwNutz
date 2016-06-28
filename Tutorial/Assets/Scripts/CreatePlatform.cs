using UnityEngine;
using System.Collections;

public class CreatePlatform : MonoBehaviour {
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject platformThree;
    public float SpawnTime;
	public GameObject acorn;
	public float time;

	// Use this for initialization
	
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        float random = Random.Range(0, 4);
        Vector3 spawnLoc = new Vector3();
        spawnLoc.z = 0F;
        spawnLoc.x = gameObject.transform.position.x + 20;
        spawnLoc.y = 2.8F;
		Vector3 spawnAcorn = new Vector3 ();
		time += 30*Time.deltaTime;

		if (time > SpawnTime) {
			//Debug.Log ("spawn");
			spawnAcorn = spawnLoc;
			spawnAcorn.y += 1;
			Instantiate (acorn, spawnAcorn, Quaternion.Euler (0, 0, 0));
			time = 0;
		}
        if (collider.gameObject.CompareTag("Platform"))
        {
			
            if (random == 1)
            {
                Instantiate(platformOne, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
            else if (random == 2)
            {
                Instantiate(platformTwo, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
            else if (random == 3)
            {
                Instantiate(platformThree, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
        }
    }
}
