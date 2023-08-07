using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSinkhole : MonoBehaviour
{
    [SerializeField] private GameObject sinkholeCrackPrefab;
    [SerializeField] protected Transform spawnPoint;

    public void SpawnSinkholeCrack()
    {
        var sinkholeCrack = Instantiate(sinkholeCrackPrefab, spawnPoint.position, spawnPoint.rotation);
        sinkholeCrack.GetComponent<SinkholeCrackSendDamage>().canSend = false;
    }
}