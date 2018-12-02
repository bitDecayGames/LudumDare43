using System.Collections;
using System.Collections.Generic;
using Cargo;
using DropZone;
using Level;
using SuperTiled2Unity;
using UnityEngine;

public class LevelStartScript : MonoBehaviour
{

	public DropZoneBehaviour dropZone;
	
	// Use this for initialization
	void Start ()
	{
		var levelB = GetComponent<LevelBehaviour>();
		// TODO: figure out how to set tags on these
		var mapObj = GameObject.Find("level");
		var cargoT = mapObj.transform.Find("Cargo");
		// 'cargo is layer 11'
		SetLayerRecursively(cargoT.transform, 11, "Cargo");
		
		var trashT = mapObj.transform.Find("TrashZone");
		// 'player collidable is layer 10'
		SetLayerRecursively(trashT.transform, 10, "Untagged");
		
		for (int i = 0; i < cargoT.childCount; i++)
		{
			var cargoPiece = cargoT.GetChild(i);
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
			levelB.AddToCargoQueue(cargoBehavior);
		}

		// TODO: This should be pulled from the tiled map
		levelB.AddDropZone(dropZone);
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
