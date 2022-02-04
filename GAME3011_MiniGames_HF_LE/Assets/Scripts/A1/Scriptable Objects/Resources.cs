using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "EventSystem/Resource")]
public class Resources : ScriptableObject
{
    public new string name = "Resource";
    [TextArea(10, 100)]
    public string description = "This is a Resource";
    public int resourceAmount = 5000;
}
