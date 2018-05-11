using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GroundBotton : MonoBehaviour
{
    public float yaxis;

    public Transform surface;
    [Range(0f,0.5f)]
    public float offSet = 0f;

    private Vector3 iniSurfacePos;
    private Vector3 iniButtonPos;
    private Vector3 topButtonPos;

    [SerializeField, Range(0f, 1f)]
    private float speed = 1;

    public UnityEvent OnPushDown;
    private bool topRuning = false;
    private bool isPushedDown = false;

    private void Start()
    {
        iniSurfacePos = surface.position;
        iniButtonPos = transform.position;
        topButtonPos = iniSurfacePos + new Vector3(0, transform.position.y - offSet, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            topRuning = true;
            StopAllCoroutines();
            StartCoroutine(Top());             
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            if (!topRuning)
            {
                topButtonPos = iniSurfacePos + new Vector3(0, transform.position.y - offSet, 0);
                surface.position = topButtonPos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(Down());

            if (!isPushedDown)
            {
                ResetButton();
            }
        }
    }

    public void ResetButton()
    {
        isPushedDown = false;
        transform.position = iniButtonPos;
    }

    private IEnumerator Top()
    {    
        while (surface.position.y < topButtonPos.y)
        {
            surface.position += Vector3.up *Time.deltaTime* speed;

            yield return null;
        }

        surface.position = topButtonPos;
        topRuning = false;

        if (!isPushedDown)
        {
            isPushedDown = true;
            StartCoroutine(pushButtonDown());            
            if (OnPushDown != null)
            {
                OnPushDown.Invoke();
            }
        }
        
    }

    private IEnumerator Down()
    {
        while (surface.position.y > iniSurfacePos.y)
        {
            surface.position -= Vector3.up *Time.deltaTime* speed;

            yield return null;
        }

        surface.position = iniSurfacePos;
    }

    private IEnumerator pushButtonDown()
    {
        while (transform.position.y > yaxis)
        {
            transform.position -= Vector3.up * Time.deltaTime * speed;

            yield return null;
        }
    }
}
