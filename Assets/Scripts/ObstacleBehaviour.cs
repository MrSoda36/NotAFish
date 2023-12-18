using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] List<Vector3> Directions;
    private Vector3 Direction;
    private Rigidbody2D rb;
    public bool isBouncing = false;



    void Start()
    {
        Direction = ChooseDirection();
        speed = ChooseSpeed();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isBouncing)
        {
            rb.MovePosition(transform.position + speed * Time.deltaTime * Direction);
        }
        else {
            rb.MovePosition(transform.position + speed * Time.deltaTime * -Direction);

        }
    }

    private Vector3 ChooseDirection()
    {
        Vector3 Direction = Directions[Random.Range(0, Directions.Count-1)];
        return Direction;
    }

    private float ChooseSpeed() {
        float Speed = Random.Range(2f, 3f);
        return Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            if(isBouncing) {
                isBouncing = false;
                speed = ChooseSpeed();
            }
            else {
                isBouncing = true;
                speed = ChooseSpeed();
            }
        }
    }

}
