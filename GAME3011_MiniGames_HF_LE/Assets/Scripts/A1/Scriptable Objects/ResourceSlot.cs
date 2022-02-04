using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResourceSlot : MonoBehaviour
{
    public List<Resources> resourcesOnGrid;
    string buttonName;
    public TMP_Text resourceNameText;
    public TMP_Text resourceText;
    public Image resourceIcon;

    private void Start()
    {
        //buttonName = gameObject.name;
        //
        //if (dayEvent != null)
        //{
        //    int i = int.Parse(buttonName);
        //    Grid.hasEvent[i] = true;
        //
        //    //trying to get description to display for multiple events on the same day
        //    //for now just have 1 in the list
        //    for (int index = 0; index < dayEvent.Count; index++)
        //    {
        //        eventIcon.sprite = dayEvent[index].icon;
        //    }
        //}
    }

    public void pressed()
    {
        //for (int index = 0; index < dayEvent.Count; index++)
        //{
        //    eventNameText.text = dayEvent[index].name;
        //    eventText.text = dayEvent[index].description;
        //    eventPanelIcon.sprite = dayEvent[index].icon;
        //}
    }
}
