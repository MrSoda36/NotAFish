using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HookBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float depth;
    [SerializeField] FishBehaviour fish;
    [SerializeField] Transform startPoint;

    private void Start() {
        this.gameObject.transform.position = startPoint.position;
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void FixedUpdate() {
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        transform.position += Vector3.down * 2 * Time.deltaTime;
        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position += Vector3.up * 1 * Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Fish") {
            fish = collision.gameObject.GetComponent<FishBehaviour>();
            Debug.Log("Fish caught: " + fish.fishName);
            Destroy(collision.gameObject);

            FishingGameManager.Instance.FishingGameWon();
        }
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall") {
            //Debug.Log("Ground hit");
            FishingGameManager.Instance.FishingGameLost();
        }
    }

    public void GoBackAtTop() {
        transform.position = startPoint.position;
    }
}
