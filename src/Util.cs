using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static Vector2 VectorTo(GameObject dest, GameObject source)
    {
        float dx = dest.transform.position.x - source.transform.position.x;
        float dy = dest.transform.position.y - source.transform.position.y;

        return new Vector2(dx, dy);
    }

    public static void FlipScaleForMovement(GameObject obj, Vector2 movement, bool facingLeft)
    {
        int xscale = (facingLeft) ? -1 : 1;

        if (movement.x > 0) {
            obj.transform.localScale = new Vector3(xscale, 1, 1);
        } else if (movement.x < 0) {
            obj.transform.localScale = new Vector3(-xscale, 1, 1);
        }
    }
}
