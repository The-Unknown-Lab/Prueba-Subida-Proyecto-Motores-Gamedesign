using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour, IDialogue
{
    [SerializeField] private List<string> Default, Dialogo1, Plato1, Plato2, Plato3, Plato4, DejarPlato, ComentarioPlato1, ComentarioPlato2, ComentarioPlato3, ComentarioPlato4;
    [SerializeField] private List<string> ComesPlato1, ComesPlato2, ComesPlato3, ComesPlato4;
    private List<string> actualDialogue = new List<string>();

    public List<string> DialogueSelection(int index)
    {
        switch (index)
        {
            default:
                actualDialogue = Default;
                return actualDialogue;
                case 0:
                actualDialogue = Dialogo1;
                return actualDialogue;
                case 1:
                actualDialogue = Plato1;
                return actualDialogue;
                case 2:
                actualDialogue = Plato2;
                return actualDialogue;
                case 3:
                actualDialogue = Plato3;
                return actualDialogue;
                case 4:
                actualDialogue = Plato4;
                return actualDialogue;
                case 5:
                actualDialogue = DejarPlato;
                return actualDialogue;
                case 6:
                    actualDialogue = ComesPlato1;
                return actualDialogue;
                case 7:
                    actualDialogue = ComesPlato2;
                return actualDialogue;
                case 8:
                    actualDialogue = ComesPlato3;
                return actualDialogue;
                case 9:
                    actualDialogue = ComesPlato4;
                return actualDialogue;

            case 11:
                actualDialogue = ComentarioPlato1;
                return actualDialogue;
            case 12:
                actualDialogue = ComentarioPlato2;
                return actualDialogue;
            case 13:
                actualDialogue = ComentarioPlato3;
                return actualDialogue;
            case 14:
                actualDialogue = ComentarioPlato4;
                return actualDialogue;

        }
    }
}
