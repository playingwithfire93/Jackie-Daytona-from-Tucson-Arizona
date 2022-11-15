using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private SpriteRenderer spr;
    private Rigidbody2D rbPlayer;
    private Animator animator;
    //public GameObject weaponPoint;
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private Vector2 movement;
    [SerializeField] private int JumpForce;
    [SerializeField] private bool isOnGround= false;
    [SerializeField] private bool facingRight= false;

    public GameObject bulletPrefab;
    public Transform weapon;
    //public BulletScript bscrp;

    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        //weaponPoint = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        //bscrp = GetComponent<BulletScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        movement = new Vector2(h, 0.0f);
        //animator.SetBool("isIdle", movement == Vector2.zero);
        animator.SetBool("isIdle", h == 0.0f);

        Debug.DrawRay(transform.position, Vector3.down, Color.yellow);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.0f))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround ==true))
        {
            Jump();
        }
        if (h>0.0f && facingRight == true)
        {
            Flip();
        }else if (h < 0.0f && facingRight == false)
        {
            Flip();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }


    private void FixedUpdate()
    {
        float hvelocity = movement.x * speed;
        rbPlayer.velocity = new Vector2(hvelocity, rbPlayer.velocity.y );
    }
    private void Flip()
    {
        facingRight =  !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1.0f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);          
    }
    private void Jump()
    {
        rbPlayer.AddForce(Vector2.up * JumpForce,ForceMode2D.Impulse);
    }

    public void Shoot()
    {
        Vector2 direction;
        if (transform.localScale.x > 0.0f)
        {
            direction = Vector2.right;
        }
        else direction = Vector2.left;
        // Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        GameObject bullet = Instantiate(bulletPrefab, weapon.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = collision.transform;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = null;

        }
    }
    private void LateUpdate()
    {
       animator.SetBool("Grounded", isOnGround);
    }

}
