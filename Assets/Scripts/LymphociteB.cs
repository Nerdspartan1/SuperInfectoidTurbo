using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LymphociteB : MonoBehaviour
{
    public GameObject anticorps;

    public float range;
    public float speed = 0.01f;

    private Rigidbody2D _rigidBody;
    private float _timer;
    private float _timeBetweenShoots = 1.0f;

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

        if ((GameManager.instance.player.transform.position - transform.position).magnitude < range)
        {
            // Moving
            _rigidBody.velocity = speed * (GameManager.instance.player.transform.position - gameObject.transform.position);

            gameObject.GetComponent<Animator>().SetBool("isAttacking", true);
            _timer += Time.deltaTime;

            if (_timer > _timeBetweenShoots)
            {
                GameObject bullet = Instantiate(anticorps, transform.position, transform.rotation, GameManager.instance.Game.transform);
                bullet.GetComponent<BulletScript>().direction = (GameManager.instance.player.transform.position - bullet.transform.position).normalized;
                _timer = 0;
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
            _timer = 0;
        }
        
    }

    public void Die()
    {
        EnemiesManager.numberOfEnemies--;
        Destroy(gameObject);
    }
}
