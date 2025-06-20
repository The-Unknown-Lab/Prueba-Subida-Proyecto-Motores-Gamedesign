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
        if (id == 36)
        {
            DialogueManager.Instance.CanMoveNotify2(true);
            vinosUI.SetActive(false);
        }
        else
            DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(DialogueManager.Instance.gameObject.GetComponent<IDialogue>(), new int[] { id }, "Protagonista");
    }
}
