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
        //Dialogos voz misteriosa
        DialogueID[0] = "Bienvenidos al Desafío: “La Verdad de la Milanesa”.\r\nDificultad: La Caminata.\r\nParticipantes: Cuatro.\r\nRoles: Uno será camarero, tres serán comensales.";
        DialogueID[1] = "Reglas:\r\n- Dos rondas.\r\n- En cada ronda, un plato está contaminado con una sustancia letal.\r\n- El camarero elige y sirve. \r\n- Los comensales deben comer lo asignado, pero pueden hablar con el camarero.\r\n- Todos los jugadores que lleguen a la segunda ronda, deben sobrevivir para ganar el desafío.";
        DialogueID[2] = "Dialogo al acercarse a la mesa la primera vez";
        DialogueID[3] = "Muy bien, para esta ronda el camarero debera elegir nuevamente entre 4 platos de los cuales solo uno esta envenenado\nConsulta al sommelier con que vinos maridar";
        DialogueID[4] = "ID 4";
        DialogueID[5] = "ID 5\nFunciona?";

        //Dialogos de finalizacion de ronda
        DialogueID[10] = "Felicitaciones, Nadie murio en la primer ronda";
        DialogueID[11] = "Mala suerte, murio el comensal numero 1 en la primer ronda";
        DialogueID[12] = "Mala suerte, murio el comensal numero 2 en la primer ronda";
        DialogueID[13] = "Mala suerte, murio el comensal numero 3 en la primer ronda";

        DialogueID[14] = "Felicitaciones, Nadie murio en la ronda 2, todos los supervivientes pueden retirarse";
        DialogueID[15] = "Murio el comensal numero 1 en la segunda ronda\nNinguno de los supervivientes sera premiado esta noche\nLos supervivientes pueden retirarse";
        DialogueID[16] = "Murio el comensal numero 2 en la segunda ronda\nNinguno de los supervivientes sera premiado esta noche\nLos supervivientes pueden retirarse";
        DialogueID[17] = "Murio el comensal numero 3 en la segunda ronda\nNinguno de los supervivientes sera premiado esta noche\nLos supervivientes pueden retirarse";

        //Dialogos "Protagonista"
        DialogueID[20] = "¡¡Son todos iguales!!\nMisma mila, ¡mismo pure!\nPero... Los platos son de colores diferentes...";
        DialogueID[21] = "El numero 1 es blanco\nEl 2 es rojo\nEl 3 es azul\nEl 4 verde\nY aparte... ¿Vinos?";

        //Dialogos Libro
        DialogueID[25] = "¿El cuaderno del sommelier?\nDescripciones de vinos, recomendaciones…\nParece haber una página marcada con algo escrito...";
        DialogueID[26] = "“Rojo, el color del amor y la advertencia”.\n“Azul es neutral. Verde, confunde. Blanco, engaña.”";

        //Dialogos Vinos
        DialogueID[30] = "Parece que hay vinos que tienen una pista en su etiqueta...";
        DialogueID[31] = "Malbec:\n“Lo dulce en lo rojo puede matar”";
        DialogueID[32] = "Cabernet:\n“La verdad esta en lo simple”";
        DialogueID[33] = "Merlot:\n“El que brilla no siempre es oro, pero aveces si”";
        DialogueID[34] = "Chardonnay:\n“La comida no elige su plato, el veneno si”";
        DialogueID[35] = "Este vino no tiene nada interesante...";

    }



}
