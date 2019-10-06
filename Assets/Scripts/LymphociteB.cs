using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LymphociteB : MonoBehaviour
{
    public GameObject anticorps;

	public GameObject HealObjectPrefab;

	public float attackRange = 15;
    public float speed = 0.01f;

    public AudioClip shootSound;
    public AudioClip dieSound;

    protected Rigidbody2D _rigidBody;
    protected float _timer;
    public float timeBetweenShoots = 1.0f;

	private bool _isDead = false;
	private Animator _animator;
	private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _rigidBody.freezeRotation = true;
		_animator = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();

	}

    // Update is called once per frame
    void Update()
    {
		if (!_isDead)
		{
			if ((GameManager.instance.player.transform.position - transform.position).magnitude < attackRange) //attack range
			{
				_animator.SetBool("isAttacking", true);
				Shoot();
			}
			else
			{
				_animator.SetBool("isAttacking", false);
				_timer = 0;
			}
			// Move
			_rigidBody.velocity = speed * (GameManager.instance.player.transform.position - gameObject.transform.position);
		}
	}

    public virtual void Shoot()
    {
        _timer += Time.deltaTime;

        if (_timer > timeBetweenShoots)
        {
            MakeSound(shootSound);
            GameObject bullet = Instantiate(anticorps, transform.position, transform.rotation, GameManager.instance.Game.transform);
            bullet.GetComponent<BulletScript>().direction = (GameManager.instance.player.transform.position - bullet.transform.position).normalized;
            _timer = 0;
        }
    }

    public void Die()
    {
        if (!_isDead)
        {
            MakeSound(dieSound);
        }
        
		_isDead = true;
		_animator.SetBool("isAttacking", false);
		_animator.SetBool("dead", true);
		_rigidBody.freezeRotation = false;

        EnemiesManager.numberOfEnemies--;
        EnemiesManager.numberOfKillsBeforeSuperLymphocyte--;
		int chance = Random.Range(0, 3);
		if (chance == 0)
		{
			Instantiate(HealObjectPrefab, transform.position + Random.onUnitSphere * 3, Quaternion.identity, GameManager.instance.Game.transform);
		}

		StartCoroutine(Disappear());
    }

	public IEnumerator Disappear()
	{
		float timeBeforeDisappear = 2.0f;

		while (timeBeforeDisappear > 0.0f)
		{
			timeBeforeDisappear -= Time.deltaTime;
			if (timeBeforeDisappear < 1.0f)
			{
				_spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, timeBeforeDisappear);
			}
			yield return null;
		}

		Destroy(gameObject);
	}

    public void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
