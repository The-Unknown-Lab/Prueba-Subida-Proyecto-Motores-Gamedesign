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
    [SerializeField] private List<GameObject> lugares;
    [SerializeField] private List<GameObject> UI;
    [SerializeField] private Dictionary<int,int> clickID;
    [SerializeField] private GameObject[] platosObj;
    [SerializeField] private bool principalTable = false;
    [SerializeField] int itemsInTable;
    private bool canMove = true;

    private void Start()
    {
        clickID = new Dictionary<int,int>();
        clickID[0] = 0;
        clickID[1] = 0;
        clickID[2] = 0;
        clickID[3] = 0;
        clickID[4] = 0;
        clickID[5] = 0;

        for (int i = 0; i < platosObj.Length; i++)
        {
            if (platosObj[i] != null)
            {
                platosObj[i].SetActive(true);
                platosObj[i].transform.position = lugares[i].transform.position;
                clickID[i] = platosObj[i].GetComponent<TakeItemScript>().ItemID;
            }
        }

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
            lugares[i].GetComponent<PositionID>().SetID(i);
            UI[i].GetComponent<PositionID>().SetScript(this);
            UI[i].GetComponent<PositionID>().SetID(i);

        }

        itemsInTable = 0;
        for (int i = 0; i < clickID.Count; i++)
        {
            if (clickID[i] != 0)
            {
                itemsInTable++;
            }
        }


        ActualizarTexto();

    }

    public void InteractuarPlato(int id)
    {
        if (MinigameOne.Instance.PlatoEnManoID > 0) //Dejar Plato
        {
            if (clickID[id] == 0 && id < lugares.Count - 2)
            {
                platosObj[id] = MinigameOne.Instance.PlatoEnManoObj;
                platosObj[id].transform.position = UI[id].transform.position;
                clickID[id] = MinigameOne.Instance.DejarPlato();
                MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(MinigameOneDialogues.Instance.gameObject.GetComponent<IDialogue>(), new int[] {clickID[id] });
                Debug.Log("Funciono el lugar " + id);
                Debug.Log(("Objetos guardados: ") + clickID[id]);
                ContarItems();
                ActualizarTexto();
            }
            else if (id < lugares.Count - 2)
            {
                Debug.Log("Lugar " + id + " lleno");
            }
            else if(id == lugares.Count - 1)
            {
                Debug.Log("No puedes hablar en este momento");

            }
            else
            {
                for (int i = 0; i < UI.Count; i++)
                {
                    UI[i].SetActive(false);
                }
                m_Camera.Follow = player.transform;
                m_Camera.m_Lens.OrthographicSize = 5f;
                DialogueManager.Instance.CanMoveNotify2(true);
                Debug.Log("Volver");

            }
        }
        else if (principalTable)
        {
            if (itemsInTable == 1)
            {
                if (clickID[id] > 0 && id < lugares.Count - 2) //Comer plato
                {
                    MinigameOne.Instance.TomarPlato(platosObj[id], clickID[id]);
                    //MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), 5 + clickID[id]);
                    if (clickID[id] == 4)
                    {
                        MinigameOne.Instance.EndMinigame(2);
                    }
                    else
                        MinigameOne.Instance.EndMinigame(1);
                    clickID[id] = 0;
                    platosObj[id] = null;
                    Debug.Log("Comio del lugar " + id);
                    Debug.Log(("Objetos Tomados: ") + clickID[id]);
                    ContarItems();
                    ActualizarTexto();

                }
                else if (id < lugares.Count - 2)
                {
                    Debug.Log("Lugar " + id + " Vacio");

                }
                else if (id == lugares.Count - 1)
                {
                    //MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(this.gameObject.GetComponent<IDialogue>(), 0);
                    Debug.Log("Hablar");
                }
                else
                {
                    for (int i = 0; i < UI.Count; i++)
                    {
                        UI[i].SetActive(false);
                    }
                    m_Camera.Follow = player.transform;
                    m_Camera.m_Lens.OrthographicSize = 5f;
                    DialogueManager.Instance.CanMoveNotify2(true);
                    Debug.Log("Volver");
                }

            }
            else
            {
                if (clickID[id] > 0 && id < lugares.Count - 2) //Tomar platos
                {
                    MinigameOne.Instance.TomarPlato(platosObj[id], clickID[id]);
                    //MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), clickID[id]);
                    clickID[id] = 0;
                    platosObj[id] = null;
                    Debug.Log("Tomo del lugar " + id);
                    Debug.Log(("Objetos Tomados: ") + clickID[id]);
                    ContarItems();
                    ActualizarTexto();

                }
                else if (id < lugares.Count - 2)
                {
                    Debug.Log("Lugar " + id + " Vacio");

                }
                else if (id == lugares.Count - 1)
                {
                    //MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(this.gameObject.GetComponent<IDialogue>(), 0);
                    Debug.Log("Hablar");

                }
                else
                {
                    for (int i = 0; i < UI.Count; i++)
                    {
                        UI[i].SetActive(false);
                    }
                    m_Camera.Follow = player.transform;
                    m_Camera.m_Lens.OrthographicSize = 5f;
                    DialogueManager.Instance.CanMoveNotify2(true);
                    Debug.Log("Volver");
                }

            }

        }
        else
        {
            if (clickID[id] > 0 && id < lugares.Count - 2) //Tomar platos
            {
                MinigameOne.Instance.TomarPlato(platosObj[id], clickID[id]);
                //MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(gameObject.GetComponent<IDialogue>(), clickID[id]);
                clickID[id] = 0;
                platosObj[id] = null;
                Debug.Log("Tomo del lugar " + id);
                Debug.Log(("Objetos Tomados: ") + clickID[id]);
                ContarItems();
                ActualizarTexto();

            }
            else if (id < lugares.Count - 2)
            {
                Debug.Log("Lugar " + id + " Vacio");

            }
            else if (id == lugares.Count - 1)
            {
                //MinigameOne.Instance.gameObject.GetComponent<V2NewNpcDialogue1>().OnInteract(this.gameObject.GetComponent<IDialogue>(), 0);
                Debug.Log("Hablar");

            }
            else
            {
                for (int i = 0; i < UI.Count; i++)
                {
                    UI[i].SetActive(false);
                }
                m_Camera.Follow = player.transform;
                m_Camera.m_Lens.OrthographicSize = 5f;
                DialogueManager.Instance.CanMoveNotify2(true);
                Debug.Log("Volver");
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

    public void ActualizarTexto()
    {
        if (principalTable && itemsInTable == 1)
        {
            for (int i = 0; i < lugares.Count - 2; i++)
            {
                if (MinigameOne.Instance.PlatoEnManoID == 0)
                {
                    if (clickID[i] > 0)
                    {
                        UI[i].SetActive(true);
                        UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";
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
            for (int i = lugares.Count - 2; i < lugares.Count; i++)
            {
                if (principalTable && i == lugares.Count - 1)
                {
                    UI[i].SetActive(false);
                }
                else if (i == lugares.Count - 1)
                {
                    UI[i].SetActive(true);
                    UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Hablar";
                }
                if (i == lugares.Count - 2)
                {
                    UI[i].SetActive(true);
                    UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Volver";
                }
            }

        }
        else
        {
            for (int i = 0; i < lugares.Count - 2; i++)
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
            for (int i = lugares.Count - 2; i < lugares.Count; i++)
            {
                if (principalTable && i == lugares.Count - 1)
                {
                    UI[i].SetActive(false);
                }
                else if (i == lugares.Count - 1)
                {
                    UI[i].SetActive(true);
                    UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Hablar";
                }
                if (i == lugares.Count - 2)
                {
                    UI[i].SetActive(true);
                    UI[i].GetComponentInChildren<TextMeshProUGUI>().text = "Volver";
                }
            }
        }

    }

}
