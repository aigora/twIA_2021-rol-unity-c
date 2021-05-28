using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    // Start is called before the first frame update

    public string itemName;
    public int questNumber;
    private QuestManager theQM;
    

   

    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Hero" && Input.GetKeyDown(KeyCode.F))
        {
            if(!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
            {
                theQM.itemCollected = itemName;
                gameObject.SetActive (false); 
            }
        }
    }
}
