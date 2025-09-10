using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 120f;
    public LineRenderer laserRenderer;
    public Transform laserOrigin;
    public float laserLength = 10f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;
    public float projectileLifeTime = 2f;

    void Update()
    {
        UpdateLaser();

        bool isRotatingOnly = Input.GetButton("LB");

        if (!isRotatingOnly)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(vertical, 0, horizontal);
            Vector3 moveDirection = transform.TransformDirection(direction);
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }

        float rotateInput = Input.GetAxis("Mouse X"); 
        transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("RB"))
        {
            Shoot();
        }
    }

    void UpdateLaser()
    {
        if (laserRenderer != null && laserOrigin != null)
        {
            laserRenderer.SetPosition(0, laserOrigin.position);
            laserRenderer.SetPosition(1, laserOrigin.position + laserOrigin.forward * laserLength);
        }
    }
    void Shoot()
    {
        if (laserOrigin != null)
        {
            Vector3 spawnPosition = laserOrigin.position + laserOrigin.forward * laserLength;
            Quaternion spawnRotation = laserOrigin.rotation;

            GameObject projectile = BulletPool.Instance.GetBullet(spawnPosition, spawnRotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = laserOrigin.forward * projectileSpeed;
            }

            StartCoroutine(DisableAfterTime(projectile, projectileLifeTime));
        }
    }

    IEnumerator DisableAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (obj != null)
            BulletPool.Instance.ReturnBullet(obj);
    }

    
}
