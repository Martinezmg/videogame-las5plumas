using UnityEngine;

public class PlatformWithArrows : MonoBehaviour
{
    enum arrowDirection
    {
        FRONT, BACK, RIGTH, LEFT // front = 0, back = 1, rigth = 2, left = 3
    }

    public float movingPlatformSpeed = 1f;
    public float distanceError = 0.05f;

    public float currentDistance = 0f;

    public Transform[] waypoints;
    public GroundBotton[] buttons;

    private bool isMoving = false;
    [SerializeField]
    private arrowDirection direction;
    private Vector3 vectorDir;
    private Transform currentTarget;
    private Transform lastTarget;

    public void GoTo(int dir)
    {
        //Algo que mueva el transform a directions[dir]
        direction = (arrowDirection)dir;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == (int)direction)
                continue;

            buttons[i].buttonActive = false;
        }

        SetDirection();

    }

    void SetDirection()
    {
        currentTarget = waypoints[(int)direction];

        if (currentTarget == lastTarget)
        {
            ResetButtons();
            return;
        }

        Vector3 tarPos = currentTarget.localPosition;
        tarPos = new Vector3(tarPos.x, 0, tarPos.z);

        Vector3 thisPos = transform.localPosition;
        thisPos = new Vector3(thisPos.x, 0, thisPos.z);

        vectorDir = (tarPos - thisPos).normalized;

        

        isMoving = true;

        SetNewWaypoints();
    }

    void MovePlatform()
    {        
        transform.Translate(vectorDir * Time.deltaTime * movingPlatformSpeed);
        //transform.position = Vector3.Lerp(transform.position, currentTarget.position, Time.deltaTime * movingPlatformSpeed);
    }

    void ResetPlatform()
    {
        //asignar nuevas direcciones
        lastTarget = currentTarget;
        isMoving = false;

        //resetear los botones
        ResetButtons();
    }

    void ResetButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].ResetButton();

            if (i == (int)direction)
                continue;

            buttons[i].buttonActive = true;
        }
    }

    void SetNewWaypoints()
    {
        PlatformWaypoint current = currentTarget.GetComponent<PlatformWaypoint>();

        waypoints = current.waypoints;
    }

    private void Start()
    {
        lastTarget = transform;
    }

    private void Update()
    {
        if (isMoving)
        {
            currentDistance = Vector3.Distance(transform.localPosition, waypoints[(int)direction].localPosition);

            if (currentDistance <= distanceError )
            {
                ResetPlatform();
            }

            MovePlatform();
        }
    }

}
