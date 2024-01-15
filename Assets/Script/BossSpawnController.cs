using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnController : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossspawn;
    public GameObject box;
    public GameObject box1spawn;
    public GameObject box2spawn;
    public GameObject box3spawn;
    public GameObject spikeHead;
    public GameObject spikeHeadSpawn;
    public static BossSpawnController Instance;
    
    public void Awake()
    {
        Instance = this;
    }
    public void BossSpawn()
    {
        Instantiate(spikeHead, spikeHeadSpawn.transform.position, spikeHeadSpawn.transform.rotation);
        Instantiate(boss, bossspawn.transform.position, bossspawn.transform.rotation);
        Instantiate(box, box1spawn.transform.position, box1spawn.transform.rotation);
        Instantiate(box, box2spawn.transform.position, box2spawn.transform.rotation);
        Instantiate(box, box3spawn.transform.position, box3spawn.transform.rotation);
    }
}
