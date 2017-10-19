using UnityEngine;

public class CameraTrigger : MonoBehaviour {
    
    private CameraController camController;
    public Transform targetPoint;

	// Use this for initialization
	void Start ()
    {
        if (camController == null)
            camController = CameraManager.camer.transformc.GetComponent<CameraController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player")
            return;
        
        camController.SetNewTarget(targetPoint);
    }
}
