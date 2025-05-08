using Zenject;

public class UntitledInstaller : MonoInstaller
{
    private InputPlayer input;

    public override void InstallBindings()
    {
        Container.Bind<InputPlayer>().FromInstance(input = new()).AsSingle();
    }
}