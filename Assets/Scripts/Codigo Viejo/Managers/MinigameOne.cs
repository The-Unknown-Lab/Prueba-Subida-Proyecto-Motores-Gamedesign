using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameOne : MonoBehaviour
{
    private static MinigameOne instance;
    public static MinigameOne Instance => instance;
    public int PlatoEnManoID => platoEnManoID;
    public GameObject PlatoEnManoObj => platoEnManoObject;

    [SerializeField] private GameObject victoryScreen, defeatScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] mesaObj;
    [SerializeField] private GameObject platoEnManoObject;
    [SerializeField] private GameObject[] Npcs;
    [SerializeField] private CinemachineVirtualCamera m_Camera;
    [SerializeField] private GameObject roundButton, levelExit;
    [SerializeField] private GameObject triggerSecondRound, wines;

    [SerializeField] private int platoEnManoID;
    [SerializeField] private int foodInTables;

    [SerializeField] private int gameStage;
    [SerializeField] private GameObject[] secondFood;

    int finishedCorrutines, totalCorrutines;


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

        for (int i = 0; i < Npcs.Length; i++)
        {
            StartCoroutine(PlayAnimation(Npcs[i], "Idle", i));
        }

        gameStage = 0;
        DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(DialogueManager.Instance.gameObject.GetComponent<IDialogue>(), new int[] {0,1}, "Voz Misteriosa");
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

    public void CheckMinigameStatus(bool button)
    {
        if (foodInTables == foodPlaces.Count && gameStage < 2 && button)
        {
            if (roundButton.activeSelf == false)
                roundButton.SetActive(true);
        }
        else
        {
            if (roundButton.activeSelf == true)
                roundButton.SetActive(false);
        }
    }

    public void EndRound()
    {
        roundButton.SetActive(false);
        Debug.Log("Primera parte del minijuego Terminado");
        finishedCorrutines = 0;
        totalCorrutines = 0;
        float val = 0;


        for (int i = 0; i < foodPlaces.Count; i++)
        {
            if (foodPlaces[i] == 1)
            {
                StartCoroutine(PlayAnimation(Npcs[i], "NpcEat", val));
                val += 3f;
                totalCorrutines++;
            }
            else if (foodPlaces[i] == 2)
            {
                if (i == 2)
                {
                    mesaObj[i].GetComponent<MesaScript>().lugares.Remove(mesaObj[i].GetComponent<MesaScript>().lugares[0]);
                }
                else
                    mesaObj[1].GetComponent<MesaScript>().lugares.Remove(mesaObj[1].GetComponent<MesaScript>().lugares[i]);
                StartCoroutine(PlayAnimation(Npcs[i], "NpcDeath", val));
                val += 3f;
                totalCorrutines++;
                Npcs[i].GetComponent<NpcsDialogueScript>().ChangeDialogueIndex(new int[] { 40 });
                foodPlaces[i] = 3;
            }

        }
        gameStage++;

    }

    private IEnumerator PlayAnimation(GameObject Npc, string animName, float time)
    {
        yield return new WaitForSeconds(time);

        Npc.GetComponent<Animator>().Play(animName);

        finishedCorrutines++;

        if (animName != "Idle")
        {
            m_Camera.Follow = Npc.transform;
            m_Camera.m_Lens.OrthographicSize = 2.5f;

            if (finishedCorrutines == totalCorrutines)
            {
                Invoke("ResetCameraPosition", 3.5f);
                Invoke("NextStage", 4f);
                finishedCorrutines = 0;
                totalCorrutines = 0;
            }
        }

    }

    private void ResetCameraPosition()
    {
        m_Camera.Follow = player.transform;
        m_Camera.m_Lens.OrthographicSize = 5f;
    }

    private void NextStage()
    {
        foodInTables = 0;
        platoEnManoID = 0;
        platoEnManoObject = null;

        for (int i = 0; i < mesaObj.Length; i++)
        {
            if (mesaObj[i].GetComponent<MesaScript>() != null)
            {
                if (i == 0 && gameStage == 1)
                    mesaObj[i].GetComponent<MesaScript>().ResetItems(secondFood);
                else
                    mesaObj[i].GetComponent<MesaScript>().ResetItems(new GameObject[] { null, null, null, null });
            }
        }

        foreach(var key in foodPlaces.Keys.ToList())
        {
            if (foodPlaces[key] < 3)
                foodPlaces[key] = 0;
            else if (foodPlaces[key] == 3)
                foodInTables++;
        }

        int deathId = 10;
        foreach (var id in foodPlaces)
        {
            if (id.Value == 3)
            {
                deathId = id.Key + 11;
                foodPlaces[id.Key] = 4;
                break;
            }
            else
            {
                deathId = 10;
            }
        }
        if (gameStage < 2)
        {
            //Pasa a la siguiente ronda
            DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(DialogueManager.Instance.gameObject.GetComponent<IDialogue>(), new int[] { deathId, 3}, "Voz Misteriosa");
            triggerSecondRound.SetActive(true);
            wines.SetActive(true);
        }
        else
        {
            //Codigo de cuando haya sido la ultima ronda
            DialogueManager.Instance.gameObject.GetComponent<DialoguesManager>().OnInteract(DialogueManager.Instance.gameObject.GetComponent<IDialogue>(), new int[] { deathId + 4 }, "Voz Misteriosa");
            levelExit.SetActive(true);
        }


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
