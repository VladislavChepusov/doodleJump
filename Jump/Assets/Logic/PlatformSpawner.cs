using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Префаб платформы
    public float spawnInterval = 1f;   // Интервал спавна новых платформ
    public float horizontalRange = 6f; // Дистанция по оси X для спавна
    public float startSpawnHeight = 8f; // Высота, с которой начнем спавн платформ
    public int initialPlatformCount = 10; // Количество платформ для спавна при старте
    public float platformSpacing = 1.5f;  // Расстояние между платформами

    void Start()
    {
        // Сначала создаем несколько платформ в начале игры
        for (int i = 0; i < initialPlatformCount; i++)
        {
            float spawnX = Random.Range(-horizontalRange, horizontalRange);
            float spawnY = startSpawnHeight + i * platformSpacing; // Высота спавна увеличивается для каждой платформы
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        // Запускаем повторяющийся спавн
        InvokeRepeating("SpawnRandomPlatform", spawnInterval, spawnInterval);
    }

    void SpawnRandomPlatform()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        float randomY = Random.Range(-4f, 6f); // Параметры могут быть изменены для лучшей настройки
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
