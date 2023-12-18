using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField] public string fishName;
    [SerializeField] float speed;
    [SerializeField] ParticleSystem particle;

    uint direction = 0;

    private void Start() {
        particle.Stop();
    }

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

        if(collision.gameObject.tag == "Player") {
            StartCoroutine(FishCatched());
        }
    }

    IEnumerator FishCatched() {
        speed = 0;
        particle.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        FishingGameManager.Instance.FishingGameWon();
    }
}
