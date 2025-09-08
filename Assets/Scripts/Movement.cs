using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Vertical, 0, horizontal);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
