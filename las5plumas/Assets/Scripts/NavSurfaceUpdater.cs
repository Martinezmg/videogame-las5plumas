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

    public void UpdateSurface(float t)
    {
        StartCoroutine(_updateSurface(t));
    }

    IEnumerator _updateSurface(float t)
    {
        surfaceMoving = true;

        yield return new WaitForSeconds(t);

        surfaceMoving = false;
    }
}
