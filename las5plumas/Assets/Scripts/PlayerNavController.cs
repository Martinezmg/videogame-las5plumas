using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerNavController : MonoBehaviour {

    public Camera cam;
    public RectTransform pivotUI;

    NavMeshAgent agent;
    Ray way;

    //for ui
    Vector2 originPoint;
    Vector2 currentPoint;
    float lastAngle;

    // Use this for initialization
    void Start ()
    {
        //this is for player manager
        PlayerManager.player.transformp = transform;

        //this is for cam in null case
        if (cam == null)
            cam = CameraManager.camer.transformc.GetComponent<Camera>();

        agent = GetComponent<NavMeshAgent>();
        way = new Ray(transform.position, transform.GetChild(0).forward);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //when mousebutton is down, take initial point 
        if (Input.GetMouseButtonDown(0))
        {
            pivotUI.gameObject.SetActive(true);
            pivotUI.position = Input.mousePosition;

            originPoint = (Vector2)pivotUI.position;
        }
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = Vector3.Lerp(
            transform.eulerAngles,
            new Vector3(transform.eulerAngles.x, cam.transform.eulerAngles.y, transform.eulerAngles.z),
            Time.deltaTime);

            Vector2 currentPoint = (Vector2)Input.mousePosition;
            currentPoint = currentPoint - originPoint;

            if (currentPoint.magnitude > 50f)
            {
                float angle = Vector2.SignedAngle(currentPoint, Vector2.up);
                Quaternion rotateTo = Quaternion.Euler(transform.GetChild(0).eulerAngles.x, angle + cam.transform.eulerAngles.y, transform.GetChild(0).eulerAngles.z);

                transform.GetChild(0).rotation = Quaternion.Lerp(transform.GetChild(0).rotation, rotateTo, 0.5f);                
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            pivotUI.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        way.origin = transform.position;
        way.direction = transform.GetChild(0).forward;

        if (Input.GetMouseButton(0))
        {
            agent.SetDestination(way.GetPoint(1f));
        }

    }

   // public float CurrentAngle() { return angle - lastAngle; }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.forward * 30f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.right * 30f);
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position + Vector3.up, transform.GetChild(0).forward * 15f);
    }*/
}
