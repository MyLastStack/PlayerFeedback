using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    [SerializeField] Animation animator;
    public bool playing;
    void Start()
    {
        playing = false;
    }

    void Update()
    {
        if (playing)
        {
            animator.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playing = true;
        }
    }
}
