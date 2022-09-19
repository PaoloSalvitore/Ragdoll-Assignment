using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // [SerializeField] private HingeJoint _hingeJoint;
    //[SerializeField] private float _speed = 3f;
     float moveDir = 0f;

    public Transform wheelTurn;
    float turnDir = 0f;

    HingeJoint joint;
    public void Start()
    {
        joint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        JointMotor motor = joint.motor;

        motor.targetVelocity = 600f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            motor.targetVelocity *= 2;

        }

        motor.force += 200f;
        moveDir = Input.GetAxis("Vertical");
        turnDir = Input.GetAxis("Horizontal");
        motor.targetVelocity *= moveDir;
        wheelTurn.eulerAngles = new Vector3(wheelTurn.eulerAngles.x, wheelTurn.eulerAngles.y + turnDir, wheelTurn.eulerAngles.z);
        joint.motor = motor;
            
       
    }

}
