using Cargo;
using UnityEngine;

public class TrashZoneTooltipController : MonoBehaviour
{
    public GameObject PoisonedCrate;
	
    // Use this for initialization
    void Start ()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
	
    // Update is called once per frame
    void Update () {
        
        if (PoisonedCrate == null)
        {
            Destroy(gameObject);
            return;
        }
        
        if (PoisonedCrate.GetComponent<CargoBehaviour>().score == -50)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }
}