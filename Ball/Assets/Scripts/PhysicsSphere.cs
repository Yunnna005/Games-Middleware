using Assets.Scripts;
using System.Text;
using UnityEngine;

public class PhysicsSphere : MonoBehaviour
{
    PhysicsPlane plane;
    private Vector3 acceleration, velocity;
    private const float gravity = 9.81f;

    public float Radius { get { return transform.localScale.x / 2f; } internal set
        {
            transform.localScale = value * 2 * Vector3.one;
        } }

    void Start()
    {
        plane = FindAnyObjectByType<PhysicsPlane>();
        acceleration = gravity * Vector3.down;  
        
    }

    void Update()
    {
        velocity += acceleration * Time.deltaTime; 
        transform.position += velocity * Time.deltaTime;

        if(plane.isCollidingWith(this))
        {
            Vector3 vel_parallel = Utils.parallelTo(velocity, plane.normal);
            Vector3 vel_perpendicullar = Utils.perpendicularTo(velocity, plane.normal);
            velocity = -vel_parallel + vel_perpendicullar;
        }
    }
}
