using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego singletonAdministradorJuego;
    private static int velocidadBala = 30;
    private static int disparosPorJuego = 10;
    private static float velocidadRotacion = 1;

    private void Awake()
    {
        if(singletonAdministradorJuego == null)
        {
            singletonAdministradorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }

   public static int VelocidadBala
    {
        get => velocidadBala;
        set => velocidadBala = value;
    }

    public static int DisparosPorJuego
    {
        get => disparosPorJuego;
        set => disparosPorJuego = value;
    }

    public static float VelocidadRotacion
    {
        get => velocidadRotacion;
        set => velocidadRotacion = value;
    }
}
