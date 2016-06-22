using UnityEngine;
using System.Collections;

public class PlatformRemover : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}
