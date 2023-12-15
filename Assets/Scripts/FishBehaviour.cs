using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField] public string fishName;
    [SerializeField] float speed;

    uint direction = 0;

    private void FixedUpdate() {
        if (direction == 0) {
            transform.position += Vector3.left * speed * Time.deltaTime;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            transform.position += Vector3.right * speed * Time.deltaTime;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Wall") {
            if(direction == 0) {
                direction = 1;
            }
            else {
                direction = 0;
            }
        }
    }
}
