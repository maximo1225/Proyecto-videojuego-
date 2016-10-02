using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menu : MonoBehaviour {
	
	public Canvas menuSalida;
	public Button jugadorComputadora;
	public Button jugarDosJugadores;
	public Button salir;
	
	// Use this for initialization
	void Start () 
	{
		menuSalida = menuSalida.GetComponent<Canvas>();
		jugadorComputadora = jugadorComputadora.GetComponent<Button>();
		jugarDosJugadores = jugarDosJugadores.GetComponent<Button>();
		salir = salir.GetComponent<Button>();
		
		menuSalida.enabled = false;
	}
	
	public void ExitPress()
	{
		menuSalida.enabled = true;
		jugadorComputadora.enabled = false;
		jugarDosJugadores.enabled = false;
		salir.enabled = false;
	}
	
	public void NoPress()
	{
		menuSalida.enabled = false;
		jugadorComputadora.enabled = true;
		jugarDosJugadores.enabled = true;
		salir.enabled = true;
	}
	
	public void StartLevelComputer()
	{
		Application.LoadLevel(1);
	}
	
	public void StartLevelPlayers()
	{
		Application.LoadLevel(2);
	}
	
	public void ExitGame()
	{
		Application.Quit();
	}
}
