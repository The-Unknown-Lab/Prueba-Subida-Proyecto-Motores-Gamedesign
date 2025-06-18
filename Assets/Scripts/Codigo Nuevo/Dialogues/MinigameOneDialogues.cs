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
        DialogueID[0] = "Bienvenidos al Desafío: “La Verdad de la Milanesa”.\r\nDificultad: La Caminata.\r\nParticipantes: Cuatro.\r\nRoles: Uno será camarero, tres serán comensales.";
        DialogueID[1] = "Reglas:\r\n- Dos rondas.\r\n- En cada ronda, un plato está contaminado con una sustancia letal.\r\n- El camarero elige y sirve. \r\n- Los comensales deben comer lo asignado, pero pueden hablar con el camarero.\r\n- Todos los jugadores que lleguen a la segunda ronda, deben sobrevivir para ganar el desafío.";
        DialogueID[2] = "Dialogo al acercarse a la mesa la primera vez";
        DialogueID[3] = "ID 3";
        DialogueID[4] = "ID 4";
        DialogueID[5] = "ID 5\nFunciona?";

        //Dialogos de finalizacion de ronda
        DialogueID[10] = "Felicitaciones, Nadie murio en la primer ronda";
        DialogueID[11] = "Mala suerte, murio el comensal numero 1 en la primer ronda";
        DialogueID[12] = "Mala suerte, murio el comensal numero 2 en la primer ronda";
        DialogueID[13] = "Mala suerte, murio el comensal numero 3 en la primer ronda";

        DialogueID[14] = "Felicitaciones, Nadie murio en la ronda 2, todos los supervivientes pueden retirarse";
        DialogueID[15] = "Murio el comensal numero 1 en la segunda ronda\nNinguno de los supervivientes sera premiado esta noche";
        DialogueID[16] = "Murio el comensal numero 2 en la segunda ronda\nNinguno de los supervivientes sera premiado esta noche";
        DialogueID[17] = "Murio el comensal numero 3 en la segunda ronda\nNinguno de los supervivientes sera premiado esta noche";


    }



}
