using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    Vector3 sInicial = new Vector3(0,0,0);
    [Tooltip("Escala de la explosion")]
    public Vector3 sFinal = new Vector3(10f,10f,10f);
    float tTotal;
    [Tooltip("Tiempo que tarda en alcanzar su maximo tamaño la explosion")]
    public float tFinal = 5f;
    float porcentaje = 0;
    GameObject explosion;
    bool contact = false;
    [Tooltip("Material de la explosion")]
    public Material Ma;


    void OnCollisionEnter(Collision col){
        if(!contact && col.gameObject.tag != "Bomb"){
            contact = true;

            explosion = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            explosion.transform.position = this.transform.position;
            explosion.tag="Bomb";
            explosion.GetComponent<Renderer>().material = Ma;
        }
    }

    void Update(){
        if(contact && porcentaje <= 1f ){
            tTotal += Time.deltaTime;
            porcentaje = tTotal/tFinal;
            explosion.transform.localScale = Vector3.Lerp(sInicial,sFinal, porcentaje);
        }
    }
}
