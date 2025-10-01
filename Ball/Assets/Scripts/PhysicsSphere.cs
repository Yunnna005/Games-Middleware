using Assets.Scripts;
using System.Text;
using UnityEngine;

public class PhysicsSphere : MonoBehaviour, IPhysical
{

    private Vector3 acceleration, velocity;
    private const float gravity = 9.81f;
    float CoR = 0.5f;
    private Vector3 previousPosition;
    private Vector3 previousVelocity;
    private float timeInterval;

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
    
    /*
    public float mass = 1.0f;
    */

    void Start()
    {
        acceleration = gravity * Vector3.down;   
    }

    void Update()

    { previousPosition = transform.position;
        previousVelocity = velocity;
        velocity += acceleration * Time.deltaTime; 
        transform.position += velocity * Time.deltaTime;
        /*
        transform.position -= velocity * Time.deltaTime;
        Vector3 vel_parallel = Utils.parallelTo(velocity, plane.normal);
        Vector3 vel_perpendicullar = Utils.perpendicularTo(velocity, plane.normal);
        velocity = -CoR * vel_parallel + vel_perpendicullar;
        */
    }

    public bool isColliding(IPhysical other)
    {
        if (other is PhysicsPlane)
        {
            return (other as PhysicsPlane).isCollidingWith(this);
        }

        if (other is PhysicsSphere sphere)
        {
            Vector3 v = sphere.transform.position - this.transform.position;
            return v.magnitude < (sphere.Radius + this.Radius);
        }

        return true;
    }

    public void resolvedVelosityForCollisionWith(IPhysical other, ref Vector3 position, ref Vector3 velocity)
    {
        if(other is PhysicsPlane)

        {   // Calculate Time of Impact (ToI) 
            PhysicsPlane plane = other as PhysicsPlane;
            timeInterval = Time.deltaTime;
            float D0 = Utils.distanceToPlane(previousPosition, plane) - Radius;
            float D1 = Utils.distanceToPlane(transform.position, plane) - Radius;
            float totalDistance = D1 - D0;
            float speed = (totalDistance) / timeInterval;
            float ToI = -D0 / speed;

            // Resollve vel at ToI
            Vector3 velAtToI = previousVelocity + acceleration * ToI;
            Vector3 posAtToI = previousPosition + velAtToI * ToI;
            Vector3 parVel = Utils.parallelTo(velAtToI, plane.normal);
            Vector3 perpVel = Utils.perpendicularTo(velAtToI, plane.normal);
            Vector3 newVel = -CoR * parVel + perpVel;

            // resolve pos at end of interval
            float remainingTime = timeInterval - ToI;
            velocity = newVel + acceleration * remainingTime;
            position = posAtToI + velocity * remainingTime;
            float d = Utils.distanceToPlane(position, plane) - Radius;

            if (d < 0)
            {
                position -= d * plane.normal;
            }
        }

        if (other is PhysicsSphere)
        {
            //calculate ToI
            PhysicsSphere sphere = other as PhysicsSphere;
            //float D0 = Vector3.Distance(previousPosition, sphere.previousPosition) - Radius -sphere.Radius: //distance betwwen 2 spheres
            //float D1 = Vector3.Distance(transform.position, sphere.transform.position) - Radius -sphere.Radius: 
            /*
            float totalDistance = D1 - D0;
            float speed = (totalDistance) / timeInterval;
            float ToI = -D0 / speed;
            
            Vector3 velAtToI = previousVelocity + acceleration * ToI;
            Vector3 posAtToI = previousPosition + velAtToI * ToI;

            Vector3 velAtToIOther = sphere.previousVelocity + sphere.acceleration * ToI;
            Vector3 posAtToIOther = sphere.previousPosition + sphere.velAtToI * ToI;
            
            Vector3 normal = (posAtToI - pasAtToIOther).normalized;

            Vector3 parVel = Utils.parallelTo(velAtToI, normal);
            Vector3 perpVel = Utils.perpendicularTo(velAtToI, normal);
            

            Vector3 parVelOther = Utils.parallelTo(velAtToIOther, sphere.normal);
            Vector3 perpVelOther = Utils.perpendicularTo(velAtToIOther, sphere.normal);

            Vector3 velPerpAfter = (momentum formula)V1;
            Vector3 velPerpAfterOther = (momentum formula)V2;
            Vector3 velAfter = -CoR * parVel + perpVelAfter;
            Vector3 newVel = -CoR * parVelOther + perpVelAfterOther;
            */
            
            timeInterval = Time.deltaTime;

            Vector3 deltaPos = position - sphere.transform.position;
            float dist = deltaPos.magnitude;
            float minDist = Radius + sphere.Radius;

            if (dist < minDist)
            {
                Vector3 normal = deltaPos.normalized;

                Vector3 relVel = velocity - sphere.velocity;
                float relVelAlongNormal = Vector3.Dot(relVel, normal);

                if (relVelAlongNormal < 0f)
                {
                    /*
                    float mA = Mass;
                    float mB = sphere.Mass;

                    float j = -(1 + CoR) * relVelAlongNormal / (1 / mA + 1 / mB);

                    velocity += (j / mA) * normal;
                    sphere.velocity -= (j / mB) * normal;

                    float penetration = minDist - dist;
                    if (penetration > 0f)
                    {
                        Vector3 correction = normal * (penetration / (mA + mB));
                        position += correction * mB;
                        sphere.transform.position -= correction * mA;
                    }
                    */
                }
            }
        }
    }

    public void overrideAfterCollision(Vector3 pos, Vector3 vel)
    {
        throw new System.NotImplementedException();
    }
}
