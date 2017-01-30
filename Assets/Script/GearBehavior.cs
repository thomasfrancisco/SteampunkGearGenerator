using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearBehavior : MonoBehaviour {
    [HideInInspector]
    public float speed;
    public float smokeProbability;
    public Vector2 smokeRateMinMax;

    private Transform smokeEmitter;
    private ParticleSystem particle;
    private bool hasParticleSystem = false;
    private float timer;
    private float smokeEmissionRate;

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        smokeEmitter = transform.FindChild("smokeEmitter");
        float rand = Random.Range(0f, 1f);
        if (rand < smokeProbability)
        {
            transform.DetachChildren();
            hasParticleSystem = true;
            particle = smokeEmitter.gameObject.GetComponent<ParticleSystem>();
            smokeEmitter.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            
            
            Debug.Log("Got particle");
        } else
        {
            DestroyImmediate(smokeEmitter.gameObject);
        }

        smokeEmissionRate = Random.Range(smokeRateMinMax.x, smokeRateMinMax.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        if(timer > smokeEmissionRate && hasParticleSystem)
        {
            timer = 0;
            particle.Play();
            
        }

        timer += Time.deltaTime;

    }
}
