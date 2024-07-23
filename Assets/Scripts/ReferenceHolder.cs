using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class ReferenceHolder : MonoBehaviour
{
    public GameObject ContentGO;
    [AllowNull]
    public GameObject CurrentItemDropGO;
    public Scrollbar scrollbar;
    public Button TakeAllButton;
}
