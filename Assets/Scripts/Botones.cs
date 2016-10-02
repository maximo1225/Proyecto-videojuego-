using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Botones : MonoBehaviour {

    public Button boton;
    public Text botonTexto;
    private ControladorJ controladorJ;

    public void SetSpace()
    {
		if(controladorJ.delay > 0)
		{
			  botonTexto.text = controladorJ.GetTurnoString();
			  boton.interactable = false;
			  controladorJ.FinalizarTurno();
		}
		else
		{
			botonTexto.text = controladorJ.GetTurnoString();
			boton.interactable = false;
			controladorJ.FinalizarTurno();
			controladorJ.delay = 0;
		}
    }

	 public void desactivarBotonesComputador()
	 {
		 
	 }
    public void SetGameControllerReference(ControladorJ controlador)
    {
        controladorJ = controlador;
    }

}
