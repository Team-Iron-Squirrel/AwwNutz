using UnityEngine;
using System.Collections.Generic;

public class CreatePlatform : MonoBehaviour {
    public GameObject Course1, Course2, Course3, Course4, Course5, Course6, Course7, Course8, Course9, Course10, Course11, Course12, Course13, Course14, Course15;
    public List<GameObject> CourseList = new List<GameObject>();
    private int index = 1, tier = 1;
    private int coin;

    // Use this for initialization
    void Awake()
    {
        Debug.Log("start");
        CourseList.Add(null);
        CourseList.Add(Course1); CourseList.Add(Course2); CourseList.Add(Course3); CourseList.Add(Course4); CourseList.Add(Course5);
        CourseList.Add(Course6); CourseList.Add(Course7); CourseList.Add(Course8); CourseList.Add(Course9); CourseList.Add(Course10);
        CourseList.Add(Course11); CourseList.Add(Course12); CourseList.Add(Course13); CourseList.Add(Course14); CourseList.Add(Course15);

    }
    
    void Update()
    {
        Debug.Log("update");
    }
	void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.gameObject.CompareTag("Course"))
        {
            coin = Random.Range(0, 2);
            Vector3 spawnLoc = new Vector3();
            spawnLoc.z = 0F;
            spawnLoc.x = gameObject.transform.position.x + 15;
            spawnLoc.y = 0F;
            if(index == 1)
            {
                Instantiate(CourseList[index], spawnLoc, default(Quaternion));
            }
            else if (index > 15)
            {
                index = 1;
                tier = 1;
                Instantiate(CourseList[index], spawnLoc, default(Quaternion));
            }
            else
            {
                Instantiate(CourseList[index], spawnLoc, default(Quaternion));
            }
            index += tier + coin;
            tier++;

            
        }
    }
}
