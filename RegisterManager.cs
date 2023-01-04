using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterManager : MonoBehaviour
{
    public static RegisterManager instance;

    public GameObject RegisterMenu;
    public GameObject HomeMenu;
    public GameObject LoginMenu;
    public GameObject TextHolder;

    public Text RegisterText;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        RegisterMenu.SetActive(false);
        LoginMenu.SetActive(false);
        TextHolder.SetActive(false);
    }

    public void RegisterUser()
    {
        HomeMenu.SetActive(false);
        RegisterMenu.SetActive(true);
    }

    public void LoginUser()
    {
        HomeMenu.SetActive(false);
        LoginMenu.SetActive(true);
    }

    public void Home()
    {
        HomeMenu.SetActive(true);
        RegisterMenu.SetActive(false);
        LoginMenu.SetActive(false);
        TextHolder.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeTextColour(bool b)
    {
        if (b)
        {
            RegisterText.color = Color.green;
        }
        else
        {
            RegisterText.color = Color.red;
        }
    }

    public void RegisterFailure(bool b)
    {
        if (b)
        {
            RegisterText.text = "USERNAME TAKEN";
        }
        else
        {
            RegisterText.text = "USERNAME CAN'T BE EMPTY";
        }
        TextHolder.SetActive(true);
    }

    public void RegisterSuccess()
    {
        RegisterText.text = "REGISTRATION SUCCESFUL";
        TextHolder.SetActive(true);
    }
}
