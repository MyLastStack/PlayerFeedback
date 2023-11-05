using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
    public bool playing;
    public bool alreadyPlayed;
    void Start()
    {
        playing = false;
        alreadyPlayed = false;
    }

    void Update()
    {
        if (playing && !alreadyPlayed)
        {
            animator.Play("Base Layer.GameSceneDoor", 0);
            alreadyPlayed = true;
        }
    }

    public void playAudio()
    {
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !alreadyPlayed)
        {
            playing = true;
        }
    }
}
