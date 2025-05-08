using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Application.targetFrameRate = 60;
        Container.Bind<InputPlayer>().FromNew().AsSingle();
        input.Enable();
    }
    
    private void OnDisable()
    {
        input.Disable();
    }
}