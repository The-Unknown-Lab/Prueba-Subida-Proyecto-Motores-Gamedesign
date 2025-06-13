using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroScript : MonoBehaviour, IInteractuable
{
    public void OnInteract()
    {
        MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(MinigameOneDialogues.Instance.gameObject.GetComponent<IDialogue>(), new int[] {3});
    }
}
