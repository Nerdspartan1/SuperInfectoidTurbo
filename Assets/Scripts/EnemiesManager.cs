using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public enum EnemyType
    {
        LymphociteB = 0,
        LymphociteT = 1,
        Dendrite = 2
    }

    public GameObject LBPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomEnemies(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRandomEnemies(int difficulty)
    {
        switch (difficulty)
        {
            case 0:
                _SpawnEnemies(EnemyType.LymphociteB, 5);
                break;
            case 1:
                break;
            default:
                break;
        }
    }

    private void _SpawnEnemies(EnemyType type, int number)
    {
        for (int i = 0; i < number; i++)
        {
            float x = Random.Range(-GameManager.instance.playAreaWidth / 2, GameManager.instance.playAreaWidth / 2);
            float y = Random.Range(-GameManager.instance.playAreaHeight / 2, GameManager.instance.playAreaHeight / 2);

            Debug.Log("x : " + -GameManager.instance.playAreaWidth / 2+" / "+ GameManager.instance.playAreaWidth / 2);
            Debug.Log("y : " + y);

            switch (type)
            {
                case EnemyType.LymphociteB:
                    Instantiate(LBPrefab, new Vector3(x, y, 0), Quaternion.identity, GameManager.instance.Game.transform);
                    break;
                case EnemyType.LymphociteT:
                    break;
                case EnemyType.Dendrite:
                    break;
            }
        }
    }
}
