using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    //Aqu� �nicamente vamos a guardar los datos
    public Vector3 playerPosition;
    public string mapBoundary; //El nombre del l�mite del mapa

    //Aqu� tambi�n guardar�amos el inventario y dem�s
    public List<InventorySaveData> inventorySaveData;
}
