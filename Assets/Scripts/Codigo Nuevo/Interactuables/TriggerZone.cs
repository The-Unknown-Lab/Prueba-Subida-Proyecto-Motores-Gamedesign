using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] int[] index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(DialogueManager.Instance.gameObject.GetComponent<IDialogue>(), index, "Voz Misteriosa");
            Destroy(gameObject);
        }
    }
}
