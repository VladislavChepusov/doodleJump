using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // ������ ���������
    public float spawnInterval = 1f;   // �������� ������ ����� ��������
    public float horizontalRange = 6f; // ��������� �� ��� X ��� ������
    public float startSpawnHeight = 8f; // ������, � ������� ������ ����� ��������
    public int initialPlatformCount = 10; // ���������� �������� ��� ������ ��� ������
    public float platformSpacing = 1.5f;  // ���������� ����� �����������

    void Start()
    {
        // ������� ������� ��������� �������� � ������ ����
        for (int i = 0; i < initialPlatformCount; i++)
        {
            float spawnX = Random.Range(-horizontalRange, horizontalRange);
            float spawnY = startSpawnHeight + i * platformSpacing; // ������ ������ ������������� ��� ������ ���������
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        // ��������� ������������� �����
        InvokeRepeating("SpawnRandomPlatform", spawnInterval, spawnInterval);
    }

    void SpawnRandomPlatform()
    {
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        float randomY = Random.Range(-4f, 6f); // ��������� ����� ���� �������� ��� ������ ���������
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
