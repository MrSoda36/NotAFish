using System.Collections.Generic;
using UnityEngine;

public class FishingObjectsList : MonoBehaviour
{
    public static FishingObjectsList Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

    }
    /// <summary>
    /// Objets pouvant �tre p�ch�s dans l'oc�an (premi�re zone de p�che)
    /// </summary>
    public List<FishScriptableObjects> beachObjects = new List<FishScriptableObjects>();


}
