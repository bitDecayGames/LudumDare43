using System;
using Boo.Lang.Runtime;
using Cargo;
using DropZone;
using Level;
using Scoring;
using SuperTiled2Unity;
using UnityEngine;
using Utils;

public class LevelStartScript : MonoBehaviour {
    public DropZoneBehaviour dropZone;
    public GetMeToCenter CenterPrefab;

    private GameObject mapObj;

    private bool isTutorial;

    public bool SplashHasHappened; 
    public GrabTooltipController grabTip;
    public MoveTooltipController moveTip;
    public AccelTooltipController accelTip;
    public PoisonedCrateTooltipController poisonedCrateTip;
    public TrashZoneTooltipController trashZoneTip;
    public RotateTooltipController rotateTip;
    public GameObject SplashAnimation;
    public GameObject RatPrefab;

    public MoneyIndicator moneyPrefab;

    // Use this for initialization
    void Start() {
        mapObj = GameObject.Find("level");
        var levelB = GetComponent<LevelBehaviour>();
        
        var items = mapObj.transform.Find("KeyItems");
        var props = items.GetComponent<SuperCustomProperties>();
        var star1Score = 0;
        var star2Score = 0;
        var star3Score = 0;
        foreach (CustomProperty p in props.m_Properties)
        {
            if (p.m_Name == "tutorial")
            {
                isTutorial = bool.Parse(p.m_Value);
            }
        }

        SetupTrash(mapObj, levelB);

        SetupCargo(mapObj, levelB);

        SetupDropzone(mapObj, levelB);

        SetupPlayer(mapObj);
    }

    private void SetupTrash(GameObject tiledMap, LevelBehaviour level) {
        var trashT = tiledMap.transform.Find("TrashZone");
        // 'player collidable is layer 10'
        SetLayerRecursively(trashT.transform, 10, "Untagged");
    }

    private void SetupCargo(GameObject tiledMap, LevelBehaviour level) {
        var t = tiledMap.transform;
        var cargoT = t.Find("Cargo");
        // 'cargo is layer 11'
        SetLayerRecursively(cargoT.transform, 11, "Cargo");

        for (int i = 0; i < cargoT.childCount; i++)
        {
            var isRat = false;
            var innate = false;
            var cargoPiece = cargoT.GetChild(i);
            var childBod = cargoPiece.GetComponentInChildren<Rigidbody2D>();

            var rbod = cargoPiece.gameObject.AddComponent<Rigidbody2D>();
            rbod.bodyType = RigidbodyType2D.Dynamic;
            rbod.gameObject.AddComponent<FixedJoint2D>().connectedBody = childBod;

            var cargoProps = cargoPiece.GetComponent<SuperCustomProperties>();
            var cargoBehavior = cargoPiece.gameObject.AddComponent<CargoBehaviour>();
            foreach (CustomProperty p in cargoProps.m_Properties)
            {
                if (p.m_Name == "special")
                {
                    if (p.m_Value == "rat")
                    {
                        isRat = true;
                    }
                }
                if (p.m_Name == "delay")
                {
                    cargoBehavior.delay = float.Parse(p.m_Value);
                }

                if (p.m_Name == "score")
                {
                    cargoBehavior.score = int.Parse(p.m_Value);
                }

                if (p.m_Name == "material")
                {
                    cargoBehavior.material = p.m_Value;
                }

                if (p.m_Name == "bonus")
                {
                    cargoBehavior.isBonus = Boolean.Parse(p.m_Value);
                }
               
                if (p.m_Name == "bonus_description")
                {
                    cargoBehavior.bonusDescription = p.m_Value;
                }
                
                if (p.m_Name == "description")
                {
                    cargoBehavior.description = p.m_Value;
                }

                if (p.m_Name == "innate")
                {
                    innate = Boolean.Parse(p.m_Value);
                }

                if (p.m_Name == "infectable")
                {
                    if (Boolean.Parse(p.m_Value))
                    {
                        cargoBehavior.gameObject.AddComponent<Infectable>();
                    }
                }
            }

            var renderererer = cargoProps.GetComponentInChildren<SpriteRenderer>();

            try
            {
                var centerer = Instantiate(CenterPrefab, cargoProps.transform);
                centerer.Center(renderererer);
            }
            catch (Exception e)
            {
                throw new Exception("You need to add the Prefabs/TrashZone/CenterMe prefab to the LevelStartScript");
            }

            if (isTutorial && i == 0)
            {
                var tip = Instantiate(grabTip, cargoPiece.GetChild(0));
                tip.transform.localPosition = new Vector3(0, 0, 0);
            }
            
            if (isTutorial && i == 3)
            {
                var tip = Instantiate(poisonedCrateTip, cargoPiece.GetChild(0));
                tip.PoisonedCrate = cargoBehavior.gameObject;
                tip.transform.localPosition = new Vector3(-.2f, .2f, 0);
                
                var tip2 = Instantiate(trashZoneTip);
                tip2.PoisonedCrate = cargoBehavior.gameObject;
            }

            if (innate)
            {
                // we just leave these alone. They start on the deck
                cargoBehavior.SetValueTip(moneyPrefab);
            } else {
                if (isRat)
                {
                    // tell crane about rat
                    cargoPiece.gameObject.AddComponent<RatMarker>();
                }
                
                cargoPiece.gameObject.SetActive(false);
                level.AddToCargoQueue(cargoBehavior);
            }
        }
        
        var props = cargoT.GetComponent<SuperCustomProperties>();
        var star1Score = 0;
        var star2Score = 0;
        var star3Score = 0;
        foreach (CustomProperty p in props.m_Properties)
        {
            if (p.m_Name == "star1")
            {
                star1Score = int.Parse(p.m_Value);
            }
            if (p.m_Name == "star2")
            {
                star2Score = int.Parse(p.m_Value);
            }
            if (p.m_Name == "star3")
            {
                star3Score = int.Parse(p.m_Value);
            }
        }
        level.SetRating(new LevelRating(star1Score, star2Score, star3Score));
    }

