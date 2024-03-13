using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject bulletPrefab;
    List<GameObject> bulletPool;
    public float speed = 5f;

    void Start()
    {
        bulletPool = new List<GameObject>();
    }

    void ShootBullet()
    {
        for(int i = 0; i < bulletPool.Count; i++)
        {
            if(bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].transform.position = transform.position;
                bulletPool[i].SetActive(true);
                return;
            }
        }

        GameObject currentBullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        bulletPool.Add(currentBullet);
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
