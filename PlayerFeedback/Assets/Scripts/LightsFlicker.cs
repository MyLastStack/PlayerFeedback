using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsFlicker : MonoBehaviour
{
    public Light lightSource;

    public AudioSource lightSparks;

    public float minTime;
    public float maxTime;
    public float timer;

    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        
    }

    void lightsFlickering()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            lightSource.enabled = !lightSource.enabled;
            timer = Random.Range(minTime, maxTime);
            lightSparks.Play();
        }
    }
}
