using UnityEngine;

public class GameController : MonoBehaviour
{
    private Timer timer;

    public GameController(Timer t)
    {
        timer = t;
    }

    public void LouseGame(){
        timer.StopTime();
    }

}
