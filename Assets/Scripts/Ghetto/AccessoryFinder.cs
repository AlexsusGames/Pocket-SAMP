using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryFinder 
{
    private SoAccessory[] accessories => Resources.LoadAll<SoAccessory>("Accessories");

    public SoAccessory GetAccessoryByName(string name)
    {
        var accessory = accessories;
        for (int i = 0; i < accessory.Length; i++)
        {
            if (name == accessory[i].Name) return accessory[i];
        }
        return null;
    }
}
