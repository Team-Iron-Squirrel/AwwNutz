using UnityEngine;
using System.Collections;

public class platformSpawner : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Platform"))
        {
            Vector3 posCollider = collider.transform.position;
            posCollider.x += 128;
            collider.transform.position = posCollider;
        }
		if (collider.gameObject.CompareTag("Background"))
		{
			Vector3 posCollider = collider.transform.position;
			posCollider.x += 225;
			collider.transform.position = posCollider;
		}
    }
}
