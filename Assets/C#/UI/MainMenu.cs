using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        Application.Quit();
    }

    [SerializeField] private GameObject panel;

    private void OpenMenu()
    {
        try
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                panel.SetActive(true);
            }
        }
        catch
        {

        }
    }
}
