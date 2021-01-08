using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuManager : MonoBehaviour
{
    public Animator sceneTransition;
    public void LoadSceneName(string name)
    {
        sceneTransition.SetTrigger("isOpen");
        SceneManager.LoadScene(name);
    }
    public void CloseGame()
    {
        Application.Quit();
    }

}
