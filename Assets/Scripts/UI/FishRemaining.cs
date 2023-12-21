using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishRemaining : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fishRemainingText;

    void Start()
    {
       fishRemainingText.text = FishingObjectsList.Instance.beachObjects.Count.ToString() + " Remaining(s)";
    }

    public void SetRemainingFish(List<FishScriptableObjects> list)
    {
        fishRemainingText.text = list.Count.ToString() + " Remaining(s)";
    }
}
