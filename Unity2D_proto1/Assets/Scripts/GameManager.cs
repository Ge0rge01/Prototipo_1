using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Posibles estados del juego
public enum GameState
{
    menu,
    InGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    //Variable que referencia al propio Game Manager
    //Patrón de diseño Singleton
    public static GameManager sharedInstance;

    //Variable para saber en que estado del juego nos encontramos en cada momento
    public GameState currentGameState = GameState.menu;

    public void Awake()
    {
        sharedInstance = this;
    }

    public void Start()
    {
     //   BackToMenu();
        StartGame();
    }

    public void Update()
    {
        //En el caso de que quiera que yo el juego empiece cuando el usuario pulse una tecla
        if(Input.GetKeyDown(KeyCode.S) && currentGameState != GameState.InGame)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {          
            StartGame();
        }

        //Forma correcta para mando y teclado
        //Se le debe indicar a unity cual es la letra start
        //Ir a Edit/Project Settings y dentro Input.  Aumentar el Size y configurar el start y positive button
        //  if(Input.GetButtonDown("start"))
        //{
        //  StartGame();
        //}
    }


    //Metodo encargado de iniciar el juego
    public void StartGame()
    {
        SetGameState(GameState.InGame);
        PlayerController.sharedInstance.StartGame();

    }

    //Metodo que volverá al menu principal del juego
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    //Metodo que se llamara cuando el jugador muera
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    //Metodo encargado de cambiar el estado del juego
    void SetGameState(GameState newGameState)
    {

        if(newGameState == GameState.menu)
        {
            //Hay que preparar la escena de unity para el menu
        }

        if (newGameState == GameState.InGame)
        {
            //Hay que preparar la escena de unity para jugar
        }

        if (newGameState == GameState.gameOver)
        {
            //Hay que preparar la escena de unity para el gameOver
        }

        //Asignamos al estado de juego actual el que nos ha llegado por parametro
        this.currentGameState = newGameState;
    }
}
