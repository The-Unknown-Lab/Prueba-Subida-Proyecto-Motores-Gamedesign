using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroScript : MonoBehaviour, IInteractuable
{
    [SerializeField] private int[] index;
    public void OnInteract()
    {
        DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(MinigameOneDialogues.Instance.gameObject.GetComponent<IDialogue>(), index, null);
    }
}
