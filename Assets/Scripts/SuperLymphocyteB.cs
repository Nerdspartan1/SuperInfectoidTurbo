using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLymphocyteB : LymphociteB
{
    
    public override void Shoot()
    {
        
    }

    public void Burst()
    {
        MakeSound(shootSound);
        for (int i = -2; i < 3; i++)
        {
            GameObject bullet = Instantiate(anticorps, transform.position, transform.rotation, GameManager.instance.Game.transform);
            bullet.GetComponent<BulletScript>().direction = (Quaternion.Euler(0, 0, i * 15) * (GameManager.instance.player.transform.position - bullet.transform.position)).normalized;
        }
    }
}
