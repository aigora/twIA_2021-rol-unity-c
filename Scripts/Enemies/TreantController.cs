using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreantController : MonoBehaviour
{
    public Transform initialPosition;
    private Animator myAnim;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<Movement>().transform;
    }
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            ResetPosition();
        }
    }
    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void ResetPosition()
    {
        myAnim.SetFloat("moveX", (initialPosition.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (initialPosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, initialPosition.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, initialPosition.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }
}