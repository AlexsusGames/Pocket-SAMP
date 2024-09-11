using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/CarData", fileName = "CarData")]
public class SoCarData : ScriptableObject
{
    public string Name;
    public float Speed;
    public float Acceleration;
    public Sprite SideSprite;
    public Sprite TopSide;
    public int Price;
    public int Index;
}
