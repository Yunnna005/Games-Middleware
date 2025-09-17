using Assets.Scripts;
using System.Text;
using UnityEngine;

public class PhysicsSphere : MonoBehaviour
{
    PhysicsPlane plane;
    private Vector3 acceleration, velocity;
    private const float gravity = 9.81f;
    float CoR = 0.5f;

    public float Radius 
    { get 
        { 
            return transform.localScale.x / 2f; 
        } 
     internal set
        {
            transform.localScale = value * 2 * Vector3.one;
        }
    }

    void Start()
    {
        plane = FindAnyObjectByType<PhysicsPlane>();
        acceleration = gravity * Vector3.down;  
        
    }

    void Update()
    {
        Vector3 previousPosition = transform.position;
        velocity += acceleration * Time.deltaTime; 
        transform.position += velocity * Time.deltaTime;

        if(plane.isCollidingWith(this))
        {   /*
            transform.position -= velocity * Time.deltaTime;
            Vector3 vel_parallel = Utils.parallelTo(velocity, plane.normal);
            Vector3 vel_perpendicullar = Utils.perpendicularTo(velocity, plane.normal);
            velocity = -CoR * vel_parallel + vel_perpendicullar;
            */
            float timeInterval = Time.deltaTime;
            float D0 = Utils.distanceToPlane(previousPosition, plane) - Radius;
            float D1 = Utils.distanceToPlane(transform.position, plane) - Radius;
            float totalDistance = D1 - D0;
            float speed = (totalDistance)/timeInterval;
            float ToI = -D0/speed;

        }
    }
}
