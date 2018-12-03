using UnityEngine;
using System;

namespace UI
{
    public class SpriteAlphaBounce : MonoBehaviour
    {
        public const float AlphaBounceSpeed = .5f;
        private bool isFading;

        public float bottomAlpha = 0.5f;

        private SpriteRenderer renderer;

        private void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            if (renderer == null)
            {
                throw new Exception("Component requires a CanvasGroup");
            }

            Color tmp = renderer.color;
            tmp.a = 0;
            renderer.color = tmp;
        }
    
        private void Update()
        {
            Color tmp = renderer.color;
            
            if (!isFading)
            {
                tmp.a = tmp.a + AlphaBounceSpeed*Time.deltaTime;    
            
                if (tmp.a >= 1)
                {
                    isFading = true;
                }
            }
            else
            {
                tmp.a = tmp.a - AlphaBounceSpeed*Time.deltaTime;  
            
                if (tmp.a <= bottomAlpha)
                {
                    isFading = false;
                }
            }
        
            renderer.color = tmp;
        }
    }
}