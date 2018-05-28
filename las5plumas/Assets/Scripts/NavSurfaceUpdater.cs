using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavSurfaceUpdater : MonoBehaviour
{

    public NavMeshSurface surface;
    public bool surfaceMoving;

    private void Update()
    {
        if (surfaceMoving)
        {
            surface.BuildNavMesh();
        }
    }
}
