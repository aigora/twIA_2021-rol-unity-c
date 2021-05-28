using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHouse : MonoBehaviour
{
    public QuestManager theQM;
    public bool isActive;
    public int questcompleted;
    // Start is called before the first frame update
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        questcompleted = theQM.questCounter;
        if (theQM.questCounter == 7)
        {
            isActive = true;
        }
        if (isActive == false) 
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
       if(isActive == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
