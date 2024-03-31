using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
    public GameObject Inventory;
    private InventoryController inventoryController;

    void Start()
    {
        inventoryController = Inventory.GetComponent<InventoryController>();
    }

    public void Interact()
    {
        inventoryController.addItem(gameObject);
    }
}
