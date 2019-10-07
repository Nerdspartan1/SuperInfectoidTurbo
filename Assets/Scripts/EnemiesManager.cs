using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
	public static int numberOfCells;
	public static int numberOfCellsDestroyed;
	public static int numberOfEnemies;
	public static int numberOfKillsBeforeSuperLymphocyte;
	public static int numberOfKillsToSpawnLymphocyte;

	public float minPlayerSpawnDistance;
	public int maxNumberOfCells;
	public int maxNumberOfEnemies;
	public float EnemyWavePeriod;
	private float _timeBeforeNextWave;

    public GameObject LymphocyteBPrefab;
    public GameObject SuperLymphocyteBPrefab;
	public GameObject CellPrefab;


	public void Start()
	{
		_timeBeforeNextWave = 0.0f;
		numberOfCells = 0;
		numberOfCellsDestroyed = 0;
		numberOfEnemies = 0;
		numberOfKillsBeforeSuperLymphocyte = 10;
		numberOfKillsToSpawnLymphocyte = 10;
	}

	void Update()
    {
		if(_timeBeforeNextWave < 0.0f)
		{
			for (int i = numberOfCells; i < maxNumberOfCells; i++)
			{
				Spawn(CellPrefab);
				numberOfCells++;
			}

			for (int i = numberOfEnemies; i < Mathf.Min(numberOfCellsDestroyed,maxNumberOfEnemies); i++)
			{
				if (numberOfKillsBeforeSuperLymphocyte <= 0)
				{
					Spawn(SuperLymphocyteBPrefab);
					numberOfKillsBeforeSuperLymphocyte = Mathf.Max(numberOfKillsToSpawnLymphocyte--,5);
				}
				else
				{
					Spawn(LymphocyteBPrefab);
				}
				numberOfEnemies++;
			}

            _timeBeforeNextWave = EnemyWavePeriod;
		}
		_timeBeforeNextWave -= Time.deltaTime;

	}

    private void Spawn(GameObject enemy)
    {
		Vector2 spawnPos;
		do {

			float x = Random.Range(-GameManager.instance.playAreaWidth / 2, GameManager.instance.playAreaWidth / 2);
			float y = Random.Range(-GameManager.instance.playAreaHeight / 2, GameManager.instance.playAreaHeight / 2);

			spawnPos = new Vector2(x, y);
		}
		while (Vector2.Distance(GameManager.instance.player.transform.position, spawnPos) < minPlayerSpawnDistance);

        Instantiate(enemy, new Vector3(spawnPos.x, spawnPos.y, -1), Quaternion.identity, GameManager.instance.Game.transform);

    }
}
