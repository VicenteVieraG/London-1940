using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamaulipas : MonoBehaviour
{
    //variables
    [SerializeField]
    [Tooltip("Disparo 1R")]  
    private ParticleSystem machingaR1;
    
    [SerializeField]
    [Tooltip("Disparo 1L")]  
    private ParticleSystem machingaL1;

    [SerializeField]
    [Tooltip("Disparo 2R")]  
    private ParticleSystem machingaR2;
    
    [SerializeField]
    [Tooltip("Disparo 2L")]  
    private ParticleSystem machingaL2;

    [SerializeField]
    [Tooltip("Efecto de Fogonazo")]
    private GameObject fogonazo;

    [SerializeField]
    [Tooltip("Tamaño del fogonazo")]
    private Vector3 s;
    private bool weapon;
    private bool chutin;

    void Awake(){
        weapon = false;
        chutin = false;
    }
    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown("f")){
            weapon = !weapon;
        }

        if(Input.GetMouseButton(0)){
            //Fogonazo
            var fogo1 = Instantiate(fogonazo,machingaR1.transform.position,Quaternion.LookRotation(Vector3.up)) as GameObject;
            Destroy(fogo1,  .1F);
            fogo1.transform.localScale = s; 
            var fogo2 = Instantiate(fogonazo,machingaL1.transform.position,Quaternion.LookRotation(Vector3.up)) as GameObject;
            Destroy(fogo2,  .1F);
            fogo2.transform.localScale = s;
            
            //Tipo de disparo
            if(weapon){
                //Disparo normal
                if(!chutin){
                    machingaR1.Play();
                    machingaL1.Play();
                    chutin = true;
                }
            }else{
                //Disparo especial
                if(!chutin){
                    machingaR2.Play();
                    machingaL2.Play();
                    chutin = true;
                }
            }        
        }else{
            chutin = false;
            machingaR1.Stop();
            machingaL1.Stop();
            machingaR2.Stop();
            machingaL2.Stop();
        }   
    }
}

