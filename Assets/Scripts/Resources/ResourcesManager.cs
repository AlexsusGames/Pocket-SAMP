using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    private List<int> resourcesCount = new List<int>();
    private ItemsData ResData = new ItemsData();
    private GetItemInfo getInfo = new GetItemInfo();

    private void OnEnable()
    {
        resourcesCount = ResData.GetItemList();
    }
}
