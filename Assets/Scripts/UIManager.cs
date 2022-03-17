using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene("Menu");
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void OnRestartButtonClicked()
    {
        FindObjectOfType<AudioManager>().Play("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OnQuitButtonClicked()
    {
        if(Application.platform != RuntimePlatform.IPhonePlayer)
        {
            Application.Quit();
        }
    }
}
