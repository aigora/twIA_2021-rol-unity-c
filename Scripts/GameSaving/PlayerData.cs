using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int health;
    public int maxhp;
    public int xp;
    public int coins;
    public bool[] QuestsCompleted;
    public float[] position;
    public PlayerData(PlayerStats stats,Movement player, PlayerHPManager HPMan, GoldManager GdMn, QuestManager QMan,int scenE)
    {
        level = stats.currentLevel;
        health = HPMan.playerCurrentHealth;
        maxhp = HPMan.playerMaxHealth;
        xp = stats.currentExp;
        coins = GdMn.currentGold;
        QuestsCompleted = QMan.questCompleted;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
        scenE = SceneManager.GetActiveScene().buildIndex;
    }

}
