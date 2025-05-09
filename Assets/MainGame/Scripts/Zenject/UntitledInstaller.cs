using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    private InputPlayer input;
    private GameController gameCon;
    [SerializeField] private Timer timer;

    public override void InstallBindings()
    {
        Application.targetFrameRate = 60;

        Container.Bind<InputPlayer>().FromInstance(input = new()).AsSingle();
        input.Enable();
        
        Container.Bind<GameController>().FromInstance(gameCon = new(timer)).AsSingle();
    }
    
    private void OnDestroy()
    {
        input.Disable();
    }
}