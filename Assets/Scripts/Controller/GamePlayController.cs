using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[HideInInspector] public int playerScore = 0;
    
    

    [SerializeField]private Animator _gameOverPanel;

	[SerializeField]private Text _scoreText, _endScoreText;

	[SerializeField]private GameObject pausePanel,butonpause;

	public Text userName;

    public GameObject gameWinCanvas;



    public void PauseGameButton()
	{
		pausePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	public void ResumeButton()
	{
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}
	void Awake(){
		_MakeInstance ();
        

    }

	void Start(){
		_scoreText.text = "" + playerScore;
		string displayName = PlayerPrefs.GetString("MyName");
		userName.text = displayName;
    }

	void Update(){
		_UpdateGamePlayController ();
        string sceneName = SceneManager.GetActiveScene().name;
        if (Boss.bossDied == true && sceneName == "Level1")
        {
            StartCoroutine(TimeLoad());
            Time.timeScale = 0;
            gameWinCanvas.SetActive(true);
        }
    }

    IEnumerator TimeLoad()
    {
        yield return new WaitForSeconds(4);
    }

    void _UpdateGamePlayController(){
        _scoreText.text = "" + playerScore;
       


    }

	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}

	public void _PlayerDied(){
		
		_gameOverPanel.Play ("SlideIn");
		_endScoreText.text = "" + playerScore;
		_scoreText.gameObject.SetActive (false);
		butonpause.SetActive (false);


	}

	public void _RestartButton(){
		Time.timeScale = 1f;
        SceneManager.LoadScene ("Level2");
	}

    public void _RestartEasyButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
    public void _Exit(){
   /* #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
    #endif*/
		//Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLv2()
    {
        
        SceneManager.LoadScene("Level2");
        Boss.bossDied = false;
        Time.timeScale = 1f;
    }
    public void NextWin()
    {
        
        SceneManager.LoadScene("Win");
        Time.timeScale = 1f;
    }



}
