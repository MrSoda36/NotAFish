using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UIEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    Transform transform;
    private Vector3 defaultScale;

    void Start() {
        transform = this.gameObject.GetComponent<Transform>();
        defaultScale = this.transform.localScale;
    }

    void Enlarge() {
        Vector3 enlarge = defaultScale * 1.2f;
        this.transform.DOScale(enlarge, 0.05f);
    }

    void Shrink() {
        this.transform.DOScale(defaultScale, 0.05f);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Enlarge();
    }

    public void OnPointerExit(PointerEventData eventData) {
        Shrink();
    }
}
