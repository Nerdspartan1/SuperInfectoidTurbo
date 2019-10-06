using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	public float PerlinRate;
	public float PerlinAccelerationFactor;
	private Rigidbody2D _rigidbody;
	private Collider2D _collider;
	private Vector2 _perlinDirection;
	private Animator _animator;

    public AudioClip dieSound;

	public int VirionsDrop = 5;
	public GameObject VirionPrefab;
	private VirionManager _virionManager;

	public GameObject GibsPrefab;

	public bool IsPopped=false;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_perlinDirection = Random.insideUnitCircle.normalized;
		_animator = GetComponent<Animator>();
		_virionManager = GameManager.instance.GetComponent<VirionManager>();
		_collider = GetComponent<Collider2D>();
	}

	void Update()
    {
		Vector2 perlinPosition = _perlinDirection * PerlinRate * Time.time;
		Vector2 acceleration = PerlinAccelerationFactor  * new Vector2(Mathf.PerlinNoise(perlinPosition.x, perlinPosition.y) - 0.5f, Mathf.PerlinNoise(perlinPosition.x + 10,perlinPosition.y) -0.5f );
		_rigidbody.velocity += acceleration * Time.deltaTime;
		

	}

	public void StartInfecting()
	{
		_animator.SetBool("panicked", true);
	}

	public void StopInfecting()
	{
		_animator.SetBool("panicked", false);
	}

	public void Pop(bool infected)
	{
        MakeSound(dieSound);
		IsPopped = true;
		_animator.SetTrigger("pop");
		
		Destroy(gameObject,1.0f);
		if (infected)
		{
			EnemiesManager.numberOfCellsDestroyed++;
			for (int i = 0; i < VirionsDrop; i++)
			{
                if (_virionManager.virions.Count < _virionManager.maxVirions)
                {
                    var v = Instantiate(VirionPrefab, transform.position + Random.onUnitSphere, Quaternion.identity, GameManager.instance.Game.transform);
                    _virionManager.virions.Add(v.GetComponent<Virion>());
                }
			}
		}
		EnemiesManager.numberOfCells--;
	}

	public void FinishPop()
	{
		_collider.enabled = false;
		for (int i = 0; i < 6; i++)
		{
			var g = Instantiate(GibsPrefab, transform.position, Quaternion.identity, GameManager.instance.Game.transform);
			g.GetComponent<Rigidbody2D>().velocity = 6 * Random.insideUnitCircle;
		}
	}

    public void MakeSound(AudioClip originalClip)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = originalClip;
        float pitch = 1.0f + Random.Range(-0.2f, 0.2f);
        audioSource.pitch = pitch;
        audioSource.Play();
        //AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
