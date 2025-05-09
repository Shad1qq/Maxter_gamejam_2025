using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    private InputPlayer input;
    private GameController gameCon;
    [SerializeField] private Timer timer;

    public override void InstallBindings()
    {
        gameCon = new(timer);
        Container.Bind<GameController>().FromInstance(gameCon).AsSingle();

        Application.targetFrameRate = 60;
        Container.Bind<InputPlayer>().FromInstance(input = new()).AsSingle();
        input.Enable();
    }
    
    private void OnDisable()
    {
        input.Disable();
    }}