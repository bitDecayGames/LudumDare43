using System.Collections;
using System.Collections.Generic;
using Cargo;
using Level;
using UnityEngine;

public class LevelStartScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		// TODO: figure out how to set tags on these
		var cargoT = transform.parent.Find("cargo");
		// 'cargo is layer 12'
		SetLayerRecursively(cargoT.transform, 12);
		
		var trashT = transform.Find("TrashZone");
		// 'player collidable is layer 10'
		SetLayerRecursively(trashT.transform, 10);
		
		for (int i = 0; i < cargoT.childCount; i++)
		{
			var cargoPiece = cargoT.GetChild(i);
			var cargoBehavior = cargoPiece.gameObject.AddComponent<CargoBehaviour>();
			cargoPiece.gameObject.SetActive(false);
			GetComponent<LevelBehaviour>().AddToCargoQueue(cargoBehavior);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SetLayerRecursively(Transform t, int layer)
	{
		t.gameObject.layer = layer;
   
		for (int i = 0; i < t.childCount; i++)
		{
			SetLayerRecursively(t.GetChild(i), layer);
		}
	}
}
