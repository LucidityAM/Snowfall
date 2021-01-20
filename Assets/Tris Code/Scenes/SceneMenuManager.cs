using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenuManager : MonoBehaviour
{
    public Animator sceneTransition;

    private int levelToLoad;

    public void FadeToLevel(int levelName)
    {
        levelToLoad = levelName;
        sceneTransition.SetTrigger("FadeOut");

        Button[] buttons = FindObjectsOfType<Button>();

        foreach(Button button in buttons)
        {
            button.enabled = false;
        }
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
            FadeToLevel(4);
        }           
    }

}
