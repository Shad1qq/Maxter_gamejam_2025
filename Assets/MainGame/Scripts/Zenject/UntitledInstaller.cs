using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    private InputPlayer input;

    public override void InstallBindings()
    {
        Application.targetFrameRate = 60;
        Container.Bind<InputPlayer>().FromInstance(input = new()).AsSingle();
        input.Enable();
    }
    
    private void OnDisable()
    {
        input.Disable();
    }
}