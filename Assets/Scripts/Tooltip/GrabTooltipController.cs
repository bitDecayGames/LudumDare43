using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Cargo;
using SuperTiled2Unity;
using UnityEngine;

public class GrabTooltipController : MonoBehaviour
{
	private bool grabbed;
	private bool released;

	public SpriteRenderer grabTip;
	public SpriteRenderer releaseTip;

	private PlayerMovement player;
	
	private CargoBehaviour cargo;
	// Use this for initialization
	void Start ()
	{
		var playerObj = GameObject.FindWithTag("Player");
		player = playerObj.GetComponent<PlayerMovement>();
		grabTip.gameObject.SetActive(false);
		releaseTip.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (cargo == null)
		{
			cargo = gameObject.GetComponentInAncestor<CargoBehaviour>();
			return;
		}

		var jointFound = false;
		foreach (var joint in player.GetComponentsInChildren<FixedJoint2D>())
		{
			if (joint.connectedBody.gameObject.GetComponentInAncestor<CargoBehaviour>() == cargo)
			{
				// this is us!
				grabbed = true;
				jointFound = true;
				break;
			}
		}

		if (grabbed && !jointFound)
		{
			// we have been released
			released = true;
		}
		
		if (!grabbed && !released)
		{
			grabTip.gameObject.SetActive(true);
			releaseTip.gameObject.SetActive(false);
		} else if (grabbed && !released)
		{
			grabTip.gameObject.SetActive(false);
			releaseTip.gameObject.SetActive(true);
		}
		else
		{
			grabTip.gameObject.SetActive(false);
			releaseTip.gameObject.SetActive(false);
		}
}
}
