using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LymphociteB : MonoBehaviour
{
    public GameObject anticorps;

    private float _timer;
    private float _timeBetweenShoots = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _timeBetweenShoots)
        {
            GameObject bullet = Instantiate(anticorps, transform.position, transform.rotation, GameManager.instance.Game.transform);
            bullet.GetComponent<BulletScript>().direction = (GameManager.instance.player.transform.position - bullet.transform.position).normalized;
            _timer = 0;
        }
    }
}
