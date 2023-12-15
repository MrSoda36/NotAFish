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
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isBouncing)
        {
            rb.MovePosition(transform.position + Direction * speed * Time.deltaTime);
        }
        else {
            rb.MovePosition(transform.position + -Direction * speed * Time.deltaTime);

        }
    }

    private Vector3 ChooseDirection()
    {
        Vector3 Direction = Directions[Random.Range(0, Directions.Count-1)];
        return Direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            if(isBouncing) {
                isBouncing = false;
            }
            else {
                isBouncing = true;
            }
        }
    }

}
