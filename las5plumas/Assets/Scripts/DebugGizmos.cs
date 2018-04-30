using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGizmos : MonoBehaviour {

    public bool lookAt = false;
    public Transform target;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        if (lookAt)
        {
            transform.LookAt(target);

            lookAt = false;
        }
    }
}
