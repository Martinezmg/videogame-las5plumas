using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static CameraManager camer;

    public Transform transformc;

    private void Awake()
    {
        if (camer == null)
        {
            camer = this;
        }
    }
}
