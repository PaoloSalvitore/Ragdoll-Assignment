using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
       [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private GameObject _pfBullet;
    public float bulletSpeed = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E ))
        {

            PlayerShoot();
        }
    }




    private void PlayerShoot()
    {
        var bullet = Instantiate(_pfBullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = _bulletSpawnPoint.forward * bulletSpeed;
    }


}
