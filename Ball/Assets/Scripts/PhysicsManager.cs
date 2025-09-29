using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    List<IPhysical> allObjects = new List<IPhysical>();

    void Start()
    {
        allObjects.Clear();

        var allMonobehaviours = FindObjectsOfType<MonoBehaviour>();

        foreach (var mb in allMonobehaviours)
        {
            if (mb is IPhysical physical)
            {
                allObjects.Add(physical);
            }
        }
    }

    private void Update()
    {
        for(int i = 0; i< allObjects.Count-1; i++)
        {
            for (int j = 1; j< allObjects.Count; j++)
            {
                if (allObjects[i].isColliding(allObjects[j]))
                {
                    Vector3 pos = Vector3.zero, vel = Vector3.zero;
                    allObjects[i].resolvedVelosityForCollisionWith(allObjects[j], ref pos, ref vel);
                    allObjects[j].overrideAfterCollision(pos, vel);

                }
            }
        }
    }
}
