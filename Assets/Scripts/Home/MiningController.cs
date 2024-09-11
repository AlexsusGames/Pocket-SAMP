using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningController 
{
    public void Subscribe(MiningVisual visual,MiningChanger changer)
    {
        changer.OnChange += visual.SetData;
    }
    public void Unsubscribe(MiningVisual visual, MiningChanger changer)
    {
        changer.OnChange -= visual.SetData;
    }
}
