using System;
using UnityEngine;

namespace DropZone {
    public class Chain : MonoBehaviour {
        public Transform Origin;
        
        private SpriteRenderer _renderer;
        private SpriteRenderer Renderer {
            get {
                if (_renderer == null) _renderer = GetComponent<SpriteRenderer>();
                return _renderer;
            }
        }

        private bool lengthening;
        private float targetLength;
        private float length;
        private float timeToLength;
        private float time;
        private Action onDone;
        private Action onStart;

        void Start() {
            SetLength(GetLength());
        }


        public float GetLength() {
            return Renderer.size.x;
        }
        
        public void SetLength(float length) {
            var size = Renderer.size;
            size.x = length;
            Renderer.size = size;
            MoveToCorrectOrigin();
        }
        
        void Update() {
            if (lengthening) {
                if (time < timeToLength) {
                    var len = time / timeToLength * (targetLength - length) + length;
                    SetLength(len);
                    time += Time.deltaTime;
                } else {
                    lengthening = false;
                    SetLength(targetLength);
                    if (onDone != null) onDone();
                }
            } else {
                SetLength(GetLength());
            }
        }

        public void SetTargetLength(float length, float timeToLength, Action onDone, Action onStart)
        {
            onStart();
            lengthening = true;
            targetLength = length;
            this.length = GetLength();
            this.timeToLength = timeToLength;
            time = 0;
            this.onDone = onDone;
        }

        private void MoveToCorrectOrigin() {
            var pos = transform.position;
            pos.x = Origin.position.x;
            pos.y = Origin.position.y - GetLength();
            transform.position = pos;
        }
    }
}