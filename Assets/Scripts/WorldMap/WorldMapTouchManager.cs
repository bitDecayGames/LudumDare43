using System.Collections.Generic;
using UnityEngine;

namespace WorldMap {
    public class WorldMapTouchManager : MonoBehaviour {

        private List<WorldMapButton> buttons = new List<WorldMapButton>();

        public void Register(WorldMapButton button) {
            buttons.Add(button);
        }

        void Update() {
            UpdateStatus();
        }

        public void UpdateStatus() {
            var hit = GetHit(Input.mousePosition);
            if (hit != null) {
                if (Input.GetMouseButtonDown(0)) {
                    buttons.ForEach(button => {
                        button._RefreshStatus();
                        button._ClickStatus(hit == button);
                        button._HoverStatus(hit == button);
                    });
                } else {
                    buttons.ForEach(button => {
                        button._RefreshStatus();
                        button._ClickStatus(false);
                        button._HoverStatus(hit == button);
                    });
                }
            } else {
                buttons.ForEach(button => {
                    button._RefreshStatus();
                    button._ClickStatus(false);
                    button._HoverStatus(false);
                });
            }
        }
        
        private WorldMapButton GetHit(Vector3 screenPos) {
            return GetFirstHitOfType<WorldMapButton>(screenPos);
        }

        private T GetFirstHitOfType<T>(Vector3 screenPos) {
            screenPos.z = 0;
            List<RaycastHit> hits = new List<RaycastHit>();
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            hits.AddRange(Physics.RaycastAll(ray));
            hits.Sort((a, b) => (int)((a.transform.position.z - b.transform.position.z) * 10000));
            for(int i = 0; i < hits.Count; i++) {
                T tmp = hits[i].transform.GetComponentInParent<T>();
                if (tmp != null) return tmp;
            }
            return default(T);
        }
    }
}