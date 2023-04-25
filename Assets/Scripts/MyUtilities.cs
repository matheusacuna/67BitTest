using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtilities
{
    public static class UtilsClass
    {
        public static void KnockBack(this Rigidbody rig, Transform transform1, Transform transform2, float knockBackForce)
        {
            Vector3 dir = (transform1.position - transform2.position).normalized;
            rig.AddForce(dir * knockBackForce, ForceMode.Impulse);
        }
    }
}

