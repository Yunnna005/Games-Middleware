using UnityEngine;

public class PhysicsSphere : MonoBehaviour
{

    PhysicsPlane plane;
    private Vector3 acceleration, velocity;
    private const float gravity = 9.81f;

    void Start()
    {
        plane = FindAnyObjectByType<PhysicsPlane>();
        acceleration = gravity * Vector3.down;  
    }

    void Update()
    {
        velocity += acceleration * Time.deltaTime; 
        transform.position += velocity * Time.deltaTime;

        if(transform.position.y < plane.transform.position.y + 0.5f)
        {
            transform.position -= velocity * Time.deltaTime;
            velocity = -velocity;
        }

        
    }
}
