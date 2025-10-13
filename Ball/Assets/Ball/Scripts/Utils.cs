using UnityEngine;

namespace Assets.Scripts
{
    internal static class Utils
    {
        internal static Vector3 parallelTo(Vector3 v, Vector3 n)
        {
            Vector3 n_normal = n.normalized;
            return Vector3.Dot(v, n_normal) * n_normal;
        }

        internal static Vector3 perpendicularTo(Vector3 v, Vector3 n)
        {
            return v - parallelTo(v, n);
        }

        internal static float distanceToPlane(Vector3 point, PhysicsPlane p)
        {
            Vector3 v = point - p.transform.position;
            return Vector3.Dot(v, p.normal);
        }
    }
}
