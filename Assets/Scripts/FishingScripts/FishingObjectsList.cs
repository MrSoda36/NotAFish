using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingObjectsList : MonoBehaviour
{
    private static FishingObjectsList _instance;
    public static FishingObjectsList Instance {
        get {
            if (_instance == null)
            {
                Debug.Log("FishingObjectsList is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = this;
    }
    /// <summary>
    /// Objets pouvant �tre p�ch�s dans l'oc�an (premi�re zone de p�che)
    /// </summary>
    public List<FishScriptableObjects> beachObjects = new List<FishScriptableObjects>();
    /// <summary>
    /// Objets pouvant �tre p�ch�s dans l'�tang (deuxi�me zone de p�che)
    /// </summary>
    public List<FishScriptableObjects> pondObjects = new List<FishScriptableObjects>();
    /// <summary>
    /// Objets pouvant �tre p�ch�s dans la rivi�re dans la grotte (troisi�me zone de p�che)
    /// </summary>
    public List<FishScriptableObjects> caveRiverObjects = new List<FishScriptableObjects>();
    /// <summary>
    /// Objets pouvant �tre p�ch�s dans la derni�re zone 
    /// </summary>
    public List<FishScriptableObjects> lastZoneObjects = new List<FishScriptableObjects>();


}
