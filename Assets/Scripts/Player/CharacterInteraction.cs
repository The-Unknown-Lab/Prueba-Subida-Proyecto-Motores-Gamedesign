using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour, ICanMove
{
    private IInteractuable interactable;
    [SerializeField] private GameObject interactionBox;
    private bool canMove, canMove2;

    private void Start()
    {
        canMove = true;
        canMove2 = true;
        DialogueManager.Instance.AddObserverForMove(this);
    }

    private void Update()
    {
        if (interactable != null && canMove && canMove2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.OnInteract();
                interactionBox.transform.position = new Vector2(0, 0);
                interactionBox.SetActive(false);
                interactable = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractuable>() != null && canMove && canMove2)
        {
            interactable = collision.GetComponent<IInteractuable>();
            interactionBox.SetActive(true);
            interactionBox.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractuable>() != null)
        {
            interactable = null;
            interactionBox.SetActive(false);
        }
    }

    public void CanMove(bool state)
    {
        canMove = state;
    }
    public void CanMove2(bool state)
    {
        canMove2 = state;
    }
}
