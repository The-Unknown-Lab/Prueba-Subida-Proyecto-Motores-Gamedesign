using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] GameObject secondaryScreen;
    private float timer;
    private bool changeScene = false;

    private void Update()
    {
        timer = timer + Time.deltaTime;
        if (changeScene && timer > 2)
        {
            SceneManager.LoadScene(sceneIndex);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (secondaryScreen != null)
            {
                timer = 0;
                changeScene = true;
                secondaryScreen.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}
