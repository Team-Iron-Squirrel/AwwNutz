using UnityEngine;
using System.Collections;

public class firstSpawn : MonoBehaviour {
    public GameObject courseOne;
    // Use this for initialization
    void Start () {
        Debug.Log("start2");
        Vector3 spawnLoc = new Vector3();
        spawnLoc.z = 0F;
        spawnLoc.x = gameObject.transform.position.x + 15;
        spawnLoc.y = 0F;
        Instantiate(courseOne, spawnLoc, Quaternion.Euler(0, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
