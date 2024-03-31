using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.collider.tag.Equals("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}
