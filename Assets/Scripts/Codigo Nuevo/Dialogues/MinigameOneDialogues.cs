using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameOneDialogues : MonoBehaviour, IDialogue
{
    private static MinigameOneDialogues instance;
    public static MinigameOneDialogues Instance => instance;

    private Dictionary<int, string> DialogueID;

    private List<string> DialogueListToReturn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        DialogueListToReturn = new List<string>();
        DialogueID = new Dictionary<int, string>();
        Dialogues();
    }


    //Metodo que busca que IDs de dialogos se necesitan y luego se encarga de devolver dichos dialogos
    public List<string> DialogueSelection(int[] IDs) 
    {
        DialogueListToReturn.Clear();
        for (int i = 0; i < IDs.Length; i++)
        {
            DialogueListToReturn.Add(DialogueID[IDs[i]]);
        }
        return DialogueListToReturn;
    }


    protected virtual void Dialogues()
    {
        DialogueID[0] = "Hola";
        DialogueID[1] = "Adios";
        DialogueID[2] = "No lo se";
        DialogueID[3] = "ID 3";
        DialogueID[4] = "ID 4";
        DialogueID[5] = "ID 5\nFunciona?";

        //Dialogos de muerte
        DialogueID[10] = "Felicitaciones, Nadie murio esta ronda";
        DialogueID[11] = "Mala suerte, murio el comensal numero 1";
        DialogueID[12] = "Mala suerte, murio el comensal numero 2";
        DialogueID[13] = "Mala suerte, murio el comensal numero 3";

    }



}
