using UnityEngine;

namespace Ambient {
    public class CloudCluster : MonoBehaviour {
        public Transform LargeCloudPrefab;
        public Transform SmallCloudPrefab;

        public float Speed = 0.01f;
        public float Radius = 0.1f;
        
        private System.Random rnd = new System.Random();
        
        void Start() {
            var largeCloudNum = rnd.Next(1, 3);
            for (int i = 0; i < largeCloudNum; i++) SpawnCloud(LargeCloudPrefab);
            var smallCloudNum = rnd.Next(0, 2);
            for (int i = 0; i < smallCloudNum; i++) SpawnCloud(SmallCloudPrefab);
        }

        void Update() {
            var pos = transform.position;
            pos.x += Speed;
            transform.position = pos;
        }
        

        private void SpawnCloud(Transform cloud) {
            var cloudInst = Instantiate(cloud, transform);
            var pos = new Vector3((float) rnd.NextDouble(), (float) rnd.NextDouble());
            pos.Normalize();
            pos *= Radius;
            cloudInst.transform.localPosition = pos;
        }
    }
}