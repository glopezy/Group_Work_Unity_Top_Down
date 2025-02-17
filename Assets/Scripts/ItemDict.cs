using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDict : MonoBehaviour
{
    
    //usamos un dict para mantener registro de ids unicos de los objetos
    public List<Item> itemPrefabs;
    private Dictionary<int, GameObject> itemDict;

    //antes que Start
    private void Awake()
    {
        itemDict = new Dictionary<int, GameObject>();

        //asignar ids (hacendo +1)
        for (int i = 0; i < itemPrefabs.Count; i++)
        {
            if (itemPrefabs[i] != null)
            {
                //empiezan en 1 y van aumentando
                itemPrefabs[i].ID = i + 1;
            }
        }

        foreach(Item item in itemPrefabs)
        {
            itemDict[item.ID] = item.gameObject;
        }
    }


    public GameObject GetItemPrefab(int itemID)
    {
        itemDict.TryGetValue(itemID, out GameObject prefab);
        if (prefab == null)
        {
            Debug.Log($"No {itemID} en dict");
        }
        //igualmente fallará si intenta devolver null pero así sabemos por qué
        return prefab;
    }
}
