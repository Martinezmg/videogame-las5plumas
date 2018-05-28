using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Sight : MonoBehaviour
{
    [System.Serializable]
    public class SightEvent : UnityEvent<bool> { }

    public LayerMask layer;

    public Vector3 sightCenter = Vector3.zero;
    public float sightDistance = 1f;
    [Range(0f,90f)]
    public float sightAngle = 10f;
    [Range(1,5)]
    public int accuracy = 1;

    public Transform target;
    public SightEvent OnTargetInSight;
    public bool isTargetInSight = false;

    [Space]
    [Header("Focus")]
    public bool focusEnabled = false;
    [SerializeField]
    private float focusDelay = 1f;
    private bool isFocus = false;
    public UnityEvent OnFocus;
    private Quaternion defaultRot;

    public bool enableGizmos = false;

    #region Properties
    private bool IsTargetInSight
    {
        set
        {
            isTargetInSight = value;
            onTargetInSight();
        }
    }

    public bool IsFocus
    {
        get
        {
            return isFocus;
        }

        set
        {
            isFocus = value;

            if (isFocus)
                OnFocus.Invoke();
            else
                transform.rotation = defaultRot;
        }
    }
    #endregion

    private void Start()
    {
        defaultRot = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            SightTarget();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == target.gameObject)
        {
            SightTarget();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target.gameObject && isTargetInSight)
        {
            IsTargetInSight = false;
        }
    }

    private void SightTarget()
    {
        RaycastHit hit;

        foreach (Vector3 dir in Directions())
        {
            Ray ray = new Ray(transform.position + sightCenter, dir);

            Debug.DrawLine(ray.origin, ray.GetPoint(sightDistance), Color.blue);

            if (Physics.Raycast(ray, out hit, sightDistance * transform.localScale.x, layer))
            {
                if (hit.collider.gameObject == target.gameObject && !isTargetInSight)
                {
                    IsTargetInSight = true;
                }
            }
        }
    }

    private void onTargetInSight()
    {
        if (OnTargetInSight!=null)
        {
            OnTargetInSight.Invoke(isTargetInSight);
        }
    }

    private Vector3[] Directions()
    {
        Vector3[] directions = new Vector3[accuracy * 2 - 1];

        directions[accuracy-1] = transform.forward;

        if (accuracy > 1)
        {
            float diff = sightAngle / ((accuracy - 1) * 2);

            for (int i = 0; i < accuracy - 1; i++)
            {
                Vector3 rigth_dir = Quaternion.AngleAxis(diff * (i + 1), transform.up) * transform.forward;
                Vector3 left_dir = Quaternion.AngleAxis(-diff * (i + 1), transform.up) * transform.forward;

                directions[i] = rigth_dir;
                directions[directions.Length - 1 - i] = left_dir;
            }
        }

        return directions;
    }    

    private void OnDrawGizmos()
    {
        if (!enableGizmos)
            return;

        Gizmos.color = Color.cyan;

        foreach (Vector3 dir in Directions())
        {
            Gizmos.DrawRay(transform.position + sightCenter, dir * sightDistance * transform.localScale.x);
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightDistance * transform.localScale.x);
    }


}
