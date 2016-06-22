using UnityEngine;
using System.Collections;

public class platformSpawner : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Platform"))
        {
            Vector3 posCollider = collider.transform.position;
            posCollider.x += 64;
            collider.transform.position = posCollider;
        }
    }
}
