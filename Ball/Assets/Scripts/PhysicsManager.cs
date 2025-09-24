using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    List<IPhysical> allObjects;

    void Start()
    {
        //https://stackoverflow.com/questions/539436/cast-interface-to-its-concrete-implementation-object-or-vice-versa
        //implement interface to all objects
        //implement physicsManager
        //add multible planes and spheres 
        //allObjects = FindObjectsOfType<IPhysical>().ToList();
    }

    void Update()
    {
        
    }
}
