using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroScript : MonoBehaviour, IInteractuable
{
    [SerializeField] private int[] index;
    [SerializeField] private int[] newIndex;
    [SerializeField] private string nameOfDialogue;
    [SerializeField] private GameObject triggerZone;
    public void OnInteract()
    {
        DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(MinigameOneDialogues.Instance.gameObject.GetComponent<IDialogue>(), index, nameOfDialogue);
        if (triggerZone != null)
        {
            triggerZone.SetActive(true);
        }
        if (newIndex != null)
        {
            index = newIndex;
            newIndex = null;
        }
    }
}
