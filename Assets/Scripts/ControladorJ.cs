using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorJ : MonoBehaviour {

    public Text[] listaBotones;
    private string JugadorT;//variable mantendra una X u O dependiendo el turno del jugador
    public GameObject mensaje;
    public Text TextoMensaje;
    public GameObject botonReiniciar;
    public GameObject P1;
    public GameObject P2;
    private int movNum;
    
    public bool turno;
    public float delay;
    private int value;

    void Start()
    {
        //al iniciar el juego se desactiva el boton de reiniciar
        botonReiniciar.SetActive(false);
        CambiarEstadoJugador(true, false);
        turno = true;
        
    }

	void Update()
	{
		if( turno == false)
		{
			delay += delay * Time.deltaTime;
			if(delay >= 100)
			{
				value = Random.Range(0, 8);
				if(listaBotones[value].GetComponentInParent<Button>().interactable == true)
				{
					listaBotones[value].text = GetTurnoString();
					listaBotones[value].GetComponentInParent<Button>().interactable = false;
					FinalizarTurno();
				}
			}
		}
	}
	
    void Awake()
    {
        mensaje.SetActive(false);
        ReferenciaBotones();
        JugadorT = "X";
        movNum = 0;
    }

    void ReferenciaBotones()
    {
        for(int i = 0; i < listaBotones.Length; i++)
        {
            listaBotones[i].GetComponentInParent<Botones>().SetGameControllerReference(this);
        }
    }

    //retorna en el boton el valor actual que tenga el JugadorT
    public string GetTurnoString()
    {
        return JugadorT;
    }

    //para manejar el estado del jugador
    private void CambiarEstadoJugador(bool p1, bool p2)
    {
        P1.GetComponentInParent<Button>().interactable = p1;
        P2.GetComponentInParent<Button>().interactable = p2;
    }

    //verifica si uno de los jugadores ha gana para finalizar el juego
    public void FinalizarTurno()
    {
        movNum++;
        if (listaBotones[0].text == JugadorT && listaBotones[1].text == JugadorT
            && listaBotones[2].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[3].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[5].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[6].text == JugadorT && listaBotones[7].text == JugadorT
            && listaBotones[8].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[0].text == JugadorT && listaBotones[3].text == JugadorT
            && listaBotones[6].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[1].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[7].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[2].text == JugadorT && listaBotones[5].text == JugadorT
            && listaBotones[8].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[0].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[8].text == JugadorT)
        {
            GameOver();
        }
        else if (listaBotones[2].text == JugadorT && listaBotones[4].text == JugadorT
            && listaBotones[6].text == JugadorT)
        {
            GameOver();
        }
        //lanza el mensaje cuando los jugadores quedan empate.
        else if (movNum >= 9)
        {
            GameOver();
        }
        else
        {
            Cambiardeturno();
        }
    }

    
    void Cambiardeturno()
    {
        JugadorT = (JugadorT == "X") ? "O" : "X";
        if(JugadorT == "X")
        {
			  turno = true;
           CambiarEstadoJugador(true, false);
           delay = 10;
        }
        else
        {
			  turno = false;
           CambiarEstadoJugador(false, true);
        }

    }

    public void Reiniciar()
    {
        JugadorT = "X";
        movNum = 0;
        mensaje.SetActive(false);

        for (int i = 0; i < listaBotones.Length; i++)
        {
            listaBotones[i].GetComponentInParent<Button>().interactable = true;
            listaBotones[i].text = "";
        }
        botonReiniciar.SetActive(false);
        CambiarEstadoJugador(true, false);
    }



    //desactiva todos los botones del juego para finalizarlo
    void GameOver()
    {
        for(int i = 0; i < listaBotones.Length; i++)
        {
            listaBotones[i].GetComponentInParent<Button>().interactable = false;
            
        }

        mensaje.SetActive(true);
        string Jugador = (JugadorT == "X") ? "P1" : "Computador";
        TextoMensaje.text = (movNum >= 9) ?  "Empate!" :  "Ganó " + Jugador;

        botonReiniciar.SetActive(true);
    }

	public void VolverMenu()
	{
		Application.LoadLevel(0);
	}
   
}
