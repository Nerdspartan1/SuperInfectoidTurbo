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
    }

    public static GameManager instance;

    public GamePhase gamePhase;

    public GameObject Menu;
    public GameObject Game;
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
				Game.SetActive(true);
				gamePhase = GamePhase.GamingPhase;
				break;
			case GamePhase.FirstMenuPhase:
				Game.SetActive(false);
				Menu.SetActive(true);
				gamePhase = GamePhase.FirstMenuPhase;
				break;
		}
    }

    public void LaunchGame()
    {
        ChangePhase(GamePhase.GamingPhase);
    }

	public void GameOver()
	{
		player.SetActive(false);
		ScoreText.text = $"You got eradicated ! Your score : {EnemiesManager.numberOfCellsDestroyed}";
		GameOverScreen.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
