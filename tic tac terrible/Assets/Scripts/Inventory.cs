using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> inventorySlots;

    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (InventorySlot slot in FindObjectsOfType<InventorySlot>())
        {
            inventorySlots.Add(slot);
        }

        inventorySlots[0].isSelected = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
