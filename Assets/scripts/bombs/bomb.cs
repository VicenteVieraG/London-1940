using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Explosion")]  
    private GameObject explosion;
    [SerializeField]
    [Tooltip("Fuerza")]  
    private float F;
    [SerializeField]
    [Tooltip("Radio")]  
    private float R;
    private Rigidbody RB;
    bool contact;

    void Start(){
        contact = false;
    }

    void OnCollisionEnter(Collision col){
        if(!contact && col.gameObject.tag != "Bomb"){
            contact = true;
            var expl = Instantiate(explosion,this.transform.position,Quaternion.identity) as GameObject;
            expl.transform.localScale = new Vector3(20f,20f,20f);
            Destroy(expl, 2f);

            Collider[] colliders = Physics.OverlapSphere(this.transform.position, R);
            foreach(Collider hit in colliders){
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null){
                    rb.AddExplosionForce(F, this.transform.position, R, 10F);
                }
            }
        }
    }
}
