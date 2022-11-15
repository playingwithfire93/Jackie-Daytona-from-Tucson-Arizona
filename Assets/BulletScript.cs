using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 0.0f;
    private Rigidbody2D rbBullet;
    private Vector2 Direction;


    private void Awake()
    {
        rbBullet = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rbBullet.velocity = Direction*speed;
    }
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
}

