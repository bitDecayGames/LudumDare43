using System.Collections;
using DropZone;
using Level;
using ScriptableObjects;
using UnityEngine;

namespace DebugScripts {
    public class DebugLevelBehaviour : MonoBehaviour {
        public CargoFactory Factory;

        public DropZoneBehaviour DropZoneOne;
        public DropZoneBehaviour DropZoneTwo;
        
        void Start() {
            StartCoroutine(WaitThenTest());
        }

        private IEnumerator WaitThenTest() {
            yield return new WaitForSeconds(0.1f);

            var level = FindObjectOfType<LevelBehaviour>();
            if (level != null) {
                level.SetRating(new LevelRating(10, 30, 60));
                level.AddToCargoQueue(Factory.ByName("LCargo", 1))
                    .AddToCargoQueue(Factory.ByName("SquareCargo", 2))
                    .AddToCargoQueue(Factory.ByName("LineCargo", 2))
                    .AddToCargoQueue(Factory.ByName("SCargo", 3))
                    .AddToCargoQueue(Factory.ByName("TCargo", 1))
                    .AddToCargoQueue(Factory.ByName("LCargo", 3))
                    .AddToCargoQueue(Factory.ByName("SquareCargo", 10))
                    .AddToCargoQueue(Factory.ByName("SCargo", 15))
                    .AddToCargoQueue(Factory.ByName("TCargo", 20));
                level.AddDropZone(DropZoneOne).AddDropZone(DropZoneTwo);
            }
        }
    }
}