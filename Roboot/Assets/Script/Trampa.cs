using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Me han pisado");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Me han dejado de pisar");
    }
}
