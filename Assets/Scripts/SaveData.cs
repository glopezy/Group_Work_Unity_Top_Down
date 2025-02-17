using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //Aquí únicamente vamos a guardar los datos
    public Vector3 playerPosition;
    public string mapBoundary; //El nombre del límite del mapa

    //Aquí también guardaríamos el inventario y demás
    public List<InventorySaveData> inventorySaveData;

    //cofres
    public List<ChestSaveData> chestSaveData;

}

[System.Serializable]
public class ChestSaveData
{
    public string chestID;
    public bool isOpened;
}