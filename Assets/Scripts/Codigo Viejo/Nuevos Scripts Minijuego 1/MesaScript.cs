using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MesaScript : MonoBehaviour, IInteractuable
{
    [SerializeField] private CinemachineVirtualCamera m_Camera;
    [SerializeField] private GameObject player;
    [SerializeField] public List<GameObject> lugares;
    [SerializeField] private List<GameObject> UI;
    [SerializeField] private Dictionary<int,int> clickID;
    [SerializeField] private GameObject[] platosObj;
    [SerializeField] private int mesaId;
    [SerializeField] int itemsInTable;
    private bool canMove = true;

    private void Start()
    {

        clickID = new Dictionary<int,int>();
        for (int i = 0; i < 5; i++)
        {
            clickID[i] = 0;
        }

        for (int i = 0; i < platosObj.Length; i++)
        {
            if (platosObj[i] != null)
            {
                platosObj[i].SetActive(true);
                platosObj[i].transform.position = lugares[i].transform.position;
                clickID[i] = platosObj[i].GetComponent<ItemID>().ID;
            }
        }

        for (int i = 0; i < lugares.Count; i++)
        {
            lugares[i].GetComponent<PositionID>().SetID(i);
        }


            ContarItems();
    }

    public void OnInteract()
    {
        DialogueManager.Instance.CanMoveNotify2(false);
        m_Camera.Follow = gameObject.transform;
        m_Camera.m_Lens.OrthographicSize = 1.5f;
        for (int i = 0; i < lugares.Count; i++)
        {
            UI[i].SetActive(true);
            UI[i].transform.position = lugares[i].transform.position;
            UI[i].GetComponent<PositionID>().SetScript(this);
            UI[i].GetComponent<PositionID>().SetID(i);

        }


        ContarItems();
        ActualizarTexto();

    }

    public void InteractuarPlato(int id)
    {
        //Funcionalidad del boton de volver
        if (id == lugares.Count - 1)
        {
            for (int i = 0; i < UI.Count; i++)
            {
                UI[i].SetActive(false);
            }
            m_Camera.Follow = player.transform;
            m_Camera.m_Lens.OrthographicSize = 5f;
            DialogueManager.Instance.CanMoveNotify2(true);
        }

        //Funcion para dejar el plato en la mesa
        if (MinigameOne.Instance.PlatoEnManoID > 0)
        {
            if (clickID[id] == 0 && id < lugares.Count - 1)
            {
                platosObj[id] = MinigameOne.Instance.PlatoEnManoObj;
                platosObj[id].transform.position = UI[id].transform.position;
                clickID[id] = MinigameOne.Instance.DejarPlato(lugares[id].gameObject.GetComponent<PositionID>().SeeId(), mesaId);
                ContarItems();
                ActualizarTexto();
            }
        }
        //Funcion para tomar el plato de la mesa
        else 
        {
            if (clickID[id] > 0 && id < lugares.Count - 1)
            {
                MinigameOne.Instance.TomarPlato(platosObj[id], clickID[id], lugares[id].gameObject.GetComponent<PositionID>().SeeId(), mesaId);
                clickID[id] = 0;
                platosObj[id] = null;
                ContarItems();
                ActualizarTexto();

            }
        }

        ContarItems();
    }

    private void ContarItems()
    {
        itemsInTable = 0;
        for (int i = 0; i < clickID.Count; i++)
        {
            if (clickID[i] != 0)
            {
                itemsInTable++;
            }
        }
    }

    public void ResetItems(GameObject[] newFoodObj)
    {

        for (int i = 0; i < platosObj.Length; i++)
        {
            if (platosObj[i] != null)
            {
                platosObj[i].transform.position = new Vector2(1000, 1000);
                Destroy(platosObj[i]);
            }
        }

        clickID.Clear();
        for (int i = 0; i < 5; i++)
        {
            clickID[i] = 0;
        }

        for (int i = 0; i < newFoodObj.Length; i++)
        {
            if (newFoodObj[i] != null)
            {
                platosObj[i] = newFoodObj[i];
                platosObj[i].SetActive(true);
                platosObj[i].transform.position = lugares[i].transform.position;
                clickID[i] = platosObj[i].GetComponent<ItemID>().ID;
            }
        }


        ContarItems();

    }

    public void ActualizarTexto()
    {
        for (int i = 0; i < lugares.Count - 1; i++)
        {
            if (MinigameOne.Instance.PlatoEnManoID == 0)
            {
                if (clickID[i] > 0)
                {
                    UI[i].SetActive(true);
                    UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Tomar";
                }
                else if (clickID[i] == 0)
                {
                    UI[i].SetActive(false);
                }
            }
            else
            {
                if (clickID[i] > 0)
                {
                    UI[i].SetActive(false);
                }
                else if (clickID[i] == 0)
                {
                    UI[i].SetActive(true);
                    UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Colocar";

                }

            }
        }
        for (int i = lugares.Count - 1; i < lugares.Count; i++)
        {
            if (i == lugares.Count - 1)
            {
                UI[i].SetActive(true);
                UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Volver";
            }
        }

    }

}
