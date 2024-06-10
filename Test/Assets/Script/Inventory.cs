using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<TextMeshProUGUI> itemSlots = new List<TextMeshProUGUI>(); // Liste des textes de slots d'inventaire

    public void AddItem(GameObject item)
    {
        items.Add(item);
        UpdateInventoryUI();
        Debug.Log("Item added: " + item.name);
    }

    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
        UpdateInventoryUI();
        Debug.Log("Item removed: " + item.name);
    }

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i < items.Count)
            {
                itemSlots[i].text = items[i].GetComponent<InteractableObject>().GetItemName();
            }
            else
            {
                itemSlots[i].text = "";
            }
        }
    }
}

