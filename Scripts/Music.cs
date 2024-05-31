using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<PlayerHealth>();
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
