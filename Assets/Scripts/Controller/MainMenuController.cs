using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using System.Collections.Generic;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour {
    [SerializeField] GameObject panel1;

    public Text userName;

    public void Start()
    {
        string displayName = PlayerPrefs.GetString("MyName");
        userName.text = displayName;
    }

    public void ShowPanel()
    {
        panel1.SetActive(true);
    }

    // Update is called once per frame
    public void ClosePanel()
    {
        panel1.SetActive(false);
    }

    public void _PlayButton(){
        SceneManager.LoadScene("Level2");
	}
    public void _PlayEasyButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGameButton()
    {
		Application.Quit();

    }
}
