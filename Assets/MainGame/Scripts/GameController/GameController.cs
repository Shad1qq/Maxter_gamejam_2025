using UnityEngine;

public class GameController
{
    private Timer timer;

    public GameController(Timer t)
    {
        timer = t;
        StartGame();
    }

    private void StartGame(){
        timer.StartTimer();
    }

    public void LouseGame(){
        timer.StopTime();
    }

}
