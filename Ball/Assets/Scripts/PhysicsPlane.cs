using UnityEngine;
using static Assets.Scripts.Utils;

public class PhysicsPlane : MonoBehaviour
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

    internal bool isCollidingWith(PhysicsSphere sphere)
    {
        Vector3 v = sphere.transform.position - this.transform.position;
        Vector3 p = parallelTo(v, normal);
        return p.magnitude < sphere.Radius;
    }
}
