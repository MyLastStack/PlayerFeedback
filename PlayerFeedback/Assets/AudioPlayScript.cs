using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void playAudio()
    {
        audioSource.Play();
    }
}
