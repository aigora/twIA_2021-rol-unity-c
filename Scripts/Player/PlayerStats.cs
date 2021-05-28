using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    public int[] HpLvls;
    public int[] AtkLvls;
    public int[] DefLvls;
    public int CurrentHP;
    public int CurrentAtk;
    public int CurrentDef;
    private PlayerHPManager thePlayerHP;
    private HurtEnemy Damage;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HpLvls[1];
        CurrentAtk = AtkLvls[1];
        CurrentDef = DefLvls[1];
        thePlayerHP = FindObjectOfType<PlayerHPManager>();
        Damage = FindObjectOfType<HurtEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
    }
    public void AddExperience(int experienceGained)
    {
        currentExp += experienceGained;
    }
    public void LevelUp()
    {
        currentLevel++;
        CurrentHP = HpLvls[currentLevel];
        thePlayerHP.playerMaxHealth = CurrentHP;
        thePlayerHP.playerCurrentHealth += CurrentHP - HpLvls[currentLevel - 1];
        CurrentAtk = AtkLvls[currentLevel];
        Damage.damageToGive = CurrentAtk;
        CurrentDef = DefLvls[currentLevel];
    }
}
// defensa en espera de ser introducida de forma util en el juego