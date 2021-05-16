using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRifle : Weapon
{


    public override void shoot(GameObject shootPoint, Transform obj)
    {
        Instantiate(GameManager.Instance.prefabBullet, shootPoint.transform.position, obj.transform.rotation * Quaternion.Euler(0, -10, 0)) ;
    }
}
