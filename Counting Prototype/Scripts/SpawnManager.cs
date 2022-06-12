using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] figures;

    private float xSpawn = 5;
    private float yMaxSpawn = 32;
    private float yMinSpawn = 22;
    private float zSpawn = 5;
    

    public void SpawnFigures(int figuresAmount)
    {
        for (int i = 0; i <= figuresAmount; i++)
        {
            int figureIndex = Random.Range(0, figures.Length);

            Instantiate(figures[figureIndex], RandomSpawnPosition(), Quaternion.Euler(Vector3.one * Random.Range(1, 180)));
        }
    }


    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xSpawn, xSpawn), Random.Range(yMinSpawn, yMaxSpawn), Random.Range(-zSpawn, zSpawn)); 
    }
}
