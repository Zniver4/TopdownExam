using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 120f;
    public LineRenderer laserRenderer;
    public Transform laserOrigin;
    public float laserLength = 10f;

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
        Debug.Log("Disparo realizado");
    }
}
