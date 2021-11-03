using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float lifetime = 3;
    Vector3 bulletPosition;
    Vector3 direction;
    bool canShoot = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // Fire();
        }
    }

    public void Fire(Vector3 bulletPosition , Vector3 direction)
    {   
       this.bulletPosition = bulletPosition;
       this.direction = direction;
       if(!canShoot){

        StartCoroutine(DelayFire());
       }
    }

    private IEnumerator DelayFire()
    {   
        canShoot = true;
        yield return new WaitForSeconds (0.2f);
        canShoot= false;
        GameObject bullet = Instantiate(bulletPrefab);

        //ignore collise between bullet and gun
        Physics .IgnoreCollision(bullet.GetComponent<Collider>(),
                bulletSpawn.parent.GetComponent<Collider>());
        Physics .IgnoreCollision(bullet.GetComponent<Collider>(),
                Movement.Instance.GetComponent<Collider>());
        
        // bulletSpawn.parent.transform.position = direction;
        bullet.transform.position = bulletSpawn.position;


        bullet.GetComponent<Rigidbody>().AddForce( bulletSpawn.forward  * bulletSpeed,ForceMode.Impulse);
        //forcemode.impuse only once
        StartCoroutine(DestroyBulletAfterTime(bullet,lifetime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }


}
