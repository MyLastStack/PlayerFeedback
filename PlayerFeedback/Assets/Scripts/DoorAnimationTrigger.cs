using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
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
            animator.SetBool("Open", true);
            alreadyPlayed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !alreadyPlayed)
        {
            playing = true;
        }
    }
}
