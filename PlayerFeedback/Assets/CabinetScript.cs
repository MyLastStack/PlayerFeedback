using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetScript : MonoBehaviour
{
    [SerializeField] GameObject camTrigger;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem smoke;

    [SerializeField] Animator jumpscare;

    [SerializeField] GameSceneManager gsm;

    bool startScare = false;
    float timer = 5.0f;

    bool creditBool = false;
    float secondTimer = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (camTrigger.GetComponent<SecurityCamScript>().switchTriggered)
        {
            animator.SetBool("fall", true);
            smoke.Play();
            startScare = true;
        }

        if (startScare)
        {
            countdownTimer();
            if (creditBool)
            {
                endCredit();
            }
        }
    }

    void countdownTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            jumpscare.SetBool("spook", true);
            creditBool = true;
        }
    }

    void endCredit()
    {
        if (secondTimer > 0)
        {
            secondTimer -= Time.deltaTime;
        }
        if (secondTimer <= 0)
        {
            gsm.EndCredit();
        }
    }

}
