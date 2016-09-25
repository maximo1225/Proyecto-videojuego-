using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Botones : MonoBehaviour {

    public Button boton;
    public Text botonTexto;
    private ControladorJ controladorJ;

    public void SetSpace()
    {
        botonTexto.text = controladorJ.GetTurnoString();
        boton.interactable = false;
        controladorJ.FinalizarTurno();
    }

    public void SetGameControllerReference(ControladorJ controlador)
    {
        controladorJ = controlador;
    }

}
