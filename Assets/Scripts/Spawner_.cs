using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_ : MonoBehaviour
{
    public GameObject[] monsters;
    public Queue<GameObject> queue = new Queue<GameObject>();

    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            SpawnMonster();
        }

        StartCoroutine(MonsterSpawn());
    }

    private void SpawnMonster()
    {
        int Index = Random.Range(0, monsters.Length);
        GameObject gameObject = Instantiate(monsters[Index], this.gameObject.transform);
        queue.Enqueue(gameObject);
        gameObject.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject gameObject = queue.Dequeue();
        return gameObject;
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            GameObject gameObject = GetQueue();
            if (gameObject != null)
            {
                gameObject.SetActive(true);
                gameObject.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            }
            else
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }


}
