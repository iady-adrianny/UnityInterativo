﻿using UnityEngine;

public class Laranja : MonoBehaviour
{
    private AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //se colidir com personagem
        if (other.GetComponent<ControlePersonagem>() != null)
        {
            som.Play();
        }
    }
}
