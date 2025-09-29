using UnityEngine;
using UnityEngine.UIElements;

public interface IPhysical
{
    public bool isColliding(IPhysical other);
    void overrideAfterCollision(Vector3 pos, Vector3 vel);
    public void resolvedVelosityForCollisionWith(IPhysical other, ref Vector3 position, ref Vector3 velocity);
}
