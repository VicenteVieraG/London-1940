using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeFlight : MonoBehaviour
{
    //Cams
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject cam5;
    public GameObject cam6;
    int camN;
    //forward speed
    [Tooltip("Velocidad de avance inicial")]
    public float speed;
    //horizontal speed
    [Tooltip("Velocidad de giro horizontal")]
    public float rSpeed;
    [Tooltip("Rotacion vertical")]
    //Rotational movement
    public float rotation;
    [Tooltip("Rotacion horizontal")]
    public float hRotation;
    //GUI para mostrar
    [Tooltip("GUI Seleccionada")]
    public GameObject GUI;
    //Objeto de bomba
    [Tooltip("Objeto que va a soltar como Bomba")]
    public Rigidbody Bomb;
    public Transform offSet;
    [Tooltip("Sistema de particulas")]
    public ParticleSystem bullets;  
    [SerializeField]
    private ParticleSystem machingaR;
    [SerializeField]
    private ParticleSystem machingaL;
    // Bandera para aplicar zoom a camara
    private bool zoomActived = false;
    private Camera cam;
    //Torreta con camara
    [Tooltip("Torreta con camara")]
    [SerializeField]
    private GameObject Torreta;
    [Tooltip("Bengala")]
    [SerializeField]
    private ParticleSystem Bengala;
    private bool b;
    private bool turret;
    // Start is called before the first frame update
    void Start()
    {
        rSpeed=0;
        rotation=0;
        hRotation=0;
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        cam5.SetActive(false);
        cam6.SetActive(false);
        
        cam =  cam1.GetComponent<Camera>();

        turret = false;
        b=true;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(turret){
            //Cambia a la vista normal
            if(Input.GetKeyDown("q")){
            turret = !turret;
            var tam = GetComponent<tamaulipas>();
            tam.enabled = !tam.enabled;

            cam1.SetActive(true);
            cam6.SetActive(false);
            }

            //forward position
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            //mouse movemt
            rotation=Input.GetAxis("Mouse Y");
            hRotation=Input.GetAxis("Mouse X");

            Vector3 a = new Vector3(rotation*-5f,hRotation*5f,0);

            Torreta.transform.Rotate(a, Space.Self);
        }else{
            //Vuelo del avion normal

            //forward position
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            if(Input.GetKey("w") && speed<=80){
                    speed+=Time.deltaTime*10;
            }

            if(Input.GetKey("s") && speed>=3){
                    speed-=Time.deltaTime*10;
            }
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            //move horizontaly
            if(Input.GetKey("a") && rSpeed>-50){
                rSpeed-=Time.deltaTime*10;
            }

            if(Input.GetKey("d") && rSpeed<50){
                rSpeed+=Time.deltaTime*10;
            }
            
            transform.Translate(Vector3.right * Time.deltaTime * rSpeed);

            //mouse movemt
            rotation=Input.GetAxis("Mouse Y");
            hRotation=Input.GetAxis("Mouse X");

            Vector3 a = new Vector3(rotation*5f,0,hRotation*5f);

            transform.Rotate(a, Space.Self);

            //drop bomb
            if (Input.GetKeyDown(KeyCode.Space)){
                Rigidbody instance;
                instance = Instantiate(Bomb, offSet.position, offSet.rotation) as Rigidbody;
            }

            //change camera
            if (Input.GetKeyDown("c")){
                camN++;
                switch(camN){
                    case 1:
                        cam1.SetActive(false);
                        cam2.SetActive(true);
                        cam3.SetActive(false);
                        cam4.SetActive(false);
                        cam5.SetActive(false);
                        cam = cam2.GetComponent<Camera>();
                        break;
                    case 2:
                        cam1.SetActive(false);
                        cam2.SetActive(false);
                        cam3.SetActive(true);
                        cam4.SetActive(false);
                        cam5.SetActive(false);
                        cam = cam3.GetComponent<Camera>();
                        break;
                    case 3:
                        cam1.SetActive(false);
                        cam2.SetActive(false);
                        cam3.SetActive(false);
                        cam4.SetActive(true);
                        cam5.SetActive(false);
                        cam = cam4.GetComponent<Camera>();
                        break;
                    case 4:
                        cam1.SetActive(false);
                        cam2.SetActive(false);
                        cam3.SetActive(false);
                        cam4.SetActive(false);
                        cam5.SetActive(true);
                        cam = cam5.GetComponent<Camera>();
                        break;
                    case 5:
                        cam1.SetActive(true);
                        cam2.SetActive(false);
                        cam3.SetActive(false);
                        cam4.SetActive(false);
                        cam5.SetActive(false);
                        cam = cam1.GetComponent<Camera>();
                        camN=0;
                        break;
                }
            }

            //Detecta cambios en la torreta
            if(Input.GetKeyDown("q")){
                turret = !turret;
                var tam = GetComponent<tamaulipas>();
                tam.enabled = !tam.enabled;

                cam1.SetActive(false);
                cam2.SetActive(false);
                cam3.SetActive(false);
                cam4.SetActive(false);
                cam5.SetActive(false);
                cam6.SetActive(true);
            }
            
            //Activa las benagalas
            if(Input.GetKey("v")){
                if(b){
                    Bengala.Play();
                    b = !b;
                }
            }else{
                if(!b){
                    b = !b;
                    Bengala.Stop();
                }
            }
            //Zoom 
            if(Input.GetKeyDown("e")){
                if(zoomActived == true){
                    
                    zoomActived = false;
                    cam.fieldOfView = 60;
                } else {
                    zoomActived = true;
                    cam.fieldOfView = 30;

                }
            } 
        }
    }

    void OnCollisionEnter(Collision col) {
        GUI.SetActive(true);
    }
}