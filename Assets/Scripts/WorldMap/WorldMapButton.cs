using System;
using UnityEngine;
using UnityEngine.Events;

namespace WorldMap {
    public class WorldMapButton : MonoBehaviour {
        public WorldMapButtonEvent OnClick = new WorldMapButtonEvent();
        public WorldMapButtonEvent OnHoverEnter = new WorldMapButtonEvent();
        public WorldMapButtonEvent OnHoverExit = new WorldMapButtonEvent();
        
        private bool clickStatus;
        private bool lastClickStatus;
        private bool hoverStatus;
        private bool lastHoverStatus;

        void Start() {
            var manager = FindObjectOfType<WorldMapTouchManager>();
            if (manager == null) throw new Exception("Couldn't find WorldMapTouchManager on the scene, probably needs to be put on the MainCamera");
            manager.Register(this);
        }

        void Update() {
            if (JustClicked())
            {
                FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.MenuSelect2);
                OnClick.Invoke(this);
            }
            if (HoverJustEnter()) OnHoverEnter.Invoke(this);
            if (HoverJustExit()) OnHoverExit.Invoke(this);
        }

        /// <summary>
        /// Only for use by the WorldMapTouchManager
        /// </summary>
        /// <param name="value"></param>
        public void _ClickStatus(bool value) {
            clickStatus = value;
        }

        /// <summary>
        /// Only for use by the WorldMapTouchManager
        /// </summary>
        /// <param name="value"></param>
        public void _HoverStatus(bool value) {
            hoverStatus = value;
        }

        /// <summary>
        /// Only for use by the WorldMapTouchManager
        /// </summary>
        public void _RefreshStatus() {
            lastClickStatus = clickStatus;
            lastHoverStatus = hoverStatus;
        }

        public bool JustClicked() {
            return clickStatus && clickStatus != lastClickStatus;
        }

        public bool HoverJustEnter() {
            return hoverStatus && hoverStatus != lastHoverStatus;
        }
        
        public bool IsHovering() {
            return hoverStatus;
        }

        public bool HoverJustExit() {
            return !hoverStatus && hoverStatus != lastHoverStatus;
        }

        [Serializable]
        public class WorldMapButtonEvent : UnityEvent<WorldMapButton> {}
    }
}