using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    private Rigidbody2D myRigidBody;
    private int walkDirection;

    public bool canMove;
    private DialogueManager theDM;

    public Collider2D walkZone;
    private bool hasWalkzone;
    private Vector2 minWalkpoint;
    private Vector2 maxWalkpoint;

    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        canMove = true;
        theDM = FindObjectOfType<DialogueManager>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
        if (walkZone != null)
        {
            minWalkpoint = walkZone.bounds.min;
            maxWalkpoint = walkZone.bounds.max;
            hasWalkzone = true;
        }
        anime = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!theDM.dialogActive)
        {
            canMove = true;
        }
        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }
        if (isWalking == true)
        {
            walkCounter -= Time.deltaTime;
            switch (walkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    anime.SetFloat("MovY", myRigidBody.velocity.y);
                    if (hasWalkzone == true && transform.position.y > maxWalkpoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    anime.SetFloat("MovX", myRigidBody.velocity.x);
                    if (hasWalkzone == true && transform.position.x > maxWalkpoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    anime.SetFloat("MovY", myRigidBody.velocity.y);
                    if (hasWalkzone == true && transform.position.y < minWalkpoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    anime.SetFloat("MovX", myRigidBody.velocity.x);
                    if (hasWalkzone == true && transform.position.x < minWalkpoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }
            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            anime.SetFloat("MovX", myRigidBody.velocity.x);
            anime.SetFloat("MovY", myRigidBody.velocity.y);
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = waitTime;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = false;
            isWalking = false;
            myRigidBody.velocity = Vector2.zero;
            waitCounter = waitTime;
        }
    }
}