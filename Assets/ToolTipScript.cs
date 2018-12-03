using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipScript : MonoBehaviour
{

	public enum Tips
	{
		MOVE,
		GRAB,
		ACCEL,
		ROTATE,
		TRASH
	}

	public Vector2 offset;
	public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTip(Tips tip)
	{
		
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
}
