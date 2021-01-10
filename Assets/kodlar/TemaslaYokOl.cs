﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerPatlama;
    GameObject OyunKontrol;
    OyunKontrol kontrol;


    void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
        
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "sinir")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position,transform.rotation);
            kontrol.ScoreArttir(10);
        }
        if (col.tag=="Player")
        {
            Instantiate(patlama, col.transform.position, col.transform.rotation);
            kontrol.oyunBitti();
        }
    }
}