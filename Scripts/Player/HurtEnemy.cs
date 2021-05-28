using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public GameObject DamageBurst;
    public Transform HitPoint;
    public GameObject damageNumber;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Instantiate(DamageBurst, other.transform.position, other.transform.rotation);
            var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
        }
    }
}
