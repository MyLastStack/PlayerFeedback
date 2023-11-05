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

    bool CamOneActive = false;

    float minTime = 0.5f;
    float maxTime = 2.0f;
    float timer;

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
            ReconnectingCam();
        }
    }

    public void UseCamOne()
    {
        secCamOne.depth = 2.0f;
        secCamTwo.depth = 0f;

        CamOneActive = true;
    }

    public void UseCamTwo()
    {
        secCamOne.depth = 0f;
        secCamTwo.depth = 2.0f;

        CamOneActive = false;
        CamOneAuxUI.SetActive(false);
    }

    void ReconnectingCam()
    {
        if (timer > 0)
        {
            CamOneAuxUI.SetActive(false);
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            CamOneAuxUI.SetActive(true);
            timer = Random.Range(minTime, maxTime);
        }
    }
}
