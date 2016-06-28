using UnityEngine;
using System.Collections;

public class CreatePlatform : MonoBehaviour {
    public GameObject courseOne;
    public GameObject courseTwo;
    public GameObject courseThree;
    public GameObject courseFour;
    public GameObject courseFive;
    public float SpawnTime;
	public GameObject acorn;
	public float time;
    public GameObject Enemy;
	// Use this for initialization
	
	void OnTriggerEnter2D(Collider2D collider)
    {
		

		
        if (collider.gameObject.CompareTag("Course"))
        {
            Vector3 enemySpawn = new Vector3();
            time += 50 * Time.deltaTime;
            if (time > SpawnTime)
            {
                Debug.Log("Spawn");
                enemySpawn.y = 1F;
                enemySpawn.z = 0F;
                enemySpawn.x = gameObject.transform.position.x + 20;
                Instantiate(Enemy, enemySpawn, Quaternion.Euler(0, 0, 0));
                time = 0;
            }
            float random = Random.Range(1, 5);
            Vector3 spawnLoc = new Vector3();
            spawnLoc.z = 0F;
            spawnLoc.x = gameObject.transform.position.x + 15;
            spawnLoc.y = 0F;
            Debug.Log(spawnLoc.x + "Course:  " + random);

            if (random == 1)
            {
                Instantiate(courseOne, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
            else if (random == 2)
            {
                Instantiate(courseTwo, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
            else if (random == 3)
            {
                Instantiate(courseThree, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
            else if (random == 4)
            {
                Instantiate(courseFour, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
            else if (random == 5)
            {
                Instantiate(courseFive, spawnLoc, Quaternion.Euler(0, 0, 0));
            }
        }
    }
}
