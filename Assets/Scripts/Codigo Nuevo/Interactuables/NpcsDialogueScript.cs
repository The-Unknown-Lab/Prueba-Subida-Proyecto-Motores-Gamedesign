using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcsDialogueScript : MonoBehaviour, IInteractuable
{
    [SerializeField] private string NpcName;
    [SerializeField] private int[] dialogueIndex;

    public void OnInteract()
    {
        DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(DialogueManager.Instance.gameObject.GetComponent<IDialogue>(), dialogueIndex, NpcName);
    }

    public int[] SeeDialogueIndex()
    {
        return dialogueIndex;
    }
    public void ChangeDialogueIndex(int[] newIndex)
    {
        dialogueIndex = newIndex;
    }
}
