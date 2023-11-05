using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetScript : MonoBehaviour
{
    [SerializeField] GameObject camTrigger;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem smoke;

    void Start()
    {
        
    }

    void Update()
    {
        if (camTrigger.GetComponent<SecurityCamScript>().switchTriggered)
        {
            animator.SetBool("fall", true);
            smoke.Play();
        }
    }
}
