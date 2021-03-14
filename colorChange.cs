using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(1/Mathf.Pow(Vector3.Distance(transform.position, player.transform.position), 1.5f), 1/Mathf.Pow(Vector3.Distance(transform.position, player.transform.position), 1.5f), 1/Mathf.Pow(Vector3.Distance(transform.position, player.transform.position), 1.5f));
    }
}
