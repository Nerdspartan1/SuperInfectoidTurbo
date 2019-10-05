using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
	public int life;
	public UnityEvent OnDeath;
	public UnityEvent OnDamaged;

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
}
