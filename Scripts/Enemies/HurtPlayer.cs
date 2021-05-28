using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public float atkRange;
    private float lastAtkTime;
    public float atkDelay;
    public Transform target;
    public PlayerHPManager theHPMan;
    public AudioSource AttackSound;
    public GameObject damageNumber;

    private Animator animer;
    // Start is called before the first frame update
    void Start()
    {
        theHPMan = FindObjectOfType<PlayerHPManager>();
        target = FindObjectOfType<Movement>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceToPlayer < atkRange)
        {
            if (Time.time > lastAtkTime + atkDelay)
            {
                theHPMan.HurtPlayer(damageToGive);
                lastAtkTime = Time.time;
                AttackSound.Play();
                var clone = (GameObject)Instantiate(damageNumber, target.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
            }
        }
    }
}
// aunque haya referencias a defensa en el codigo, se esta viendo como crear dicho sistema, ya que no estamos seguros de como queremos definir a este
