using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LymphociteB : MonoBehaviour
{
    public GameObject anticorps;

	public GameObject HealObjectPrefab;

	public float attackRange = 15;
    public float speed = 0.01f;

    protected Rigidbody2D _rigidBody;
    protected float _timer;
    public float timeBetweenShoots = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

        if ((GameManager.instance.player.transform.position - transform.position).magnitude < attackRange) //attack range
        {
            gameObject.GetComponent<Animator>().SetBool("isAttacking", true);
            Shoot();
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
            _timer = 0;
		}
		// Move
		_rigidBody.velocity = speed * (GameManager.instance.player.transform.position - gameObject.transform.position);
	}

    public virtual void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > timeBetweenShoots)
        {
            GameObject bullet = Instantiate(anticorps, transform.position, transform.rotation, GameManager.instance.Game.transform);
            bullet.GetComponent<BulletScript>().direction = (GameManager.instance.player.transform.position - bullet.transform.position).normalized;
            _timer = 0;
        }
    }

    public void Die()
    {
        EnemiesManager.numberOfEnemies--;
        EnemiesManager.numberOfKillsBeforeSuperLymphocyte++;
		int chance = Random.Range(0, 3);
		if (chance == 0)
		{
			Instantiate(HealObjectPrefab, transform.position + Random.onUnitSphere * 3, Quaternion.identity, GameManager.instance.Game.transform);
		}
		Destroy(gameObject);
    }
}
