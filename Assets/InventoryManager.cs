using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<AllItems> _inventoryItems = new List<AllItems>();
    [SerializeField] private AudioSource pickupObjectSoundEffect;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item)
    {
        if (!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
            pickupObjectSoundEffect.Play();
        }
    }

    public void RemoveItem(AllItems item)
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }


    public enum AllItems
    {
        YellowKey,
        OrangeKey
    }
}
