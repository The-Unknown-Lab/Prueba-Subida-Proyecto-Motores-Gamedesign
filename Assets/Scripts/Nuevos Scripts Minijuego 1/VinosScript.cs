using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinosScript : MonoBehaviour, IInteractuable
{
    [SerializeField] GameObject vinosUI;
    public void OnInteract()
    {
        DialogueManager.Instance.CanMoveNotify2(false);
        vinosUI.SetActive(true);
    }

    public void PressButton(int id)
    {
        if (id == 4)
        {
            DialogueManager.Instance.CanMoveNotify2(true);
            vinosUI.SetActive(false);
        }
        else
            MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), id);

    }
}
