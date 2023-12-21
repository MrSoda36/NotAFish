using UnityEngine;
using TMPro;

public class CreditMovement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float speed;

    private void Update() {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
