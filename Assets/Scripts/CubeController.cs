using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!Input.gyro.enabled)
        {
            Input.gyro.enabled = true;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion deviceRotation = GyroToUnity(Input.gyro.attitude);
        Vector3 deviceEulerAngles = deviceRotation.eulerAngles;
        Vector3 transformEulerAngles = transform.rotation.eulerAngles;
        transform.Rotate((new Vector3(transformEulerAngles.x, deviceEulerAngles.x, transformEulerAngles.z)) * (0.01f * Time.deltaTime));
	}

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
    
}
