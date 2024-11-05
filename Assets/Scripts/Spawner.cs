using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.ParticleSystem;

public class Spawner : MonoBehaviour
{
    [Header("Pool Paramater")]
    public GameObject prefabParticle;
    public float speedParticles;
    public int maxPooledItem;

    [Header("Spawner Data")]
    public float spawnRate;
    public float spawnRadius;

    public Transform particleContainers;

    public IObjectPool<GameObject> poolParticles;

    // Start is called before the first frame update
    void Start()
    {
        poolParticles = new ObjectPool<GameObject>(OnCreateItem, OnTakeItem, OnReturnToPool, OnDestroyPool, maxSize: maxPooledItem);

        for (int i = 0; i < maxPooledItem; i++)
        {
            poolParticles.Release(CreateParticles());
        }
        StartCoroutine(spawnInterval());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnInterval()
    {
        GameObject p = poolParticles.Get();
        yield return new WaitForSeconds(1/spawnRate);
        StartCoroutine(spawnInterval());
    }

    private GameObject CreateParticles()
    {
        GameObject particle = Instantiate(prefabParticle, particleContainers);
        ReturnToPool rtp = particle.AddComponent<ReturnToPool>();
        rtp.pool = poolParticles;

        return particle;
    }

    public GameObject OnCreateItem()
    {
        return CreateParticles();
    }

    public void OnTakeItem(GameObject item)
    {
        item.transform.position = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        item.transform.rotation = transform.rotation;
        item.SetActive(true);
        /*Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        item.transform.position = (Vector2)transform.position + spawnCircle;
        Rigidbody2D rb2dItem = item.GetComponent<Rigidbody2D>();
        rb2dItem.velocity = transform.right * speed;*/
    }

    public void OnReturnToPool(GameObject item)
    {
        item.SetActive(false);
    }

    public void OnDestroyPool(GameObject item)
    {
        Destroy(item);
    }
}
