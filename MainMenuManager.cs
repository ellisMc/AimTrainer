using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManger : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        OptionsMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void main()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
