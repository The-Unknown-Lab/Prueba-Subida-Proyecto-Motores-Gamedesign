using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroScript : MonoBehaviour, IInteractuable
{
    [SerializeField] private int index;
    public void OnInteract()
    {
        MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), index);
    }
}
