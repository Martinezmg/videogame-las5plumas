using UnityEngine;
using TouchScript.Gestures.TransformGestures;
using System;

namespace Project.Game
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        public Transform target;

        //Para la suavidad del movimiento
        [Header("Transform smoothness")]
        public float lerpSmothness = 1f;
        [Range(0, 1)]
        public float quaternionLerpSmothness = 0.05f;

        public ScreenTransformGesture zoomGesture;
        private float defaultZoomSize;
        [Range(5f, 10f)]
        public float maxZoom = 8f;
        [Range(1f, 4.5f)]
        public float minZoom = 4f;

        public TouchScript.Gestures.Gesture.GestureState state;

        //misc
        private bool idle = true;

        private void OnEnable()
        {
            if (zoomGesture == null)
            {
                zoomGesture = MainManager.Instance.GetComponent<ScreenTransformGesture>();
            }

            zoomGesture.Transformed += ZoomHandler;
        }

        private void OnDisable()
        {
            zoomGesture.Transformed -= ZoomHandler;
        }

        private void ZoomHandler(object sender, EventArgs e)
        {
            //Debug.Log(zoomGesture.DeltaScale);

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

        private void Start()
        {           

            defaultZoomSize = GetComponent<Camera>().orthographicSize;

            if (target != null)
            {
                transform.position = target.position;
                transform.rotation = target.rotation;
            }
            
        }

        private void Update()
        {
            state = zoomGesture.State;

            #region MoveToPoint
            if (!idle)
            {
                MoveToNewTarget();
            }
            #endregion
        }

        public void SetNewTarget(Transform t, float z)
        {
            target = t;
            defaultZoomSize = z;

            idle = false;
        }

        private void MoveToNewTarget()
        {
            float distanceA = Vector3.Distance(transform.position, target.position);
            float distanceB = Vector3.Distance(transform.eulerAngles, target.eulerAngles);

            float currentSize = GetComponent<Camera>().orthographicSize;

            float distanceC = Mathf.Abs(currentSize - defaultZoomSize);

            if (distanceA > 0.1f && distanceB > 0.1f && distanceC > 0.1f)
            {
                transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * lerpSmothness);

                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, quaternionLerpSmothness);                

                GetComponent<Camera>().orthographicSize = Mathf.Lerp(currentSize, defaultZoomSize, Time.deltaTime * lerpSmothness);


            }
            else
            {
                idle = true;
            }
        }

    }
}
