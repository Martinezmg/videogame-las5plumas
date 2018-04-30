using UnityEngine;
using TouchScript.Gestures.TransformGestures;
using System;
using System.Collections;

namespace Project.Game
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour, IManager
    {
        public Transform target;

        //Para la suavidad del movimiento
        [Header("Transform smoothness")]
        public float lerpSmothness = 1f;
        [Range(0, 1)]
        public float quaternionLerpSmothness = 0.05f;
        [Range(0.001f, 0.1f)]
        public float posError = 0.1f;
        [Range(0.001f, 0.1f)]
        public float rotError = 0.1f;

        [Space(10f)]
        [Header("Camera size")]
        public ScreenTransformGesture zoomGesture;
        public float zoomSize;
        [Range(5f, 10f)]
        public float maxZoom = 8f;
        [Range(1f, 4.5f)]
        public float minZoom = 4f;
        [Range(0, 1)]
        public float zoomLerpSmothness = 0.05f;
        [Range(0.001f, 0.1f)]
        public float zoomError = 0.1f;

        public float posDistance;
        public float rotDistance;

        //misc
        private bool idle = true;

        private void Awake()
        {
            if (zoomGesture == null)
            {
                zoomGesture = MainManager.Instance.GetComponent<ScreenTransformGesture>();
            }
        }

        private void OnEnable()
        {
            transform.parent = null;
            SetNewTarget(target);

            zoomGesture.Transformed += ZoomHandler;
        }

        private void Start()
        {

            zoomSize = GetComponent<Camera>().orthographicSize;

            /*if (target != null)
            {
                transform.position = target.position;
                transform.rotation = target.rotation;
            }*/

        }

        private void Update()
        {
            #region MoveToPoint
            if (!idle)
            {
                //MoveToNewTarget();
            }
            #endregion
        }

        private void OnDisable()
        {
            zoomGesture.Transformed -= ZoomHandler;
        }

        private void ZoomHandler(object sender, EventArgs e)
        {
            float delta = zoomGesture.DeltaScale;
            float size = GetComponent<Camera>().orthographicSize;

            if (delta >= 1f && size > minZoom)
            {
                GetComponent<Camera>().orthographicSize *= (1 - Mathf.Abs(1 - zoomGesture.DeltaScale));
            }
            else if(delta < 1f && size < maxZoom)
            {
                GetComponent<Camera>().orthographicSize *= (1 + Mathf.Abs(1 - zoomGesture.DeltaScale));
            }
        }        

        public void SetNewTarget(Transform t)
        {
            target = t;

            //start courutine
            //StopAllCoroutines();
            StartCoroutine(MoveToNewTarget());
            StartCoroutine(RotateToNewTarget());
        }

        public void SetNewZoom(float z)
        {
            zoomSize = z;

            //start courutine
            //StopAllCoroutines();
            StartCoroutine(SetZoomSize());
        }

        /*private void MoveToNewTarget()
        {
            float distanceA = Vector3.Distance(transform.position, target.position);
            float distanceB = Vector3.Distance(transform.eulerAngles, target.eulerAngles);

            float currentSize = GetComponent<Camera>().orthographicSize;

            float distanceC = Mathf.Abs(currentSize - zoomSize);

            if (distanceA > 0.1f && distanceB > 0.1f && distanceC > 0.1f)
            {
                transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * lerpSmothness);

                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, quaternionLerpSmothness);                

                GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentSize, zoomSize, Time.deltaTime * lerpSmothness);


            }
            else
            {
                idle = true;
            }
        }*/

        private IEnumerator MoveToNewTarget()
        {
             posDistance = Vector3.Distance(transform.position, target.position);

            while (posDistance > posError)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * lerpSmothness);

                posDistance = Vector3.Distance(transform.position, target.position);
                
                yield return null;
            }

            
        }

        private IEnumerator RotateToNewTarget()
        {
            rotDistance = Vector3.Distance(transform.eulerAngles, target.eulerAngles);

            while (rotDistance > rotError)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, quaternionLerpSmothness);

                rotDistance = Vector3.Distance(transform.eulerAngles, target.eulerAngles);

                yield return null;
            }
        }

        private IEnumerator SetZoomSize()
        {
            float currentSize = GetComponent<Camera>().orthographicSize;

            float zoomDiff = Mathf.Abs(currentSize - zoomSize);

            while (zoomDiff > zoomError)
            {
                currentSize = Mathf.Lerp(currentSize, zoomSize, Time.deltaTime * lerpSmothness);

                GetComponent<Camera>().orthographicSize = currentSize;
                zoomDiff = Mathf.Abs(currentSize - zoomSize);

                yield return null;
            }
            
        }


        //Para usar junto con un boton
        public void DisableComponent()
        {
            enabled = false;
        }

        public void EnableComponent()
        {
            Debug.Log("ENABLING CAMERAAAAAAAA");

            enabled = true;
        }
    }
}
