using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapis : MonoBehaviour
{
    public string stanZapis;
    void Start()
    {
       // stanZapis = PlayerPrefs.GetString("stanZapis", "Stan Konta: 1001");

           // GameObject.Find("wyplata").GetComponent<Wyp³ata>().StanKonta = stanZapis;
    }

    // Update is called once per frame
    void Update()
    {
        //stanZapis = GameObject.Find("wyplata").GetComponent<Wyp³ata>().StanKonta;
    }

    public void zapisz()
    {
        //PlayerPrefs.SetString("stanZapis", stanZapis);

        //PlayerPrefs.Save();
    }
    public void OnApplicationQuit()
    {
        //PlayerPrefs.SetString("stanZapis", stanZapis);

       // PlayerPrefs.Save();
    }
}
