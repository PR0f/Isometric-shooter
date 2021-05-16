using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Weapon
{
    LineRenderer shootLine;

    public void init(GameObject shootPoint)
    {
        GameObject prefabLine = GameManager.Instance.prefabLine;
        GameObject spawn = Instantiate(prefabLine, shootPoint.transform);
        shootLine = spawn.GetComponent<LineRenderer>();
    }

    public override void shoot(GameObject shootPoint, Transform obj)
    {

        shootLine.SetPosition(0, Vector3.zero);

        Vector2 dir = new Vector2(shootPoint.transform.TransformDirection(Vector2.up).x,
            shootPoint.transform.TransformDirection(Vector2.up).y);


        shootLine.enabled = true;

        Vector2 vector2 = new Vector2(shootPoint.transform.position.x, shootPoint.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(vector2, -dir.normalized * 50);
        if (hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "Wall")
        {
            shootLine.SetPosition(1, new Vector3(0, -hit.distance * 2, 0));
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.GetComponent<EnemyController>().setDamage();
            }
        }
        else
        {
            shootLine.SetPosition(1, new Vector3(0, -50, 0));
        }
    }

    public void enableLaser(bool x)
    {
        shootLine.enabled = x;
    }
}
