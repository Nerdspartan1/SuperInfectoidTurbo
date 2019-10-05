using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gibs : MonoBehaviour
{
	public Sprite[] sprites;
	private SpriteRenderer _spriteRenderer;
	public float LifeTime = 3.0f;

    void Start()
    {
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }

    void Update()
    {
		LifeTime -= Time.deltaTime;
		if (LifeTime < 1.0f)
		{
			_spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, LifeTime);
		}
		if (LifeTime < 0.0f)
			Destroy(gameObject);

	}
}
