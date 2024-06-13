using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalItem : MonoBehaviour
{
    public int ID;

    private void OnMouseDown()
    {
        ItemManager.Instance.OnItemClicked(this);
    }
}
