using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    public string enemyQuestName;
    private QuestManager theQM;

    private PlayerStats thePlayerStats;
    public int ExpPerKill;

    public GameObject Coin;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        theQM = FindObjectOfType<QuestManager>();
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;
            Instantiate(Coin, new Vector3(this.transform.position.x,this.transform.position.y,0), Quaternion.identity);
            Destroy(gameObject);
            thePlayerStats.AddExperience(ExpPerKill);
        }
    }
    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive; // = CurrentHealth = CurrentHealth - damageToGive;
    }
    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}