using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsDialogueScript : MonoBehaviour, IInteractuable
{
    [SerializeField] private string NpcName;
    [SerializeField] private int[] dialogueIndex;

    public void OnInteract()
    {
        DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(MinigameOneDialogues.Instance.gameObject.GetComponent<IDialogue>(), dialogueIndex);
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
