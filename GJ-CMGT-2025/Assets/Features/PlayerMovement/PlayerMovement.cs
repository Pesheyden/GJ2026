using BSOAP.Events;
using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private CommandEventSo _actionEvent;
    public Transform player;
    public float distance;
    public float yDistance;
    Vector3 direction;
    bool onGRound = true;
    public Transform camera;
    
    //transform.position += d * direction

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.W) && noCollision(player.position, Vector3.forward, distance))
        {
            direction = Vector3.forward;
            player.position += distance * direction;
            _actionEvent.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.A) && noCollision(player.position, Vector3.left, distance))
        {
            direction = Vector3.left;
            if (!onGRound)
            {
                direction = Vector3.right;
            }
           
            player.position += distance * direction;
            _actionEvent.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.S) && noCollision(player.position, Vector3.back, distance))
        {
            direction = Vector3.back;
            player.position += distance * direction;
            _actionEvent.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.D) && noCollision(player.position, Vector3.right, distance))
        {
            direction = Vector3.right;
            if (!onGRound)
            {
                direction = Vector3.left;
            }
           
            player.position += distance * direction;
            _actionEvent.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGRound)
            {
                direction = Vector3.up;
                onGRound = false;
                
            }
            else
            {
                direction = Vector3.down;
                onGRound = true;
                
            }

           
            player.position += yDistance * direction;
            player.Rotate(0, 0, 180);
            camera.GetComponent<Camera_Controller>().offset.y *= -1;
            camera.GetComponent<Camera_Controller>().camRotationTo = Quaternion.Euler(camera.eulerAngles.x, camera.eulerAngles.y, camera.eulerAngles.z + 180);


        }

    }

    bool noCollision(Vector3 position,Vector3 direction, float maxDistance)
    {

        if (!onGRound && (direction == Vector3.left || direction == Vector3.right))
        {
            direction *= -1;
        }
        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        float distance;
        if (Physics.Raycast(ray, out hit)){
            distance = hit.distance;
            if(distance <= maxDistance)
            {
                print(distance);
                return false;
            }
            else
            {
                return true;
            }
                
        }
        return true;
        
    }
}
