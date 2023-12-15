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
    /// Objets pouvant être pêchés dans l'océan (première zone de pêche)
    /// </summary>
    public List<FishScriptableObjects> oceanObjects = new List<FishScriptableObjects>();
    /// <summary>
    /// Objets pouvant être pêchés dans l'étang (deuxième zone de pêche)
    /// </summary>
    public List<FishScriptableObjects> poundObjects= new List<FishScriptableObjects>();
    /// <summary>
    /// Objets pouvant être pêchés dans la rivière dans la grotte (troisième zone de pêche)
    /// </summary>
    public List<FishScriptableObjects> caveRiverObjects= new List<FishScriptableObjects>();
    /// <summary>
    /// Objets pouvant être pêchés dans la dernière zone 
    /// </summary>
    public List<FishScriptableObjects> lastZoneObjects = new List<FishScriptableObjects>();


}
