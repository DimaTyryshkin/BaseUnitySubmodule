using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GizmosExtantion
{
    static float arrowHeadAngle = 20.0f;

    public static void Arrow(Vector3 from, Vector3 to, float size = 0.25f)
    {
        Vector3 direction = to - from;
        Gizmos.DrawRay(from, direction);

        Quaternion right = Quaternion.Euler(0, 0, +arrowHeadAngle);
        Quaternion left = Quaternion.Euler(0, 0, -arrowHeadAngle);
         
        Vector3 arrow = direction.normalized * (-size);
        Gizmos.DrawRay(to, right * arrow);
        Gizmos.DrawRay(to, left * arrow);
    }
}