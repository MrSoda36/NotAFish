using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HookBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float depth;
    [SerializeField] FishBehaviour fish;


    void Update() {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Fish") {
            fish = collision.gameObject.GetComponent<FishBehaviour>();
            Debug.Log("Fish caught: " + fish.fishName);
            Destroy(collision.gameObject);
            GoBackAtTop();
        }
        if(collision.gameObject.tag == "Ground") {
            Debug.Log("Ground hit");
            GoBackAtTop();
        }
    }

    public void GoBackAtTop() {
        transform.position = new Vector3(0, 5, 0);
    }
}
