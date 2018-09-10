using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {

    private GameObject target;
    public Vector3 cameraDistance = new Vector3(0f, 1f, -5f);
    public float distanceDamp = 4f;
    public float rotationDamp = 8f;
    private Transform myT;

	// Use this for initialization
	void Start () {
        myT = transform;
        target = GameObject.Find("virus2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        Vector3 toPosition = target.transform.position + (target.transform.rotation * cameraDistance);
        Vector3 currentPosition = Vector3.Lerp(myT.position, toPosition, distanceDamp * Time.deltaTime);
        myT.position = currentPosition;

        Quaternion toRotation = Quaternion.LookRotation(target.transform.position - myT.position,
            target.transform.up);
        Quaternion currentRotation = Quaternion.Slerp(myT.rotation, toRotation, rotationDamp * Time.deltaTime);
        myT.rotation = currentRotation;
    }

}
