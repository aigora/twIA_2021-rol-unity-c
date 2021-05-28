using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public Movement player;
    public PlayerHPManager HPMan;
    public PlayerStats stats;
    public GoldManager GdMn;
    public QuestManager QMan;
    public int scenE;
public void SavePlayer()
    {
        stats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<Movement>();
        HPMan = FindObjectOfType<PlayerHPManager>();
        GdMn = FindObjectOfType<GoldManager>();
        QMan = FindObjectOfType<QuestManager>();
        scenE = SceneManager.GetActiveScene().buildIndex;
        SaveSystem.SavePlayer(stats, player, HPMan, GdMn, QMan,scenE);
    }
public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        stats.currentLevel = data.level;
        HPMan.playerCurrentHealth = data.health;
        HPMan.playerMaxHealth = data.maxhp;
        stats.currentExp = data.xp;
        GdMn.currentGold = data.coins;
        QMan.questCompleted = data.QuestsCompleted;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        SceneManager.LoadScene(scenE);
        player.transform.position = position;
    }
}
