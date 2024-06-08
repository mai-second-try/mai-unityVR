using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnKeyPress : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject prefabToSpawn; // Префаб для создания
    public Transform spawnPoint; // Место создания префаба
    public float stepDistance = 1f; // расстояние, которое считается за шаг
    private int stepCount; // кол-во шагов
    private Vector3 lastPosition; // позиция игрока в прошлом кадре
    void Start()
    {
        // получаем позицию игрока в прошлом кадре
        lastPosition = transform.position;
        SpawnPrefab();
    }

    void Update()
    {
        // текущая позиция игрока
        Vector3 currentPosition = transform.position;

        // вычисляем расстояние которое прошел игрока относительно предыдущего кадра
        float distance = Vector3.Distance(currentPosition, lastPosition);

        // если расстояние между текущей и прошлой позицией больше дистанции шага
        if (distance >= stepDistance)
        {
            // увеливаем кол-во шагов
            stepCount++;

            // если кол-во шагов больше или равно n
            if (stepCount >= 7)
            {
                // сбрасываем кол-во шагов
                stepCount = 0;

                // вызываем метод SpawnPrefab()
                SpawnPrefab();
            }

            // получаем текущую позицию игрока в качестве позиции игрока в прошлом кадре
            lastPosition = currentPosition;
        }
    }

    void SpawnPrefab()
    {
        /*
        // Создаем новый экземпляр префаба в указанной точке
        GameObject newPrefab = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Активируем только в случае, если префаб был неактивным
        if (!newPrefab.activeSelf)
        {
            newPrefab.SetActive(true);
        }
        Debug.Log("Всё норм");
        */
        GameObject newPrefab = Instantiate(prefabToSpawn);

        // получаем текущую позицию игрока
        Vector3 position = transform.position;

        // вычисляем новую позицию префаба
        // position.x += 2f; // добавляем 2 к координате x

        // устанавливаем новую позицию и вращение префаба
        newPrefab.transform.position = position;
        newPrefab.transform.rotation = Quaternion.identity;

        if (!newPrefab.activeSelf)
        {
            newPrefab.SetActive(true);
        }

        Debug.Log("spawn!");
    }
}
