using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField] public string fishName;
    [SerializeField] public float weight;
    [SerializeField] float speed;
    [SerializeField] float depth;
    [SerializeField] int value;
    [SerializeField] int rarity;

    IEnumerator LifeTime() {
        yield return new WaitForSeconds(Random.Range(1, 10));
        Destroy(gameObject);
    }
}
