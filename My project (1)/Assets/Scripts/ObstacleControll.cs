using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControll : MonoBehaviour
{

    public GameObject obstacle;
    public bool calling;

    public float positionYRange;

    private int time;

    private void OnEnable()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        time = Random.Range(2, 3);
        yield return new WaitForSeconds(time);
        float spawnPositionY = Random.Range(-positionYRange, positionYRange);
        Vector3 spawnPos = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        Instantiate(obstacle, spawnPos, Quaternion.identity);
        StartCoroutine(Spawning());
    }
}
