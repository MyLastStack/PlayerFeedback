using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamScript : MonoBehaviour
{
    [SerializeField] Camera secCamOne;
    [SerializeField] Camera secCamTwo;

    [SerializeField] GameObject CamOneUI;
    [SerializeField] GameObject CamOneAuxUI;
    [SerializeField] GameObject CamTwoUI;

    [SerializeField] GameObject player;

    bool CamOneActive = false;

    float minTime = 0.5f;
    float maxTime = 2.0f;
    public float timer;
    public float secondTimer;
    bool resetter = false;

    // Start is called before the first frame update
    void Start()
    {
        secCamOne.depth = 0f;
        secCamTwo.depth = 0f;

        CamOneUI.SetActive(false);
        CamOneAuxUI.SetActive(false);
        CamTwoUI.SetActive(false);

        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (CamOneActive)
        {
            TimerReconnect();
            if (resetter)
            {
                Reconnecting();
                resetter = false;
            }
        }
    }

    public void UseCamOne()
    {
        secCamOne.depth = 2.0f;
        secCamTwo.depth = 0f;

        CamOneUI.SetActive(true);
        CamTwoUI.SetActive(false);
        CamOneActive = true;
    }

    public void UseCamTwo()
    {
        secCamOne.depth = 0f;
        secCamTwo.depth = 2.0f;

        CamOneUI.SetActive(false);
        CamTwoUI.SetActive(true);
        CamOneActive = false;
        CamOneAuxUI.SetActive(false);
    }

    public void ExitConsole()
    {
        CamOneUI.SetActive(false);
        CamTwoUI.SetActive(false);
        CamOneAuxUI.SetActive(false);

        secCamOne.depth = 0f;
        secCamTwo.depth = 0f;

        player.GetComponent<PlayerMovement>().offInteract();
    }

    void TimerReconnect()
    {
        if (timer > 0)
        {
            CamOneAuxUI.SetActive(false);
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Debug.Log("set");
            resetter = true;
            secondTimer = Random.Range(0.25f, 1.0f);
            CamOneAuxUI.SetActive(true);
        }
    }

    void Reconnecting()
    {
        if (secondTimer > 0)
        {
            secondTimer -= Time.deltaTime;
        }
        if (secondTimer <= 0)
        {
            Debug.Log("Reset");
            timer = Random.Range(minTime, maxTime);
        }
    }
}
