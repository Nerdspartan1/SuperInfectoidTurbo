using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
	static public int numberOfCells = 0;
	static public int numberOfCellsDestroyed = 0;
	public int maxNumberOfCells = 12;

	static public int numberOfEnemies = 0;
	public int maxNumberOfEnemies = 20;

	public float EnemyWavePeriod = 5.0f;
	private float _timeBeforeNextWave = 0.0f;

    public GameObject LymphocyteBPrefab;
	public GameObject CellPrefab;

	public Text InfectedCount;

	public void Start()
	{
		_timeBeforeNextWave = 0.0f;
		numberOfCells = 0;
		numberOfCellsDestroyed = 0;
		numberOfEnemies = 0;
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
				Spawn(LymphocyteBPrefab);
				numberOfEnemies++;
			}

			_timeBeforeNextWave = EnemyWavePeriod;
		}
		_timeBeforeNextWave -= Time.deltaTime;

		InfectedCount.text = $"Cells infected : {numberOfCellsDestroyed}";
	}

    private void Spawn(GameObject enemy)
    {

        float x = Random.Range(-GameManager.instance.playAreaWidth / 2, GameManager.instance.playAreaWidth / 2);
        float y = Random.Range(-GameManager.instance.playAreaHeight / 2, GameManager.instance.playAreaHeight / 2);

        Instantiate(enemy, new Vector3(x, y, -1), Quaternion.identity, GameManager.instance.Game.transform);

    }
}
