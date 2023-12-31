using System.Collections;
using UnityEngine;

public class HookBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float depth;
    [SerializeField] FishBehaviour fish;
    [SerializeField] Transform startPoint;

    [Header("Start Animation")]
    [SerializeField] Animator leaveSceneAnim;

    [Header("Particles")]
    [SerializeField] ParticleSystem bubble;
    [SerializeField] ParticleSystem sparkle;
    [SerializeField] ParticleSystem bubbleExplosion;
    [SerializeField] ParticleSystem bubbleSpeed;
    [SerializeField] ParticleSystem lineSpeed;

    [Header("Audio")]
    [SerializeField] AudioClip collisionClip;
    [SerializeField] AudioClip bubblingLoopClip;

    Rigidbody2D rb;

    bool isFinished = false;

    ParticleSystem.MainModule bubbleMain;

    private void Awake() {
        bubbleMain = bubble.main;
        bubbleMain.prewarm = true;
    }

    private void Start() {
        this.gameObject.transform.position = startPoint.position;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        SoundManager.SoundInstance.PlayAmbiantSound(bubblingLoopClip);

        bubble.Play();
        sparkle.Stop();
        bubbleExplosion.Stop();
        bubbleSpeed.gameObject.SetActive(false);
        lineSpeed.gameObject.SetActive(false);

        bubbleMain.prewarm = false;
    }

    void FixedUpdate() {

        rb.gravityScale = 1;

        if (!isFinished) {
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

                bubbleSpeed.gameObject.SetActive(true);
                lineSpeed.gameObject.SetActive(true);
            }
            else {
                bubbleSpeed.gameObject.SetActive(false);
                lineSpeed.gameObject.SetActive(false);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Fish") {
            fish = collision.gameObject.GetComponent<FishBehaviour>();
            //Debug.Log("Fish caught: " + fish.fishName);
            isFinished = true;
        }
        if(collision.gameObject.tag == "Ground") {
            //Debug.Log("Ground hit");
            isFinished = true;
            SoundManager.SoundInstance.PlaySound(collisionClip);
            StartCoroutine(BubbleExplosion());
        }
        if(collision.gameObject.tag == "Wall") {
            //Debug.Log("Wall hit");
            sparkle.Play();
            SoundManager.SoundInstance.PlaySound(collisionClip);
            FishingGameManager.Instance.wallHit++;
            // Debug.Log(FishingGameManager.Instance.wallHit);
        }

    }



    IEnumerator BubbleExplosion() {
        bubbleExplosion.Play();
        sparkle.Play();
        yield return new WaitForSeconds(0.7f);
        leaveSceneAnim.SetTrigger("LeaveScene");
        yield return new WaitForSeconds(1.3f);
        FishingGameManager.Instance.FishingGameLost();
    }

    public void GoBackAtTop() {
        transform.position = startPoint.position;
    }
}
