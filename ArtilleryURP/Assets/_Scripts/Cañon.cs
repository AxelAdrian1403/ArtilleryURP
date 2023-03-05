using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    [SerializeField] private GameObject balaPrefab;
    private GameObject puntaCañon;
    private float rotacion;

    private void Start()
    {
        puntaCañon = transform.Find("PuntaCañon").gameObject;
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

        if(Input.GetKeyDown(KeyCode.Space) && AdministradorJuego.DisparosPorJuego >= 1)
        {
            GameObject temp = Instantiate(balaPrefab, puntaCañon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;
            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.VelocidadBala;
            AdministradorJuego.DisparosPorJuego--;
        }
    }
}
