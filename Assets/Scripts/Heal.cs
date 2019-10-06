using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float range;
    public float speed;
	public float LifeTime;

    private Rigidbody2D _rigidbody;
	private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameManager.instance.player.transform.position - transform.position).magnitude < range)
        {
            _rigidbody.velocity = speed * (GameManager.instance.player.transform.position - transform.position).normalized;
        }

		LifeTime -= Time.deltaTime;
		if (LifeTime < 1.0f)
		{
			_spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, LifeTime);
		}
		if (LifeTime < 0.0f)
			Destroy(gameObject);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			collision.gameObject.GetComponent<Damageable>().Heal(5);
			Destroy(gameObject);
		}
    }
}
