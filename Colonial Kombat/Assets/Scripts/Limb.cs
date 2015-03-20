using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Limb {

    public GameObject Object;
    public string Name;
    public Collider2D Collider;

    private LimbType _type = LimbType.Unspecified;

    public Limb()
    {
        Name = "Unknown";
        SetLimbType(LimbType.Head);
    }

    public Limb( LimbType type )
    {
        Name = "Unknown";
        SetLimbType(type);
    }

    public Limb( string name, LimbType type)
    {
        Name = name;
        SetLimbType(type);
    }

    public void SetLimbType( LimbType type )
    {
        if (type != _type)
        {
            // Unload the old gameobject for this type of limb.
            if( Object != null ) GameObject.DestroyImmediate(Object);
            
            // Load the appropriate gameobject for this limb type.
            switch (type)
            {
                case LimbType.Head:
                    // Instantiate a head. If there are special things about this limb we could add another if-then or switch
                    //  to determine what to do. i.e. (maybe we want to load a squid head, or custom head)???
				Object = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Character1")) as GameObject;
                    Object.transform.position = new Vector3( 0.0f, 0.0f, 0.0f );
                    break;
                case LimbType.Arm:
                    // @TODO: add an arm prefab....
                    //  copy the syntax above to make a new arm.
                    break;
                case LimbType.Leg:
                    // @TODO: add an arm prefab....
                    //  copy the syntax above to make a new leg.
                    break;
                case LimbType.Torso:
                    // @TODO: add an arm prefab....
                    //  copy the syntax above to make a new torso.
                    break;
            }
            // set the type to the new type
            _type = type;
        }
    }
}

public enum LimbType
{
    Unspecified,
    Head,
    Arm,
    Leg,
    Torso
}
