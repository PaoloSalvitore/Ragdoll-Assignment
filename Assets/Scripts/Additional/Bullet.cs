using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3;

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }


   



    public void OnTriggerStay(Collider other)
    {

        Debug.Log("Trigger Stay");
        //limbsRigidbodies;
        if (other.tag == "Ragdoll")
        {
            if (CollisionDetection.ragdollOn == false)
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 60f, ForceMode.Impulse);
            }
            else
            {
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 60f, ForceMode.Impulse);
            }
            Destroy(gameObject);

        }
        //+= gameObject.transform.forward * 10;
    }



}
