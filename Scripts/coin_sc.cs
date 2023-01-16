using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_sc : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z + 55 < player.position.z)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
