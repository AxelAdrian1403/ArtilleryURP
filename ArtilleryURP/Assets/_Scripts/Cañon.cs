using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public static bool bloqueado;

    public AudioClip clipDisparo;
    private GameObject sonidoDisparo;
    private AudioSource sourceDisparo;

    [SerializeField] private GameObject balaPrefab;
    public GameObject particulasDisparo;
    private GameObject puntaCañon;
    private float rotacion;


    private void Start()
    {
        puntaCañon = transform.Find("PuntaCañon").gameObject;
        sonidoDisparo = GameObject.Find("SonidoDisparo");
        sourceDisparo = sonidoDisparo.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.VelocidadRotacion;

        if(rotacion >= 0 && rotacion <= 90)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);
        }

        if(rotacion > 90)
        {
            rotacion = 90;
        }

        if(rotacion < 0)
        {
            rotacion = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space) && AdministradorJuego.DisparosPorJuego >= 1 && !bloqueado)
        {
            GameObject temp = Instantiate(balaPrefab, puntaCañon.transform.position, transform.rotation);
            
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
            GameObject particulas = Instantiate(particulasDisparo, puntaCañon.transform.position, Quaternion.Euler(direccionParticulas), transform);
            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
            AdministradorJuego.DisparosPorJuego--;
            sourceDisparo.Play();
            //PlayOneShot(clip) te hace override de la propiedad del clip de audio
            bloqueado = true;
        }
    }
}
