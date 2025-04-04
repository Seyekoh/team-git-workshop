using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<GameObject> items;
    private GameObject item;

    private GameObject hand;

    public GameObject equippedWeapon;
    public Vector3 equippedPosition;
    public Vector3 equippedRotation;
    public Vector3 equippedScale;

    [SerializeField] private int numItemsInInventory = 0;

    private void Start()
    {
        items = new List<GameObject>();
        hand = GameObject.Find("RIGHT_HAND_COMBAT");
    }

    private void Update()
    {
        if (equippedWeapon != null)
        {
            if (equippedWeapon.name.Equals("Dagger"))
            {
                equippedPosition = new Vector3((float)-0.0123, (float)-0.3687, (float)-0.0235);
                equippedRotation = new Vector3((float)-79.739, (float)-122.536, (float)3.119);
                equippedScale = new Vector3((float)0.45, (float)0.45, (float)0.45);


                equippedWeapon.SetActive(true);
                equippedWeapon.transform.parent = hand.transform;
                equippedWeapon.transform.localPosition = equippedPosition;
                equippedWeapon.transform.localEulerAngles = equippedRotation;
                equippedWeapon.transform.localScale = equippedScale;
            }
        }
    }

    private int getNumItemsInInventory()
    {
        return numItemsInInventory;
    }

    public void addItem(GameObject item)
    {
        if (item != null)
        {
            items.Add(item);
            numItemsInInventory++;
        }

        if (equippedWeapon == null)
        {
            equippedWeapon = item;
        }
    }
}
