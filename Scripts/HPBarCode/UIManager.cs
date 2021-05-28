using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider HPBar;
    public Text HPText;
    public PlayerHPManager playerHealth;
    private static bool BarExists;

    private PlayerStats PS;
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        if(!BarExists)
        {
            BarExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.maxValue = playerHealth.playerMaxHealth;
        HPBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP:" + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        levelText.text = "Lvl: " + PS.currentLevel;
    }
}
