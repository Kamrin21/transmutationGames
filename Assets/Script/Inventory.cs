using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged
{
    // Start is called before the first frame update
    [SerializeField] Transform elementSlot;
    [SerializeField] Transform typeSlot;
    [SerializeField] Transform powerSlot;
    [SerializeField] Transform slots;
    [SerializeField] Transform readerSlot;
    [SerializeField] Text inventoryText;
    [SerializeField] Text readerText;
    void Start()
    {
        HasChanged();
    }

    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");
        string reader = "";
        foreach (Transform slotTransform in slots)
        {
            if (slotTransform == elementSlot)
            {
                GameObject item = slotTransform.GetComponent<Slot>().item;
                if (item)
                {
                    builder.Append(item.GetComponent<ItemProperties>().element);
                    builder.Append(" - ");
                }
            }
            if (slotTransform == typeSlot)
            {
                GameObject item = slotTransform.GetComponent<Slot>().item;
                if (item)
                {
                    builder.Append(item.GetComponent<ItemProperties>().type);
                    builder.Append(" - ");
                }
            }
            if (slotTransform == powerSlot)
            {
                GameObject item = slotTransform.GetComponent<Slot>().item;
                if (item)
                {
                    builder.Append(item.GetComponent<ItemProperties>().power);
                    builder.Append(" - ");
                }
            }
        }
        GameObject readerItem = readerSlot.GetComponent<Slot>().item;
        if (readerItem)
        {
            reader = "- " + readerItem.GetComponent<ItemProperties>().element + " - " + readerItem.GetComponent<ItemProperties>().type + " - " + readerItem.GetComponent<ItemProperties>().power + " -";
        }
        inventoryText.text = builder.ToString();
        readerText.text = reader;
    }
    // Update is called once per frame
    
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}
