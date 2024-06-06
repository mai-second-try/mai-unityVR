/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnPrefabOnButtonPress : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject prefabToSpawn; // Префаб для создания
    public Transform spawnPoint; // Место создания префаба

    private XRController xrController;

    void Start()
    {
        xrController = GetComponent<XRController>();
        if (xrController == null)
        {
            Debug.LogError("XR Controller not found on this object!");
        }
    }

    void Update()
    {
        // Проверяем нажатие кнопки "A" на XR контроллере
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonPressed) && buttonPressed)
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
}       */

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
