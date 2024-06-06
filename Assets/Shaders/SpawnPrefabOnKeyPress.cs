using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnKeyPress : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject prefabToSpawn; // Префаб для создания
    public Transform spawnPoint; // Место создания префаба

    void Update()
    {
        // Проверяем нажатие кнопки "B"
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnPrefab();
        }
    }

    void SpawnPrefab()
    {
        // Создаем новый экземпляр префаба в указанной точке
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Активируем только в случае, если префаб был неактивным
        if (!newPrefab.activeSelf)
        {
            newPrefab.SetActive(true);
        }
    }
}
