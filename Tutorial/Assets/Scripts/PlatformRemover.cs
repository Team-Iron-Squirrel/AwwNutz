using UnityEngine;
using System.Collections;

public class PlatformRemover : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            Debug.Log("layer");
            if (collider.tag == "aiJump")
            {
                Debug.Log("aijump");

                Destroy(collider.gameObject);
            }
                
        }
        else {
            Destroy(collider.gameObject);
        }
    }
}
