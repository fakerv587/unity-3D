using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleData {
    public float before;
    public float after;
    public float angle;
    public float radius;
  public ParticleData(float angle, float radius, float before, float after) {
    this.angle = angle;
    this.radius = radius;
    this.before = before;
    this.after = after;
  }
}
public class Halo : MonoBehaviour {

    public ParticleSystem particleSystem;
    public Camera camera;
    public int particleNum = 10000;
    public float minRadius = 3.0f;
    public float maxRadius = 8.0f;

    private ParticleSystem.Particle[] particles;
    private ParticleData[] particleDatas;
    private int speedLevel = 5;
    private float particleSpeed = 0.1f;

    private Ray ray;
    private RaycastHit hit;

    private float shrinkSpeed = 2f;
    private bool isshrink = false;


	// Use this for initialization
	void Start () {
        particles = new ParticleSystem.Particle[particleNum];
        particleDatas = new ParticleData[particleNum];         
        particleSystem.maxParticles = particleNum;

        particleSystem.Emit(particleNum);
        particleSystem.GetParticles(particles);

        Ndistribution nd = new Ndistribution();

        for (int i = 0; i < particleNum; i++)
        {
            float angle = UnityEngine.Random.Range(0.0f, 360.0f);
            float radius = (float)nd.getNormalDistribution((minRadius+maxRadius)*0.5f, 1);
            float before = radius;
            float after = 0.7f * radius;

            if (after < minRadius * 1.1f)
            {
                float midRadius = minRadius * 1.2f;
                after = UnityEngine.Random.Range(UnityEngine.Random.Range(minRadius, midRadius), (minRadius * 1.1f));
            }
            particleDatas[i] = new ParticleData(angle,radius,before,after);
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < particleNum; i++)
        {
            if (isshrink)
            {
                if(particleDatas[i].radius > particleDatas[i].after)
                {
                    particleDatas[i].radius -= shrinkSpeed * (particleDatas[i].radius / particleDatas[i].after) * Time.deltaTime;
                }
            }
            else
            {
                if (particleDatas[i].radius < particleDatas[i].before)
                {
                    particleDatas[i].radius += shrinkSpeed * (particleDatas[i].before / particleDatas[i].radius) * Time.deltaTime;
                }
                else if (particleDatas[i].radius > particleDatas[i].before)
                {
                    particleDatas[i].radius = particleDatas[i].before;
                }
            }

            if (i % 2 == 0)  
            {  
                particleDatas[i].angle += (i % speedLevel + 1) * particleSpeed;  
            }  
            else  
            {  
                particleDatas[i].angle -= (i % speedLevel + 1) * particleSpeed;  
            }  

            particleDatas[i].angle = particleDatas[i].angle % 360;
            float rad = particleDatas[i].angle / 180 * Mathf.PI;  

            particles[i].position = new Vector3(particleDatas[i].radius * Mathf.Cos(rad), particleDatas[i].radius * Mathf.Sin(rad), 0f);  
        }  

        particleSystem.SetParticles(particles, particleNum);  
  
        ray = camera.ScreenPointToRay(Input.mousePosition);  
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "qaq") isshrink = true;  
        else isshrink = false;  
	}
}

class Ndistribution{
    System.Random rand = new System.Random();

    public double getNormalDistribution(double mean, double stdDev)
    {
        double u1 = 1.0 - rand.NextDouble();
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2);
        double randNormal = mean + stdDev * randStdNormal;
        return randNormal;
    }
}