    private void SetupPlayer(GameObject tiledMap) {
        var items = tiledMap.transform.Find("KeyItems");
        var centerT = items.Find("center");

        if (centerT == null)
        {
            throw new RuntimeException("No center for player");
        }

        foreach (Collider2D p in centerT.GetComponentsInChildren<Collider2D>()) {
            Destroy(p);
        }

        var player = GameObject.FindWithTag("Player");
        var playerScript = player.GetComponentInChildren<PlayerAnimationController>();
        playerScript.PerspectivePoint = centerT.gameObject;

        if (isTutorial)
        {
            Instantiate(moveTip, player.transform);
        }
    }

    private void SetupDropzone(GameObject tiledMap, LevelBehaviour level) {
        var items = tiledMap.transform.Find("KeyItems");
        var dropzoneNum = 0;

        var zoneBox = items.Find("drop_zone" + dropzoneNum);
        while (zoneBox != null) {
            var newZone = Instantiate(dropZone);
            newZone.gameObject.SetActive(true);
            var fullSize = zoneBox.GetComponent<BoxCollider2D>().size;
            var halfSize = fullSize / 2;
            var vec3 = new Vector3(halfSize.x, -halfSize.y);
            newZone.transform.position = zoneBox.transform.position + vec3;

            newZone.ZoneOutline.transform.localScale = new Vector3(fullSize.x * 6, fullSize.y * 6, 0);


            if (isTutorial)
            {
                // add tool tips to correct things
                newZone.craneTip = accelTip;
                newZone.rotateTip = rotateTip;
            }

            level.AddDropZone(newZone);
            // TODO: Set drop zone size properly
            Destroy(zoneBox.gameObject);

            dropzoneNum++;
            zoneBox = items.Find("drop_zone" + dropzoneNum);
        }

        if (dropzoneNum < 1) {
            throw new RuntimeException("No drop zones found in map");
        }
    }

    private int frameDelay = 100;

    private void FixedUpdate() {
        if (frameDelay > 0) {
            frameDelay--;
            if (frameDelay <= 0) {
                foreach (CompositeCollider2D c2d in mapObj.GetComponentsInChildren<CompositeCollider2D>()) {
                    c2d.generationType = CompositeCollider2D.GenerationType.Synchronous;
                    c2d.GenerateGeometry();
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(RatPrefab);
        }
    }

    void SetLayerRecursively(Transform t, int layer, string tag) {
        t.gameObject.layer = layer;
        t.gameObject.tag = tag;

        for (int i = 0; i < t.childCount; i++) {
            SetLayerRecursively(t.GetChild(i), layer, tag);
        }
    }
}