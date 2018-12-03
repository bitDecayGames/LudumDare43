using UnityEngine;
using Random = System.Random;

namespace Ambient {
    public class CloudGenerator : MonoBehaviour {
        public CloudCluster CloudClusterPrefab;
        
        public float Height = 1;
        public float LowFrequency = 10;
        public float HighFrequency = 5;

        private float time;
        private float timeTilSpawn;

        private Random rnd = new Random();

        void Start() {
            Spawn();
        }

        void Update() {
            if (time < timeTilSpawn) {
                time += Time.deltaTime;
                if (time >= timeTilSpawn) Spawn();
            }
        }
        
        private void Spawn() {
            var cloud = Instantiate(CloudClusterPrefab, transform);
            cloud.transform.localPosition = new Vector3(0, (float) rnd.NextDouble() * Height, 0);

            time = 0;
            timeTilSpawn = (float) rnd.NextDouble() * (LowFrequency - HighFrequency) + HighFrequency;
        }
    }
}