using System;
using System.Collections;
using DropZone;
using ScriptableObjects;
using UnityEngine;

namespace DebugScripts {
    public class DebugDropZoneBehaviour : MonoBehaviour {
        public DropZoneBehaviour dropZone;
        public CargoFactory Factory;

        void Start() {
            StartCoroutine(DebugIt());
        }

        public IEnumerator DebugIt() {
            yield return new WaitForSeconds(.01f);
            dropZone.SetCargo(Factory.ByName("LCargo"), 3f, inst => {
//                Debug.Log("Dropped cargo1");
                StartCoroutine(WaitThenDo(2f, () => {
                    dropZone.SetCargo(Factory.ByName("TCargo"), 4f, inst2 => {
//                        Debug.Log("Dropped cargo 2");
                    });
                }));
            });
        }

        public IEnumerator WaitThenDo(float time, Action toDo) {
            yield return new WaitForSeconds(time);
            toDo();
        }
    }
}