using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public int playerMaxHealth;
    public int playerCurrentHealth;
    public float timeToCure;
    private float timeToCureCounter;
    public int cureAmount;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        timeToCureCounter = timeToCure;
    }
    // Update is called once per frame
    void Update()
    {
       if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            Application.Quit();
        }
        if (playerCurrentHealth < playerMaxHealth)
        {
            timeToCureCounter -= Time.deltaTime;
            if(timeToCureCounter <= 0)
            {
                if (playerCurrentHealth <= playerMaxHealth - cureAmount)
                {
                    playerCurrentHealth = playerCurrentHealth + cureAmount;
                    timeToCureCounter = timeToCure;
                }
                else
                {
                    playerCurrentHealth = playerMaxHealth;
                    timeToCureCounter = timeToCure;
                }
            }
        }
    }
    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive; // = playerCurrentHealth = playerCurrentHealth - damageToGive;
        timeToCureCounter = timeToCure;
    }
    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
