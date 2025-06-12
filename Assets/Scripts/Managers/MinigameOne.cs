using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameOne : MonoBehaviour
{
    private static MinigameOne instance;
    public static MinigameOne Instance => instance;

    [SerializeField] private GameObject victoryScreen, defeatScreen;

    [SerializeField] private int platoEnManoID;
    public int PlatoEnManoID => platoEnManoID;
    [SerializeField] private GameObject platoEnManoObject;
    public GameObject PlatoEnManoObj => platoEnManoObject;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);

        gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), 0);
    }


    public void TomarPlato(GameObject plato, int platoId)
    {
        platoEnManoID = platoId;
        platoEnManoObject = plato;
        plato.SetActive(false);
    }

    public int DejarPlato()
    {
        int id = platoEnManoID;
        platoEnManoObject.SetActive(true);
        platoEnManoID = 0;
        platoEnManoObject = null;
        return id;
    }

    public void EndMinigame(int id)
    {
        switch (id)
        {
            default:
                break;
            case 1:
                victoryScreen.SetActive(true);
                defeatScreen.SetActive(false);
                break;
            case 2:
                defeatScreen.SetActive(true);
                victoryScreen.SetActive(false);
                break;
        }
    }
}
