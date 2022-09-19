using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    public Transform cam;
    public float moveSpeed = 6f;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public static bool canMove = true;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private float _jumpSpeed = 250;
    private bool _grounded = true;

    public GameObject player;
    public Rigidbody rb;
    #endregion


    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
    }



   
    void Update()
    {
        if (canMove)
        {
            #region Movement
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = runSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (direction.magnitude >= 0.1f)
            {
               
                transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;
            }
           // Debug.Log(_grounded);

            if (Input.GetKeyDown("space") && _grounded)
            {
                _grounded = false;
                //Debug.Log("You jumped!");   
                rb.AddForce(Vector3.up * _jumpSpeed);
                
            }
            #endregion

        }
    }

    void OnCollisionStay()
    {
        _grounded = true;
    }

}

