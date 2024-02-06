//To manage our actions in a "Command Object".
public interface ICommand
{
    void Execute();
    void Undo();
}
