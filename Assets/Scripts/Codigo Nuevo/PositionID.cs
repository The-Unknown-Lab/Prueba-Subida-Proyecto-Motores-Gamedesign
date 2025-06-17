using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionID : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private MesaScript mesa;

    public void SetScript(MesaScript script)
    {
        mesa = script;
    }

    public void TouchButton()
    {
        mesa.InteractuarPlato(id);
    }

    public void SetID(int id)
    {
        this.id = id;
    }

    public int SeeId()
    {
        return id;
    }
}
