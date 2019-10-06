using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GamePhase {
        FirstMenuPhase = 1,
        GamingPhase = 2,
        CreditPhase = 3
    }

    public static GameManager instance;

    public GamePhase gamePhase;

    public GameObject Menu;
    public GameObject Game;
    public GameObject Credit;
	public GameObject GameOverScreen;
	public Text ScoreText;

    new public Camera camera;
    public float defaultOrthographicSize = 6;

    public GameObject player;

    public float playAreaWidth = 88.0f;
    public float playAreaHeight = 46.0f;

    public float parallaxFactor = 500;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangePhase(GamePhase.FirstMenuPhase);
		GameOverScreen.SetActive(false);
	}

    public void ChangePhase(GamePhase nextPhase)
    {
		switch (nextPhase)
		{
			case GamePhase.GamingPhase:
				Menu.SetActive(false);
                Credit.SetActive(false);
				Game.SetActive(true);
                Destroy(Menu.GetComponent<VideoPlayer>().videoPlayer);
                Destroy(Credit.GetComponent<VideoPlayer2>().videoPlayer);
                gamePhase = GamePhase.GamingPhase;
				break;
			case GamePhase.FirstMenuPhase:
				Game.SetActive(false);
                Credit.SetActive(false);
                Menu.SetActive(true);
                Destroy(Credit.GetComponent<VideoPlayer2>().videoPlayer);
                Menu.GetComponent<VideoPlayer>().PlayVideo();
                gamePhase = GamePhase.FirstMenuPhase;
				break;
            case GamePhase.CreditPhase:
                Game.SetActive(false);
                Menu.SetActive(false);
                Credit.SetActive(true);
                Credit.GetComponent<VideoPlayer2>().PlayVideo();
                Destroy(Menu.GetComponent<VideoPlayer>().videoPlayer);
                gamePhase = GamePhase.CreditPhase;
                break;
        }
    }

    public void LaunchGame()
    {
        ChangePhase(GamePhase.GamingPhase);
    }

    public void ShowCredits()
    {
        ChangePhase(GamePhase.CreditPhase);
    }

    public void ShowMenu()
    {
        ChangePhase(GamePhase.FirstMenuPhase);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

	public void GameOver()
	{
		GetComponent<VirionManager>().ClearVirions();
		ScoreText.text = $"You got eradicated ! Your score : {EnemiesManager.numberOfCellsDestroyed}";
		GameOverScreen.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
