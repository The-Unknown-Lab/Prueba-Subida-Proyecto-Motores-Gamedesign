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
    [SerializeField] private int[] jugadoresVivos;

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
        foodPlaces[0] = 0;
        foodPlaces[1] = 0;
        foodPlaces[2] = 0;


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
        Debug.Log(foodPlaces[0] + " " + foodPlaces[1] + " " + foodPlaces[2]);
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
        Debug.Log(foodPlaces[0] + " " + foodPlaces[1] + " " + foodPlaces[2]);


        platoEnManoID = 0;
        platoEnManoObject = null;

        return id;
    }

    private void CheckMinigameStatus()
    {
        if (foodInTables == 3)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("Primera parte del minijuego Terminado" );

                for (int i = 0; i < foodPlaces.Count; i++)
                {
                    if (foodPlaces[i] == 1)
                    {
                        jugadoresVivos[i] = foodPlaces[i];
                        Debug.Log("La persona del lugar " + i + " sobrevivio");
                    }
                    else
                        Debug.Log("La persona del lugar " + i + " murio");

                }

                PlayAnimation();

                InicializeSecondRound();
            }
        }
    }

    private void PlayAnimation()
    {

    }

    private void InicializeSecondRound()
    {
        Debug.Log("Inicia la segunda ronda del minijuego, quedaron vivos los jugaadores de los lugares " + jugadoresVivos);
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
