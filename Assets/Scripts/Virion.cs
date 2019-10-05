using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virion : MonoBehaviour
{
    public enum State
    {
        Orbiting = 0,
        Firing = 1
    }

    public State state;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private float _speed = 1000;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        state = State.Orbiting;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Orbiting)
        {
            Vector2 direction = new Vector2(GameManager.instance.player.transform.position.x - transform.position.x, GameManager.instance.player.transform.position.y - transform.position.y).normalized;
            _rigidbody.velocity += Vector3.Distance(GameManager.instance.player.transform.position, transform.position) * direction / 10;
        }
    }

    public void Fire(Vector2 direction)
    {
        state = State.Firing;
        _direction = direction;
        _rigidbody.velocity = _speed * direction * Time.deltaTime;
        _rigidbody.drag = 0;
    }
}
