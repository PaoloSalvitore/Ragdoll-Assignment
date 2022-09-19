using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public float speed = 7f;
    public float cubeTransferCounter = 0;
    public float maxCubeCount;
    public bool cubePosSwap = true;


    // Update is called once per frame
    void Update()
    {
        Movement();
    }




    public void OnTriggerEnter(Collider other)
    {
        ScoreManager.AddScore();
    }

    public void OnTriggerStay(Collider other)
    {

        Debug.Log("Trigger Stay");
        //limbsRigidbodies;
        if (other.tag == "Ragdoll")
        {
            if (CollisionDetection.ragdollOn == false)
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 25f, ForceMode.Impulse);
            }
            else
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 15f, ForceMode.Impulse);
            }
            
        }
        //+= gameObject.transform.forward * 10;
    }



    public void Movement()
    {
        Vector2 moveDirection = Vector2.zero;
        // Debug.Log("In movement");

        if (cubeTransferCounter >= maxCubeCount)
        {
            cubePosSwap = !cubePosSwap;
            cubeTransferCounter = 0;
            //    Debug.Log("SWAP movement");

        }

        if (cubePosSwap)
        {
            moveDirection.x += speed * Time.deltaTime;
            cubeTransferCounter += 1 * Time.deltaTime;
            //     Debug.Log("UP movement");

        }
        if (cubePosSwap == false)
        {
            moveDirection.x -= speed * Time.deltaTime;
            cubeTransferCounter += 1f * Time.deltaTime;
            //      Debug.Log("DOWN movement");

        }
        transform.position += (Vector3)moveDirection;


    }


}
