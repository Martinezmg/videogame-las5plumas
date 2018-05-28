using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject parent;
    public GameObject activator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == activator)
        {
            activator.transform.parent = parent.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == activator)
        {
            activator.transform.parent = null;
        }
    }
}
