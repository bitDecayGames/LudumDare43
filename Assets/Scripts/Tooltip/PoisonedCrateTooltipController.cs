using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedCrateTooltipController : MonoBehaviour
{

	public GameObject PoisonedCrate;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PoisonedCrate == null)
		{
			Destroy(gameObject);
		}
	}
}
