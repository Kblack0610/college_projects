using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletGreenPrefab;

    public int ammoSelect = 0;

    public float moveSpeed = 5f;
    public float rotationSpeed = 3f;
    public VariableJoystick shootingJoystick;

    Vector2 movement;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = shootingJoystick.Horizontal * tiltAngle;
        // float tiltAroundX = shootingJoystick.Vertical * tiltAngle;
        float heading = Mathf.Atan2(-shootingJoystick.Horizontal, shootingJoystick.Vertical);

        // Rotate the cube by converting the angles into a quaternion.
        // Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

        // // Dampen towards the target rotation
        // firePoint.rotation = Quaternion.Slerp(firePoint.rotation, target, Time.deltaTime * smooth);

        firePoint.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);

        if (heading != 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Shoot();
        }

    }

    void FixedUpdate()
    {
        // if (movement.sqrMagnitude > 0.1)
        // {
        //     float angle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg;
        //     firePoint.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -angle)), Time.deltaTime * rotationSpeed);
        // }
    }
    void Shoot()
    {
        firePoint.position = firePoint.position + new Vector3(0, 0, 30);
        Debug.Log(ammoSelect);
        switch (ammoSelect)
        {
            case 0:
                Transform bullet = Instantiate(bulletPrefab.transform, firePoint.position, firePoint.rotation) as Transform;
                break;
            case 1:
                Transform bullet_green = Instantiate(bulletGreenPrefab.transform, firePoint.position, firePoint.rotation) as Transform;
                break;
        }

        //shoot
        // Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

    }

    public void switchAmmo(int ammoID)
    {
        ammoSelect = ammoID;
    }
}
