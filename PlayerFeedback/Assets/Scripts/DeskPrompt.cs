using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeskPrompt : MonoBehaviour
{
    [SerializeField] Canvas uiPrompt;
    [SerializeField] GameObject player;

    void Start()
    {
        uiPrompt.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().interactable = true;
            uiPrompt.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent <PlayerMovement>().interactable = false;
            uiPrompt.GetComponent<Canvas>().enabled = false;
        }
    }
}
