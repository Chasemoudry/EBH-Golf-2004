using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Ball;

public class CameraPosition : MonoBehaviour {

    public Transform ballTf;

    private Transform cameraTf;

	// Use this for initialization
	void Start() 
    {
        cameraTf = this.gameObject.GetComponent<Transform>();

        GameManager.gm.cameraOffset = new Vector3(ballTf.localPosition.x + GameManager.gm.cameraOffset.x, ballTf.localPosition.y + GameManager.gm.cameraOffset.y, ballTf.localPosition.z + GameManager.gm.cameraOffset.z);
        this.gameObject.GetComponent<Ball>();
	}

	void Update() 
    {
        //Updates current Game Manager value
        GameManager.gm.cameraOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * GameManager.gm.cameraRotationSpeed, Vector3.up) * GameManager.gm.cameraOffset;

        if (ballTf != null)
        {
            //Updates current camera position and looks at player to set rotation
            cameraTf.position = ballTf.position + GameManager.gm.cameraOffset;
            cameraTf.LookAt(new Vector3(ballTf.position.x, ballTf.position.y + 1, ballTf.position.z));
        }
	}
}
