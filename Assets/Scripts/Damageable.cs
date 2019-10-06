using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
	private int _maxLife;
	public int life;
	public UnityEvent OnDeath;
	public UnityEvent OnDamaged;

	private void Start()
	{
		_maxLife = life;
	}

	public void TakeDamage(int damage)
	{
		life -= damage;
		if(life <= 0)
		{
			OnDeath.Invoke();
		}
		else
		{
			OnDamaged.Invoke();
		}
	}

	public void Heal(int heal)
	{
		life += heal;
		if (life > _maxLife) life = _maxLife;
	}
}
