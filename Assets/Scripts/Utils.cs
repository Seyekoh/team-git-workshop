using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    // kudos to https://gist.github.com/limanson/3985742e5ba179e39c0c for FaceObject()
    public enum FacingDirection { Forward = 0, Back = 180, Right = 270, Left = 90 }

    public static Quaternion FaceObject(Vector3 myPos, Vector3 targetPos, FacingDirection facing)
    {
        Vector3 direction = targetPos - myPos;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        angle -= (float)facing;
        return Quaternion.AngleAxis(angle, Vector3.up);
    }
}