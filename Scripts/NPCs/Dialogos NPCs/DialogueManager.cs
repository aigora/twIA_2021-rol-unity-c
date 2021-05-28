using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;
    public TMP_Text text;
    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private Movement thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Movement>();
        currentLine = 0;     
    }
    // Update is called once per frame
    void Update()
    { 
        if (dialogActive == true)
        {           
            //dText.text = dialogLines[currentLine];
            text.text = dialogLines[currentLine];
        }
        if (dialogActive && Input.GetKeyDown(KeyCode.Return))
        {
            currentLine++;
        }
        if (currentLine >= dialogLines.Length)
        {
            dialogActive = false;
            dBox.SetActive(false);
            currentLine = 0;
            thePlayer.canMove = true;
        }     
    }
    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}