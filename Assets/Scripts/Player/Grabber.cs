using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrashZone;

public class Grabber : MonoBehaviour
{
	private Collider2D mostRecent;
	
	public bool Activate(GameObject go)
	{
		if (go.GetComponent<FixedJoint2D>() != null)
		{
			go.GetComponent<FixedJoint2D>().connectedBody.bodyType = RigidbodyType2D.Static;
			Destroy(go.GetComponent<FixedJoint2D>());

			var trashZone = FindObjectOfType<TrashZoneBehaviour>();
			if (trashZone != null) {
				trashZone.CheckAndTakeOutTrash(go.GetComponent<FixedJoint2D>().connectedBody.transform);
			}
			return false;
		}
		
		if (mostRecent != null)
		{
			mostRecent.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
			go.AddComponent<FixedJoint2D>();  
			go.GetComponent<FixedJoint2D>().connectedBody = mostRecent.attachedRigidbody;
			return true;
		}

		return false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<PlayerMovement>() != null )
		{
			return;
		}
//		print("Adding collision with " + other.gameObject);
		mostRecent = other;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other == mostRecent)
		{
//			print("Removing collision with " + other.gameObject);
			mostRecent = null;
		}
	}
}
