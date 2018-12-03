using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Particles {
    public class MyParticleEmitter : MonoBehaviour {
        public float MaxSpeed = 0.01f;
        public float MinSpeed = 0.001f;
        public float MaxLife = 1f;
        public float MinLife = .5f;
        public MyParticle ParticlePrefab;
        
        private Random rnd = new Random();

        public MyParticle EmitParticle(Vector3 position) {
            var velocity = new Vector3();
            var xMod = rnd.Next(-1, 2);
            velocity.x = (float) rnd.NextDouble() * xMod;
            var yMod = rnd.Next(-1, 2);
            velocity.y = (float) rnd.NextDouble() * yMod;
            if (xMod == 0 && yMod == 0) velocity.x = 1;
            velocity.Normalize();
            velocity *= RandRange(MaxSpeed, MinSpeed);

            var particle = Instantiate(ParticlePrefab, transform);
            position.z = 0;
            particle.transform.position = position;
            particle.Emitted(velocity, RandRange(MaxLife, MinLife));
            return particle;
        }

        public List<MyParticle> EmitParticles(Vector3 position, int count) {
            if (count > 50) count = 50;
            List<MyParticle> particles = new List<MyParticle>();
            for (int i = 0; i < count; i++) particles.Add(EmitParticle(position));
            return particles;
        }

        private float RandRange(float max, float min) {
            return (float) rnd.NextDouble() * (max - min) + min;
        }
    }
}