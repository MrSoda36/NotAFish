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

    [Header("Particles")]
    [SerializeField] ParticleSystem bubble;
    [SerializeField] ParticleSystem sparkle;
    [SerializeField] ParticleSystem bubbleExplosion;
    [SerializeField] ParticleSystem bubbleSpeed;
    [SerializeField] ParticleSystem lineSpeed;

    Rigidbody2D rb;

    bool isFinished = false;

    private void Start() {
        this.gameObject.transform.position = startPoint.position;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        sparkle.Stop();
        bubbleExplosion.Stop();
        bubbleSpeed.Stop();
        lineSpeed.Stop();
    }

    void FixedUpdate() {
        rb.gravityScale = 1;
        Debug.Log("Speedy Bubbles is emmiting : " + bubbleSpeed.isEmitting);
        if(!isFinished) {
            transform.position += Vector3.down * 2 * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                transform.position += Vector3.up * 1 * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                transform.position += Vector3.down * speed * Time.deltaTime;
                bubbleSpeed.Play();
                lineSpeed.Play();
            }

            if(Input.GetKeyUp(KeyCode.DownArrow)) {
                bubbleSpeed.Stop();
                lineSpeed.Stop();;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Fish") {
            fish = collision.gameObject.GetComponent<FishBehaviour>();
            Debug.Log("Fish caught: " + fish.fishName);
            isFinished = true;
        }
        if(collision.gameObject.tag == "Ground") {
            //Debug.Log("Ground hit");
            StartCoroutine(BubbleExplosion());
        }
        if(collision.gameObject.tag == "Wall") {
            //Debug.Log("Wall hit");
            sparkle.Play();
        }
    }

    IEnumerator BubbleExplosion() {
        bubbleExplosion.Play();
        yield return new WaitForSeconds(1f);
        FishingGameManager.Instance.FishingGameLost();
    }

    public void GoBackAtTop() {
        transform.position = startPoint.position;
    }
}
