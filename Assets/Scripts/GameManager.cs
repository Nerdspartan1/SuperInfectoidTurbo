using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GamePhase {
        FirstMenuPhase = 1,
        GamingPhase = 2
    }

    public static GameManager instance;

    public GamePhase gamePhase;

    public GameObject Menu;
    public GameObject Game;

    public Camera camera;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePhase(GamePhase nextPhase)
    {
        if (nextPhase == GamePhase.GamingPhase)
        {
            Menu.SetActive(false);
            Game.SetActive(true);
            gamePhase = GamePhase.GamingPhase;
        }
        else if (nextPhase == GamePhase.FirstMenuPhase)
        {
            Game.SetActive(false);
            Menu.SetActive(true);
            gamePhase = GamePhase.FirstMenuPhase;
        }
    }

    public void LaunchGame()
    {
        ChangePhase(GamePhase.GamingPhase);
    }
}
