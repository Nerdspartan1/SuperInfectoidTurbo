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

    public GameObject MenuUI;
    public GameObject GameUI;
    
    public float playAreaWidth;
    public float playAreaHeight;

    public float parallaxFactor = 500;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gamePhase = GamePhase.FirstMenuPhase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePhase(GamePhase nextPhase)
    {
        if (nextPhase == GamePhase.GamingPhase)
        {
            MenuUI.SetActive(false);
            GameUI.SetActive(true);
        }
        else if (nextPhase == GamePhase.FirstMenuPhase)
        {
            GameUI.SetActive(false);
            MenuUI.SetActive(true);
        }
    }

    public void LaunchGame()
    {
        ChangePhase(GamePhase.GamingPhase);
    }
}
