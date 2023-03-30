using System.Collections;
using System.Collections.Generic;
using Articy.Stygian_Crossing.GlobalVariables;
using UnityEngine;

public class Key : InspectableObject
{

    protected override void ObjectInteraction(string arg1, object arg2)
    {
        base.ObjectInteraction("GlobalVariables.StorageKey", true);
    }
}
