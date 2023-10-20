using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIfHPZero : MonoBehaviour
{
    private Life life;
    [SerializeField]private GameObject prefab;
    private bool hasSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSpawned && life.GetCurrentHealth() <= 0)
        {
            BulletLaunch();
            hasSpawned = true;
        }
    }

    private void BulletLaunch()
    {
        Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
