using Zenject;

//This installer binds specific components (ClickableAudio, ClickableUI) 
//Found in the scene and a non-MonoBehaviour class (NonMonoExample) as single instances
public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ClickableAudio>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ClickableUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<NonMonoExample>().AsSingle();
    }
}
