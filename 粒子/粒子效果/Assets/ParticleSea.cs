using UnityEngine;
using System.Collections;
 
public class ParticleSea : MonoBehaviour {
 
public ParticleSystem particleSystem;
private ParticleSystem.Particle[] particlesArray;

public float spacing = 0.25f;
public int seaResolution = 25;
 
void Start() {
particlesArray = new ParticleSystem.Particle[seaResolution * seaResolution];
particleSystem.maxParticles = seaResolution * seaResolution;
particleSystem.Emit(seaResolution * seaResolution);
for(int i = 0; i<seaResolution; i++) {
for(int j = 0; j <seaResolution; j++) {
particlesArray[i * seaResolution + j].position =
new Vector3(i * spacing, j * spacing, 0);
}
particleSystem.SetParticles(particlesArray, particlesArray.Length);
}
}
 
}