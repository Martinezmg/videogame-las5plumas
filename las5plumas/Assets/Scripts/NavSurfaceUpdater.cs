using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavSurfaceUpdater : MonoBehaviour
{

    public NavMeshSurface surface;
    public NavMeshAgent agent;
    public Transform pivot;
    public bool surfaceMoving;

    private void Start()
    {
        //StartCoroutine(Updater());
    }

    private void Update()
    {
        if (surfaceMoving)
        {
            agent.transform.position = pivot.position;
            surface.BuildNavMesh();
        }
        else
        {
            agent.destination = pivot.position;
        }
    }

    /*private IEnumerator Updater()
    {
        while (true)
        {
            surface.BuildNavMesh();

            agent.transform.position = transform.position;

            yield return null;
        }
    }*/

    private void OnDestroy()
    {
        //StopAllCoroutines();
    }
}
