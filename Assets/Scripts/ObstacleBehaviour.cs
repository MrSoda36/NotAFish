using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] List<Vector3> Directions;
    private Vector3 Direction;
    private bool isCollision;



    // Start is called before the first frame update
    void Start()
    {
        Direction = ChooseDirection();
        Debug.Log(Direction);
    }

    void Update()
    {
        if (!isCollision)
        {
            this.transform.position += Direction * speed * Time.deltaTime;
        }
        else
        {
            if(Direction == new Vector3(1, 1, 0))
            {
                this.transform.position += new Vector3(-1, 1, 0) * speed * Time.deltaTime;
            }
            else if(Direction == new Vector3(1, -1, 0))
            {
                this.transform.position += new Vector3(-1, -1, 0) * speed * Time.deltaTime;
            }
            else if(Direction == new Vector3(-1, -1, 0))
            {
                this.transform.position += new Vector3(1, -1, 0) * speed * Time.deltaTime;
            }
            else if (Direction == new Vector3(-1, 1, 0))
            {
                this.transform.position += new Vector3(1, 1, 0) * speed * Time.deltaTime;
            }

            else
            {
                this.transform.position -= Direction * speed * Time.deltaTime;
            }
            
        }
    }

    private Vector3 ChooseDirection()
    {
        Vector3 Direction = Directions[Random.Range(0, 8)];
        return Direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isCollision = true;
        }
    }

}
