using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameOne : MonoBehaviour
{
    private static MinigameOne instance;
    public static MinigameOne Instance => instance;
    public int PlatoEnManoID => platoEnManoID;
    public GameObject PlatoEnManoObj => platoEnManoObject;

    [SerializeField] private GameObject victoryScreen, defeatScreen;
    [SerializeField] private int platoEnManoID;
    [SerializeField] private GameObject platoEnManoObject;
    [SerializeField] private int foodInTables;
    [SerializeField] private GameObject[] mesaObj;

    [SerializeField] private int gameStage;
    [SerializeField] private GameObject[] secondFood;

    private Dictionary<int, int> foodPlaces;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);


        foodPlaces = new Dictionary<int, int>();
        for (int i = 0; i <= 2; i++)
        {
            foodPlaces[i] = 0;
        }

        gameStage = 0;
        gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), new int[] {0,2,5});
    }

    private void Update()
    {
        CheckMinigameStatus();
    }


    public void TomarPlato(GameObject plato, int platoId, int lugarId, int mesaId)
    {
        platoEnManoID = platoId;
        platoEnManoObject = plato;
        Debug.Log("Plato " + platoId + " tomado del lugar " + lugarId + " de la mesa " + mesaId);
        if (mesaId == 1)
        {
            foodPlaces[lugarId] = 0;
            if (foodInTables > 0)
                foodInTables--;

        }
        else if (mesaId == 2)
        {
            foodPlaces[2] = 0;
            if (foodInTables > 0)
                foodInTables--;
        }
        plato.SetActive(false);
    }

    public int DejarPlato(int lugarId, int mesaId)
    {
        int id = platoEnManoID;
        platoEnManoObject.SetActive(true);
        Debug.Log("Plato " + platoEnManoID + " dejado en el lugar " + lugarId + " de la mesa " + mesaId);
        if (mesaId == 1)
        {
            foodPlaces[lugarId] = platoEnManoID;
            if (foodInTables < 4)
                foodInTables++;

        }
        else if (mesaId == 2)
        {
            foodPlaces[2] = platoEnManoID;
            if (foodInTables < 4)
                foodInTables++;

        }


        platoEnManoID = 0;
        platoEnManoObject = null;

        return id;
    }

    private void CheckMinigameStatus()
    {
        if (foodInTables == foodPlaces.Count && gameStage < 2)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("Primera parte del minijuego Terminado");

                for (int i = 0; i < foodPlaces.Count; i++)
                {
                    if (foodPlaces[i] == 1)
                    {
                        //Animacion Comer
                    }
                    else if (foodPlaces[i] == 2)
                    {
                        if (i == 2)
                        {
                            mesaObj[i].GetComponent<MesaScript>().lugares.Remove(mesaObj[i].GetComponent<MesaScript>().lugares[0]);
                        }
                        else
                            mesaObj[1].GetComponent<MesaScript>().lugares.Remove(mesaObj[1].GetComponent<MesaScript>().lugares[i]);
                        foodPlaces[i] = 3;
                    }

                }
                gameStage++;
                PlayEatAnimation();
            }
        }
    }

    private void PlayEatAnimation()
    {
        foodInTables = 0;
        platoEnManoID = 0;
        platoEnManoObject = null;

        for (int i = 0;i < mesaObj.Length; i++)
        {
            if (mesaObj[i].GetComponent<MesaScript>() != null)
            {
                if (i == 0 && gameStage == 1)
                    mesaObj[i].GetComponent<MesaScript>().ResetItems(secondFood);
                else
                    mesaObj[i].GetComponent<MesaScript>().ResetItems(new GameObject[] { null, null, null, null });
            }
        }

        for (int i = 0; i < foodPlaces.Count; i++)
        {
            if (foodPlaces[i] != 3)
                foodPlaces[i] = 0;
            else if (foodPlaces[i] == 3)
                foodInTables++;
        }

        gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), new int[] { 0, 2, 5 });

    }

    private void PlayDeathAnimation()
    {

    }

    private void InicializeSecondRound()
    {

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
