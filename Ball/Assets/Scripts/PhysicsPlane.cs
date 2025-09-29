using UnityEngine;
using static Assets.Scripts.Utils;

public class PhysicsPlane : MonoBehaviour, IPhysical
{
    public Vector3 normal { 
        get 
        { 
            return transform.up; 
        } 
        internal set 
        { 
            transform.up = value; 
        } 
    }

    public bool isColliding(IPhysical other)
    {
        if (other is PhysicsPlane plane)
        {
            return false;
        }

        if (other is PhysicsSphere sphere)
        {
            return isCollidingWith(sphere);
        }

        return true;
    }

    public void overrideAfterCollision(Vector3 pos, Vector3 vel)
    {
        throw new System.NotImplementedException();
    }

    public void resolvedVelosityForCollisionWith(IPhysical other, ref Vector3 position, ref Vector3 velocity)
    {
        throw new System.NotImplementedException();
    }

    internal bool isCollidingWith(PhysicsSphere sphere)
    {
        Vector3 v = sphere.transform.position - this.transform.position;
        Vector3 p = parallelTo(v, normal);
        return p.magnitude < sphere.Radius;
    }
}
