using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Npc : MonoBehaviour
{
    public TMP_Text myText;
    public string tutorialText;
    public string additionalText;
    public string thirdText; 
    public KeyCode interactionKey = KeyCode.E; 

    private bool playerInRange = false;
    private int interactionCount = 0; 

    void Start()
    {
        myText.text = ""; 
    }

    void Update()
    {
      
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            interactionCount++;

            switch (interactionCount)
            {
                case 1:
                    myText.text = tutorialText;
                    break;
                case 2:
                    myText.text = additionalText;
                    break;
                case 3:
                    myText.text = thirdText;
                    break;
                default:
                    myText.text = ""; 
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myText.text = tutorialText;
            playerInRange = true;
            interactionCount = 0; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            myText.text = "";
            playerInRange = false;
            interactionCount = 0; 
        }
    }
}
