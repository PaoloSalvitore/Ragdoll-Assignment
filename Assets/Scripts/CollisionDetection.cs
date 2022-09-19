using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject playerRig;
    public BoxCollider mainCollider;
    public static bool ragdollOn = true;
    private void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

   
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;

    void GetRagdollBits()
    {
        ragdollColliders = playerRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = mainCollider.GetComponentsInChildren<Rigidbody>();
    }



    private void OnCollisionEnter(Collision collision)
    {
            RagdollModeOn();
    }

   

    public void OnTriggerStay(Collider other)
    {
        ScoreManager.AddScore();

    }


    private void RagdollModeOn() 
    {
        ragdollOn = true;
        Debug.Log("Ragdoll Mode On");
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
     //   PlayerMovement.canMove = false;
    }

    void RagdollModeOff()
    {
        ragdollOn = false;
        Debug.Log("Ragdoll Mode Off");
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        PlayerMovement.canMove = true;
    }


}
