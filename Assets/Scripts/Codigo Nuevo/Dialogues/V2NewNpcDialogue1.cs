using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class V2NewNpcDialogue1 : MonoBehaviour, IInteractuable
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private List<string> lines;
    private float textSpeed = 0.03f;
    private bool onDialogue;
    private int index;

    private void Awake()
    {
        onDialogue = false;
    }

    public void OnInteract()
    {
        //base
    }


    public void OnInteract(IDialogue dialogue, int[] dialogID)
    {
        textComponent.text = string.Empty;
        lines = dialogue.DialogueSelection(dialogID);
        dialogueBox.SetActive(true);
        DialogueManager.Instance.CanMoveNotify(false);
        onDialogue = true;
        StartDialogue();

    }

    void Update()
    {
        if (onDialogue)
        {
            Debug.Log("Index segundo: " + index);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            onDialogue = false;
            dialogueBox.SetActive(false);
            DialogueManager.Instance.CanMoveNotify(true);
        }
    }

}