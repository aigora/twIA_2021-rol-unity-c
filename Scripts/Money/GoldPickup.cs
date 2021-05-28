using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int value;
    public GoldManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GoldManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Hero")
        {
            GM.AddGold(value);
            Destroy(gameObject);
        }
    }
}
