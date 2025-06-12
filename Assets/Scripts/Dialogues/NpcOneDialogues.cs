using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcOneDialogues : MonoBehaviour, IDialogue
{
    [SerializeField] private int dialogoIndex;
    [SerializeField] private List<string> dialogoNames;
    [SerializeField] private List<List<string>> dialogues;
    private List<string> actualDialogue = new List<string>();

    public List<string> DialogueSelection()
    {
        actualDialogue.Clear();
        switch (dialogoIndex)
        {
            default:
                Dialog1();
                break;

                case 0:
                    Dialog2();
                break;

                case 1:
                    Dialog3();
                break;

                case 2:
                Dialog4();
                break;
                case 3:
                Dialog5();
                break;

        }
        return actualDialogue;
    }

    private void Dialog1()
    {
        actualDialogue.Add("Hola 1");
        actualDialogue.Add("Como estas? 1");
        actualDialogue.Add("Bien y tu? 1");
        actualDialogue.Add("Adios 1");
    }
    private void Dialog2()
    {
        actualDialogue.Add("Hi 2");
        actualDialogue.Add("Donde 2");
        actualDialogue.Add("Goodbye 2");
    }
    private void Dialog3()
    {
        actualDialogue.Add("Adios 3");
        actualDialogue.Add("No? 3");
        actualDialogue.Add("Bye 3");
        actualDialogue.Add("Okey 3");
    }
    private void Dialog4()
    {
        actualDialogue.Add("NPC: Hola 4");
        actualDialogue.Add("Player: Hola 4");
        actualDialogue.Add("NPC: Todo bien? 4");
        actualDialogue.Add("Player: Prueba 4");
        actualDialogue.Add("NPC: Prueba longitud lista 4");
        actualDialogue.Add("Player: Adios 4");
    }

    private void Dialog5()
    {
        actualDialogue.Add("NPC: Hola 5");
        actualDialogue.Add("Player: Hola 5");
        actualDialogue.Add("NPC: Todo bien? 5");
    }
}
