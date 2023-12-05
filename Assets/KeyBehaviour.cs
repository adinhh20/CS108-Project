using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(_itemType);
            Destroy(gameObject);
        }
    }
}
