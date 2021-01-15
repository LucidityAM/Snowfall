using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuManager : MonoBehaviour
{
    public Animator sceneTransition;

    private string levelToLoad;

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        sceneTransition.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FadeToLevel("Credits");
        }           
    }
}
