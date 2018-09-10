using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_Movement : MonoBehaviour
{

    public float moveVelocity = 7f, maxVelocity = 5f;
    public float propulsion = 400f, maxPropulsion = 4f;
    private float xMovement, yMovement;
    private Rigidbody rigidb;
    private bool swim;
    private Animator animator;
    Quaternion resetPosition = Quaternion.Euler(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        rigidb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        yMovement = Input.GetAxis("Vertical") * 70;

        Quaternion targetRotation = Quaternion.Euler(yMovement, transform.localEulerAngles.y,
            transform.localEulerAngles.z);

        if(xMovement == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.6f * Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
        xMovement = Input.GetAxis("Horizontal");
		swim = Input.GetButton("Fire1");
        if (rigidb.velocity.magnitude < maxVelocity)
        {
			rigidb.AddTorque(Vector3.up * xMovement * moveVelocity);
        }

        if (swim)
        {
            animator.SetTrigger("Swim");
            if (rigidb.velocity.magnitude < maxPropulsion)
            {
				rigidb.AddForce(transform.forward * propulsion * Time.deltaTime);
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, resetPosition, 100 * Time.deltaTime);
    }
}
