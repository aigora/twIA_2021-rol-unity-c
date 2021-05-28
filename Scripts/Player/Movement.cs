using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{
    public float speed = 4f;
    private Animator anim;
    private Rigidbody2D rb2d;
    Vector2 mov, dir;
    public Vector2 lastMove;
    public bool canMove;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    CircleCollider2D AttackCollider;
    private static bool PlayerExists;
    public string startPoint;
    public AudioSource SwordSound;
    //public int scene;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        canMove = true;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        AttackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        AttackCollider.enabled = false;
        if (!PlayerExists)
        {
            PlayerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
                Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == false)
        {
            mov = Vector2.zero;
            anim.SetBool("Walking", false);
            anim.SetBool("Attacking", false);
            return;
        }
        if (mov != Vector2.zero)
        {
            anim.SetFloat("MovX", mov.x);
            anim.SetFloat("MovY", mov.y);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (!attacking)
        {
            mov = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            AttackCollider.offset = new Vector2(dir.x / 2, dir.y / 2);
            if (mov.x != 0 || mov.y != 0)
            {
                lastMove = mov;
                dir = mov;
            }
            if (Input.GetKey(KeyCode.C))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                mov = Vector2.zero;
                anim.SetBool("Attacking", true);
                AttackCollider.enabled = true;
                SwordSound.Play();
            }
        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attacking", false);
            AttackCollider.enabled = false;
        }
       /*scene = SceneManager.GetActiveScene().buildIndex;
       if (scene == 0)
       {
            //gameObject.SetActive(false);
            Destroy(gameObject);
       }
       if (scene != 0)
       {
            gameObject.SetActive(true);
       }*/
    }
    void FixedUpdate ()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}

