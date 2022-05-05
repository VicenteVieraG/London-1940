using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTurret : MonoBehaviour{
    private LineRenderer line;
    [SerializeField]
    [Tooltip("Fogonazo")]
    private GameObject Fogonazo;
    void Start(){
        line = GetComponent<LineRenderer>();
    }

    void Update(){
        RaycastHit hit;
        if(Input.GetMouseButton(1)){
            var effect = Instantiate(Fogonazo,this.transform) as GameObject;
            effect.transform.localScale = new Vector3(.000001f,.000001f,.000001f);
            Destroy(effect, .1f);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)){
                hit.rigidbody.AddForceAtPosition (5000 * transform.forward, hit.point);
            }
        }
    }
}