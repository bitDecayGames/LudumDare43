using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Utils;

public class MoveTooltipController : MonoBehaviour
{

	private bool timerStarted;
	public float countdown = 3f;
	
	// Update is called once per frame
	void Update () {
		if (!timerStarted)
		{
			if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
			{
				timerStarted = true;
			}
		}
		else
		{
			if (countdown > 0)
			{
				countdown -= Time.deltaTime;
				if (countdown <= 0)
				{
					foreach (var spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
					{
						Destroy(spriteRenderer.GetComponent<SpriteAlphaBounce>());
						var fade = spriteRenderer.gameObject.AddComponent<SpriteFadeOutOverTime>();
						fade.timeToFadeOut = 1f;
					}
				}
			}
		}
	}
}
