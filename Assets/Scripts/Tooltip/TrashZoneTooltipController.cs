using UnityEngine;

public class TrashZoneTooltipController : MonoBehaviour
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