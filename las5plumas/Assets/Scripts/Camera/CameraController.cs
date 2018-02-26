using System.Collections;
using UnityEngine;

namespace Project.Game
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        public Transform menuTarget;
        private Transform lastTarget;


        //Para la suavidad del movimiento
        [Header("Transform smoothness")]
        public float lerpSmothness = 1f;
        [Range(0, 1)]
        public float quaternionLerpSmothness = 0.05f;

        //Para controllador del zoom de la camara
        [Header("Zoom controller")]
        public float sizeCameraTimer = 1.5f;
        [Space(10)]
        public float baseCameraSize;
        public float currentCameraSize;
        public float minSizeCamera = -2f;
        public float maxSizeCamera = 2f;
        [Space(10)]
        public float sizeCameraSmothness = 1f;

        private IEnumerator ccurrentZoomTimer;

        //misc
        private bool idle = true;

        private void Start()
        {

            transform.position = target.position;
            transform.rotation = target.rotation;

            //zooming controller
            baseCameraSize = Camera.main.orthographicSize;
            currentCameraSize = baseCameraSize;
        }


        private void Update()
        {

            #region MoveToPoint
            if (!idle)
            {
                MoveToNewTarget();
            }
            #endregion

            #region ZoomController
            currentCameraSize -= Input.GetAxis("Mouse ScrollWheel") * sizeCameraSmothness;
            currentCameraSize = Mathf.Clamp(currentCameraSize, baseCameraSize - minSizeCamera, baseCameraSize + maxSizeCamera);

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, currentCameraSize, Time.deltaTime * sizeCameraSmothness);


            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                if (ccurrentZoomTimer != null)
                {
                    StopCoroutine(ccurrentZoomTimer);
                }

                ccurrentZoomTimer = CZoomTimer();
                StartCoroutine(ccurrentZoomTimer);

            }
            #endregion

            if (Input.GetMouseButton(2))
            {

            }
        }

        private IEnumerator CZoomTimer()
        {
            yield return new WaitForSeconds(sizeCameraTimer);

            while (currentCameraSize > 0.1f || currentCameraSize < -.01f)
            {
                currentCameraSize = Mathf.Lerp(currentCameraSize, baseCameraSize, Time.deltaTime * sizeCameraSmothness);
                yield return null;
            }
        }

        public void SetNewTarget(Transform t)
        {
            target = t;

            idle = false;
        }

        private void MoveToNewTarget()
        {
            float distanceA = Vector3.Distance(transform.position, target.position);
            float distanceB = Vector3.Distance(transform.eulerAngles, target.eulerAngles);

            if (distanceA > 0.1f && distanceB > 0.1f)
            {
                transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * lerpSmothness);

                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, quaternionLerpSmothness);
            }
            else
            {
                idle = true;
            }
        }

        public void MoveToMenu()
        {
            lastTarget = target;
            SetNewTarget(menuTarget);
        }

        public void MoveToGame()
        {
            SetNewTarget(lastTarget);
        }

    }
}
