using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform camera;
    public Transform target;
    public Quaternion camRotationTo;
    public float camRotationSpeed;
    public float followSpeed = 5f;
    public Vector3 offset = new Vector3(0, 2, -10);

    void Start()
    {
        offset = camera.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        camera.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        camera.rotation = Quaternion.Lerp(camera.rotation, camRotationTo, camRotationSpeed);
    }
}
