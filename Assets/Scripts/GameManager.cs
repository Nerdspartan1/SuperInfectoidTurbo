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
        CreditPhase = 3,
        ControlsPhase = 4
    }

    public static GameManager instance;

    public GamePhase gamePhase;

    public GameObject Menu;
    public GameObject Game;
    public GameObject Credit;
    public GameObject Controls;
	public GameObject GameOverScreen;
	public Score Score;
	public Score EndScore;
	public Score HighScore;

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
                Controls.SetActive(false);
                Game.SetActive(true);
                Destroy(Menu.GetComponent<VideoPlayer>().videoPlayer);
                Destroy(Credit.GetComponent<VideoPlayer2>().videoPlayer);
                Destroy(Controls.GetComponent<VideoPlayer3>().videoPlayer);
                gamePhase = GamePhase.GamingPhase;
				break;
			case GamePhase.FirstMenuPhase:
				Game.SetActive(false);
                Credit.SetActive(false);
                Controls.SetActive(false);
                Menu.SetActive(true);
                Destroy(Credit.GetComponent<VideoPlayer2>().videoPlayer);
                Destroy(Controls.GetComponent<VideoPlayer3>().videoPlayer);
                Menu.GetComponent<VideoPlayer>().PlayVideo();
                gamePhase = GamePhase.FirstMenuPhase;
				break;
            case GamePhase.CreditPhase:
                Game.SetActive(false);
                Menu.SetActive(false);
                Controls.SetActive(false);
                Credit.SetActive(true);
                Credit.GetComponent<VideoPlayer2>().PlayVideo();
                Destroy(Menu.GetComponent<VideoPlayer>().videoPlayer);
                Destroy(Controls.GetComponent<VideoPlayer3>().videoPlayer);
                gamePhase = GamePhase.CreditPhase;
                break;
            case GamePhase.ControlsPhase:
                Game.SetActive(false);
                Menu.SetActive(false);
                Credit.SetActive(false);
                Controls.SetActive(true);
                Destroy(Credit.GetComponent<VideoPlayer2>().videoPlayer);
                Destroy(Menu.GetComponent<VideoPlayer>().videoPlayer);
                Controls.GetComponent<VideoPlayer3>().PlayVideo();
                gamePhase = GamePhase.ControlsPhase;
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

    public void ShowControls()
    {
        ChangePhase(GamePhase.ControlsPhase);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

	public void GameOver()
	{
		GetComponent<VirionManager>().ClearVirions();
		Score.gameObject.SetActive(false);
		EndScore.UpdateScore(EnemiesManager.numberOfCellsDestroyed);
		GameOverScreen.SetActive(true);
		int high_score = PlayerPrefs.GetInt("high_score", 0);
		if (EnemiesManager.numberOfCellsDestroyed > high_score)
			high_score = EnemiesManager.numberOfCellsDestroyed;
			PlayerPrefs.SetInt("high_score", high_score);
		HighScore.UpdateScore(high_score);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
