using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public enum GameState {StartMenu, Paused, Playing, GameOver};
    [SerializeField] private GameState currentState;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private GameObject allGameUI, startMenuPanel, pauseMenuPanel, gameOverPanel;

	public static MenuUI singletonInstance;
	
	private void Awake() 
	{ 
		if (singletonInstance != null) 
		{ 
			Destroy(this.gameObject); 
		} 
		else 
		{ 
			singletonInstance = this; 
		} 
	}
	
    private void Start() 
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(GameObject.Find("EventSystem"));
        
        if(SceneManager.GetActiveScene().name == "StartMenu")
        {
            CheckGameState(GameState.StartMenu);
        }
        else
        {
            CheckGameState(GameState.Playing);
        }
    }

    public void CheckGameState(GameState newGameState)
    {
        currentState = newGameState;
        switch (currentState)
        {
            case GameState.StartMenu:
                StartMenuSetup();
                break;
            case GameState.Paused:
                GamePaused();
                Time.timeScale = 0f;
                break;
            case GameState.Playing:
                GameActive();
                Time.timeScale = 1f;
                break;
            case GameState.GameOver:
                GameOver();
                Time.timeScale = 0f;
                break;
        }
    }

    public void StartMenuSetup()
    {
        allGameUI.SetActive(false);
        startMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void GameActive()
    {
        allGameUI.SetActive(true);
        startMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void GamePaused()
    {
        allGameUI.SetActive(true);
        startMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        allGameUI.SetActive(false);
        startMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Playing)
            {
                CheckGameState(GameState.Paused);
            }
            else if(currentState == GameState.Paused)
            {
                CheckGameState(GameState.Playing);
            }
        }
    }

    public void StartGame()
	{
        SceneManager.LoadScene("lvl1");
        CheckGameState(GameState.Playing);
	}

    public void PauseGame()
    {
        CheckGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        CheckGameState(GameState.Playing);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        CheckGameState(GameState.StartMenu);
    }

    public void PlayerDied()
    {
        SceneManager.LoadScene("GameOver");
        CheckGameState(GameState.GameOver);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
