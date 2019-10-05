using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
	public int life = 10;
	public UnityEvent OnDeath;

	public void TakeDamage(int damage)
	{
		life -= damage;
		if(life <= 0)
		{
			OnDeath.Invoke();
		}
	}
}
