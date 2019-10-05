using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject LBPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(LBPrefab, new Vector3(-5, 3, 0), Quaternion.identity, GameManager.instance.Game.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
