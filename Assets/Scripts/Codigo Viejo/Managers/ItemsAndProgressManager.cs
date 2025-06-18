using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAndProgressManager : MonoBehaviour
{
    private static ItemsAndProgressManager instance;
    public static ItemsAndProgressManager Instance => instance;

    private Dictionary<int, int> itemsID;
    private Dictionary<string, int> progressionID;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (itemsID == null)
            itemsID = new Dictionary<int, int>();
        if (progressionID == null)
            progressionID = new Dictionary<string, int>();

        itemsID[0] = 0;
        itemsID[1] = 0;
        itemsID[2] = 0;
        progressionID["uno"] = 0;
    }

    public void ModifyItems(int id, int itemValue)
    {
        itemsID[id] += itemValue;
        Debug.Log("Item Guardado");
    }
    public void ModifyProgress(string id, int progressValue)
    {
        progressionID[id] += progressValue;
        Debug.Log("Progreso Guardado");

    }

    public int SeeItems(int id)
    {
        int progressVal = itemsID[id];
        Debug.Log("Item Visto");
        return progressVal;
    }

    public int SeeProgress(string id)
    {
        int progressVal = progressionID[id];
        Debug.Log("Progreso Visto");
        return progressVal;
    }

}
