using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> Items;

    public GameObject inventoryDescription;

    private void Start()
    {
        Items = new List<Item>();
        Mushroom mushroom = new Mushroom();
        Items.Add(mushroom);
    }

    private void Update()
    {
        inventoryDescription.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = Items[0].Description;
    }
}
