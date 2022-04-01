using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamaulipas : MonoBehaviour
{
    //variables
    [SerializeField]
    private ParticleSystem machingaR;
    [SerializeField]
    private ParticleSystem machingaL;

    // Update is called once per frame
    void Update()
    {

        if(!(Input.GetMouseButton(0))){
            machingaR.Play();
            machingaL.Play();
        }
        
    }
}
