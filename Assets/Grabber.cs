using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

	private Collider2D collider;

	private Collider2D mostRecent;
	
	// Use this for initialization
	void Start ()
	{
		collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(GameObject go)
	{
		if (go.GetComponent<FixedJoint2D>() != null)
		{
			go.GetComponent<FixedJoint2D>().connectedBody.bodyType = RigidbodyType2D.Static;
			Destroy(go.GetComponent<FixedJoint2D>());
			return;
		}
		
		if (mostRecent != null)
		{
			mostRecent.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
			go.AddComponent<FixedJoint2D>();  
			go.GetComponent<FixedJoint2D>().connectedBody = mostRecent.GetComponent<Rigidbody2D>();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		mostRecent = other;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other == mostRecent)
		{
			mostRecent = null;
		}
	}
}
