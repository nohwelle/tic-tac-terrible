using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Button button;
    public GameObject piecePrefab;

    public bool isSelected;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SelectSlot);
        //piecePrefab = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected && GameManager.Instance.playerOnePiece != piecePrefab)
        {
            GameManager.Instance.playerOnePiece = piecePrefab;
        }
    }

    void SelectSlot()
    {
        foreach (InventorySlot invSlot in Inventory.Instance.inventorySlots)
        {
            if (invSlot.isSelected)
            {
                invSlot.isSelected = false;
            }

            isSelected = true;
        }
    }
}
