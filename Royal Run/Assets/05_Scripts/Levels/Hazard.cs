using System.Collections;
using UnityEditor.Search;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private GameObject hazardPrefab;
    [SerializeField] private float spawnYOffset;
    [SerializeField] private float[] lanes = { -2.8f, 0, 2.8f };

    private void Start()
    {
        SpawnHazard();
    }

    private void SpawnHazard()
    {
        float randomXPosition = lanes[Random.Range(0, lanes.Length)];
        Vector3 spawnPosition = new Vector3(randomXPosition, transform.position.y + spawnYOffset, transform.position.z);
        Instantiate(hazardPrefab, spawnPosition, Quaternion.identity, transform);
    }
}
