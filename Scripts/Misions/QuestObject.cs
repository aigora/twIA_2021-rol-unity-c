using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;

    public QuestManager theQM;
    public bool duringQuest;

    public string startText;
    public string endText;
    public DialogHolder theDH;

    public bool isItemQuest;
    public string targetItem;

    public bool isFinalQuest;
    public int goldNeeded;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCount;

    public GoldManager GM;
    public int questGoldReward;

    public DialogueManager theDM;
    public bool isUnlocked;
    public int questNeededToUnlock;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        theDH = FindObjectOfType<DialogHolder>();
        GM = FindObjectOfType<GoldManager>();
    }
    // Update is called once per frame
    void Update()
    {  
            if (isItemQuest)
            {
                if (theQM.itemCollected == targetItem)
                {
                    theQM.itemCollected = null;
                    EndQuest();
                }
            }
            if (isEnemyQuest)
            {
                if (theQM.enemyKilled == targetEnemy)
                {
                    theQM.enemyKilled = null;
                    enemyKillCount++;
                }
                if (enemyKillCount >= enemiesToKill)
                {
                    EndQuest();
                }
            }
    }
    public void SartQuest()
    {
        theQM.ShowQuestText(startText);
        duringQuest = false;
    }
    public void EndQuest()
    {
        if (theQM.quests[questNumber].isFinalQuest == true)
        {
            theQM.ShowQuestText(endText);
            GM.currentGold = GM.currentGold - goldNeeded;
            theQM.questCounter = theQM.questCounter + 1;
            theQM.questCompleted[questNumber] = true;
            gameObject.SetActive(false);
            duringQuest = false;
            GM.AddGold(questGoldReward);
        }
        else
        {
            theQM.questCounter = theQM.questCounter + 1;
            theQM.ShowQuestText(endText);
            theQM.questCompleted[questNumber] = true;
            gameObject.SetActive(false);
            duringQuest = false;
            GM.AddGold(questGoldReward);
        }
    }
}
