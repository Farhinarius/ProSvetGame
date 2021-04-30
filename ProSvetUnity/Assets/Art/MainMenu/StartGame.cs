using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;

   
    public void Load()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
