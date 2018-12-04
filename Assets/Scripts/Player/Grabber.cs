using Particles;
using SuperTiled2Unity;
using TrashZone;
using UnityEngine;
using Utils;

public class Grabber : MonoBehaviour
{
	private Collider2D mostRecent;

	private MyParticleEmitter HeartEmitter;

	void Start() {
		var hEObj = GameObject.FindWithTag("HeartEmitter");
		if (hEObj) {
			HeartEmitter = hEObj.GetComponent<MyParticleEmitter>();
		}
	}
	
	public bool Activate(GameObject go)
	{
		if (go.GetComponent<FixedJoint2D>() != null) {
			var theCargo = go.GetComponent<FixedJoint2D>().connectedBody.transform;
			go.GetComponent<FixedJoint2D>().connectedBody.bodyType = RigidbodyType2D.Static;
			Destroy(go.GetComponent<FixedJoint2D>());

			var trashZone = FindObjectOfType<TrashZoneBehaviour>();
			if (trashZone != null) {
				var superObject = theCargo.GetComponentInParent<SuperObject>();
				if (superObject != null) {
					var centeredCargo = superObject.GetComponentInChildren<GetMeToCenter>();
					if (centeredCargo != null) trashZone.CheckAndTakeOutTrash(centeredCargo.transform);
				}
			}
			return false;
		}
		
		if (mostRecent != null)
		{
			mostRecent.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
			go.AddComponent<FixedJoint2D>();
			go.GetComponent<FixedJoint2D>().connectedBody = mostRecent.attachedRigidbody;
			EmitHearts();
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
		mostRecent = other;
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other == mostRecent)
		{
			mostRecent = null;
		}
	}

	private void EmitHearts() {
		if (HeartEmitter != null) {
			var women = FindObjectsOfType<WomanMovement>();
			foreach (var lady in women) {
				HeartEmitter.EmitParticles(lady.transform.position, 5);
			}
		}
	}
}
