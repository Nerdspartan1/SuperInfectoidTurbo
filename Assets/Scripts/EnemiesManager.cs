using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
	static public int numberOfCells = 0;
	public int maxNumberOfCells = 12;
	public int numberOfCellsDestroyed = 0;

	static public int numberOfEnemies;
	public int targetNumberOfEnemies;

	public float enemyWavePeriod = 5.0f;
	public float timeBeforeNextWave = 0.0f;

    public GameObject LymphocyteBPrefab;
	public GameObject CellPrefab;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
		if(timeBeforeNextWave < 0.0f)
		{
			for (int i = numberOfCells; i < maxNumberOfCells; i++)
				Spawn(CellPrefab);



			timeBeforeNextWave = enemyWavePeriod;
		}
		timeBeforeNextWave -= Time.deltaTime;
	}




    private void Spawn(GameObject enemy)
    {

        float x = Random.Range(-GameManager.instance.playAreaWidth / 2, GameManager.instance.playAreaWidth / 2);
        float y = Random.Range(-GameManager.instance.playAreaHeight / 2, GameManager.instance.playAreaHeight / 2);

        Debug.Log("x : " + -GameManager.instance.playAreaWidth / 2+" / "+ GameManager.instance.playAreaWidth / 2);
        Debug.Log("y : " + y);


        Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity, GameManager.instance.Game.transform);

        
    }
}
