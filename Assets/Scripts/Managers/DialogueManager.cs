using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public static DialogueManager Instance => instance;

    List<ICanMove> canMoveObservers = new List<ICanMove>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddObserverForMove(ICanMove observer)
    {
        if (!canMoveObservers.Contains(observer))
            canMoveObservers.Add(observer);
    }

    public void RemoveObserverForMove(ICanMove observer)
    {
        if (canMoveObservers.Contains(observer))
            canMoveObservers.Remove(observer);
    }


    public void CanMoveNotify(bool state)
    {
        for (int i = 0; i < canMoveObservers.Count; i++)
        {
            canMoveObservers[i].CanMove(state);
        }
    }
    public void CanMoveNotify2(bool state)
    {
        for (int i = 0; i < canMoveObservers.Count; i++)
        {
            canMoveObservers[i].CanMove2(state);
        }
    }
}
