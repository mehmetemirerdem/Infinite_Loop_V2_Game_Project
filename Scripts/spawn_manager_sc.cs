using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager_sc : MonoBehaviour
{
    public Transform[] allitems;
    private int whichitem;
    private int xpos;
    public Transform player;

    [SerializeField]
    private bool stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        if (stopSpawning != true) {
            yield return new WaitForSeconds(1);
            whichitem = Random.Range(0, 2);
            xpos = Random.Range(-1, 2) * 5;
            Instantiate(allitems[whichitem], new Vector3(xpos, 1.5f, player.position.z + 100), allitems[whichitem].rotation);
            StartCoroutine(SpawnRoutine());
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
}
