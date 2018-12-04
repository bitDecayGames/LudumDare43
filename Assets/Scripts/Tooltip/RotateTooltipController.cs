using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTooltipController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach (var spriteRenderer in GetComponentsInChildren<SpriteRenderer>()) {
			spriteRenderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
