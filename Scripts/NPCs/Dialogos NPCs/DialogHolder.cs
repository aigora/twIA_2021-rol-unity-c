using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;

    public string[] dialogueLines;

    public bool hasQuest;  // Hablar con el personaje empezar? la misi?n.
    public bool hasQuest2; // Hablar con el personaje mostrar? un dialogo dependiendo de la mision. No empieza la misi?n.
    public int questNumber;
    public string[] dialogueDuringQuest;
    public string[] dialogueBeforeQuest;
    private GoldManager theGM;
    private QuestObject theQuest;
    private QuestManager theQM;
    private QuestTrigger theQT;
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        theQuest = FindObjectOfType<QuestObject>();
        theQM = FindObjectOfType<QuestManager>();
        theQT = FindObjectOfType<QuestTrigger>();
        theGM = FindObjectOfType<GoldManager>();

        theQuest = theQM.quests[questNumber];
    }

    // Update is called once per frame
    void Update()
    {
        if (theQM.questCompleted[questNumber])
        {
            hasQuest = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Hero")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (!hasQuest)
                {
                    if (!dMan.dialogActive)
                    {
                        dMan.dialogLines = dialogueLines;
                        dMan.currentLine = 0;
                        dMan.ShowDialogue();
                    }
                    if (transform.parent.GetComponent<VillagerMovement>() != null)
                    {
                        transform.parent.GetComponent<VillagerMovement>().canMove = false;
                    }
                }
                if (hasQuest && theQuest.duringQuest == false && theQuest.isUnlocked == false)
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].SartQuest();
                    theQuest.duringQuest = true;

                    if (transform.parent.GetComponent<VillagerMovement>() != null)
                    {
                        transform.parent.GetComponent<VillagerMovement>().canMove = false;
                    }
                }
                if (hasQuest && theQuest.duringQuest == false && theQuest.isUnlocked == true && theQM.questCounter < theQuest.questNeededToUnlock && hasQuest2 == false)
                {
                    dMan.dialogLines = dialogueBeforeQuest;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();

                    if (transform.parent.GetComponent<VillagerMovement>() != null)
                    {
                        transform.parent.GetComponent<VillagerMovement>().canMove = false;
                    }
                }
                if (hasQuest && theQuest.duringQuest == false && theQuest.isUnlocked == true && theQM.questCounter >= theQuest.questNeededToUnlock && hasQuest2 == false)
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].SartQuest();
                    theQuest.duringQuest = true;

                    if (transform.parent.GetComponent<VillagerMovement>() != null)
                    {
                        transform.parent.GetComponent<VillagerMovement>().canMove = false;
                    }
                }
                if (theQuest.duringQuest == true)
                {
                    if (!dMan.dialogActive)
                    {
                        dMan.dialogLines = dialogueDuringQuest;
                        dMan.currentLine = 0;
                        dMan.ShowDialogue();

                        if (transform.parent.GetComponent<VillagerMovement>() != null)
                        {
                            transform.parent.GetComponent<VillagerMovement>().canMove = false;
                        }
                    }

                }
                if (hasQuest2 == true)
                {
                    if (theQM.quests[questNumber].gameObject.activeSelf == false)
                    {
                        dMan.dialogLines = dialogueBeforeQuest;
                        dMan.currentLine = 0;
                        dMan.ShowDialogue();

                        if (transform.parent.GetComponent<VillagerMovement>() != null)
                        {
                            transform.parent.GetComponent<VillagerMovement>().canMove = false;
                        }
                    }
                }
                if (theQuest.isFinalQuest == true)
                {
                    if (theGM.currentGold < theQuest.goldNeeded)
                    {
                        if (!dMan.dialogActive && theQM.quests[questNumber].gameObject.activeSelf == true)
                        {
                            dMan.dialogLines = dialogueBeforeQuest;
                            dMan.currentLine = 0;
                            dMan.ShowDialogue();

                            if (transform.parent.GetComponent<VillagerMovement>() != null)
                            {
                                transform.parent.GetComponent<VillagerMovement>().canMove = false;
                            }
                        }
                    }
                    if (theGM.currentGold >= theQuest.goldNeeded && theQM.quests[questNumber].gameObject.activeSelf == true)
                    {
                        theQM.quests[questNumber].EndQuest();
                    }
                }
            }
        }
    }
}
    
