using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public Text moneyText;
    public int currentGold;
    // Start is called before the first frame update
    void Start()
    {
        currentGold = 0;
        moneyText.text = "Gold: " + currentGold;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddGold(int goldGained)
    {
        currentGold += goldGained;
        moneyText.text = "Gold: " + currentGold;
    }
}