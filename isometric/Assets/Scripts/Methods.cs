using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Methods 
{
    public static void lookAt2D(Transform obj, Transform target)
    {
        Vector3 dir = target.position - obj.position;
        float angel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        obj.localRotation = Quaternion.AngleAxis(-angel + 90, Vector3.up);
    }

    public static void lookAt2D(Transform obj, Vector3 objPos, Vector3 targetPos)
    {
        Vector3 vector3 = new Vector3(objPos.x, objPos.y+1.5f, 0);
        Vector3 dir = targetPos - vector3;
        float angel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        obj.localRotation = Quaternion.AngleAxis(-angel + 97, Vector3.up);
    }
}
