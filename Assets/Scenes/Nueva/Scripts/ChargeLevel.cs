using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChargeLevel : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider Slider;

    public void ChargeScene(int NumberScene)
    {
        StartCoroutine(CargarAsync(NumberScene));
    }

    IEnumerator CargarAsync(int NumberScene)
    {
        AsyncOperation Operacion = SceneManager.LoadSceneAsync(NumberScene);

        LoadingScreen.SetActive(true);

        while (!Operacion.isDone)
        {
            float Progreso = Mathf.Clamp01(Operacion.progress / .9f);

            Slider.value = Progreso;

            yield return null;
        }
    }
}