using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public InputField userName;
   

    // Update is called once per frame
    void Update()
    {
        string displayName = userName.text;
        PlayerPrefs.SetString("MyName", displayName);
        PlayerPrefs.Save();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
