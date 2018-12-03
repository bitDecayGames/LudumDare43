﻿using System;
using Cargo;
using DropZone;
using Level;
using SuperTiled2Unity;
using UnityEngine;
using Utils;

public class LevelStartScript : MonoBehaviour
{

	public DropZoneBehaviour dropZone;
	public GetMeToCenter CenterPrefab;

	private GameObject mapObj;
	
	// Use this for initialization
	void Start ()
	{
		mapObj = GameObject.Find("level");
		var levelB = GetComponent<LevelBehaviour>();

		SetupTrash(mapObj, levelB);
		
		SetupCargo(mapObj, levelB);

		SetupPerspectivePoint(mapObj);

		// TODO: This should be pulled from the tiled map
		levelB.AddDropZone(dropZone);
		// TODO: This should be pulled from the tiled map
		levelB.SetRating(new LevelRating(1, 2, 3));
		
		if (CenterPrefab == null) throw new Exception("You must add the Prefabs/TrashZone/CenterMe prefab to this LevelStartScript component");
		
		
	}

	private void SetupTrash(GameObject tiledMap, LevelBehaviour level)
	{
		var trashT = tiledMap.transform.Find("TrashZone");
		// 'player collidable is layer 10'
		SetLayerRecursively(trashT.transform, 10, "Untagged");
	}

	private void SetupCargo(GameObject tiledMap, LevelBehaviour level)
	{
		var t = tiledMap.transform;
		var cargoT = t.Find("Cargo");
		// 'cargo is layer 11'
		SetLayerRecursively(cargoT.transform, 11, "Cargo");
		
		for (int i = 0; i < cargoT.childCount; i++)
		{
			var cargoPiece = cargoT.GetChild(i);
			var childBod = cargoPiece.GetComponentInChildren<Rigidbody2D>();

			var rbod = cargoPiece.gameObject.AddComponent<Rigidbody2D>();
			rbod.bodyType = RigidbodyType2D.Dynamic;
			rbod.gameObject.AddComponent<FixedJoint2D>().connectedBody = childBod;
				
			var cargoProps = cargoPiece.GetComponent<SuperCustomProperties>();
			var cargoBehavior = cargoPiece.gameObject.AddComponent<CargoBehaviour>();
			foreach (CustomProperty p in cargoProps.m_Properties)
			{
				if (p.m_Name == "delay")
				{
					cargoBehavior.delay = float.Parse(p.m_Value);
				}
				if (p.m_Name == "score")
				{
					cargoBehavior.score = int.Parse(p.m_Value);
				}
			}
			cargoPiece.gameObject.SetActive(false);

			var renderererer = cargoProps.GetComponentInChildren<SpriteRenderer>();
			var centerer = Instantiate(CenterPrefab, cargoProps.transform);
			centerer.Center(renderererer);
			
			level.AddToCargoQueue(cargoBehavior);
		}
	}

	private void SetupPerspectivePoint(GameObject tiledMap)
	{
		var items = tiledMap.transform.Find("KeyItems");
		var centerT = items.Find("center");

		foreach (Collider2D p in centerT.GetComponentsInChildren<Collider2D>())
		{
			Destroy(p);
		}

		var player = GameObject.FindWithTag("Player");
		var playerScript = player.GetComponentInChildren<PlayerAnimationController>();
		playerScript.PerspectivePoint = centerT.gameObject;
	}
	
	private int frameDelay = 100;

	private void FixedUpdate()
	{
		if (frameDelay > 0)
		{
			frameDelay--;
			if (frameDelay <= 0)
			{
				foreach (CompositeCollider2D c2d in mapObj.GetComponentsInChildren<CompositeCollider2D>())
				{
					c2d.generationType = CompositeCollider2D.GenerationType.Synchronous;
					c2d.GenerateGeometry();
				}
			}
			}
		}
	

	void SetLayerRecursively(Transform t, int layer, string tag)
	{
		t.gameObject.layer = layer;
		t.gameObject.tag = tag;
   
		for (int i = 0; i < t.childCount; i++)
		{
			SetLayerRecursively(t.GetChild(i), layer, tag);
		}
	}
}
