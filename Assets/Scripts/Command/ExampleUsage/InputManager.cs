using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button undoButton;
    [SerializeField] private Button redoButton;

    [Header("References")]
    [SerializeField] private PlayerMovement player;

    private CommandInvoker commandInvoker;

    private void Awake()
    {
        //Initialize the CommandInvoker.
        commandInvoker = new CommandInvoker();

        upButton.onClick.AddListener(OnUpButtonClick);
        downButton.onClick.AddListener(OnDownButtonClick);
        leftButton.onClick.AddListener(OnLeftButtonClick);
        rightButton.onClick.AddListener(OnRightButtonClick);
        undoButton.onClick.AddListener(OnUndoButtonClick);
        redoButton.onClick.AddListener(OnRedoButtonClick);
    }

    //If the player is not empty, create a new MoveCommand instance and execute the command of it.
    //Also, make buttons non-interactive for a while.
    private void RunPlayerCommand(PlayerMovement player, Vector3 movement)
    {
        if (player == null) { return; }

        ICommand command = new MoveCommand(player, movement);
        commandInvoker.ExecuteCommand(command);

        StartCoroutine(ButtonManager.Instance.OnAnyButtonClick());
    }

    //When the Left Button is pressed, call RunPlayerCommand function.
    private void OnLeftButtonClick()
    {
        RunPlayerCommand(player, Vector3.right);
    }

    //When the Right Button is pressed, call RunPlayerCommand function.
    private void OnRightButtonClick()
    {
        RunPlayerCommand(player, Vector3.left);
    }

    //When the Up Button is pressed, call RunPlayerCommand function.
    private void OnUpButtonClick()
    {
        RunPlayerCommand(player, Vector3.back);
    }

    //When the Down Button is pressed, call RunPlayerCommand function.
    private void OnDownButtonClick()
    {
        RunPlayerCommand(player, Vector3.forward);
    }

    //When the Undo Button is pressed, call UndoCommand function and make buttons non-interactive for a while.
    private void OnUndoButtonClick()
    {
        commandInvoker.UndoCommand();
        StartCoroutine(ButtonManager.Instance.OnAnyButtonClick());
    }

    //When the Redo Button is pressed, call RedoCommand function and make buttons non-interactive for a while.
    private void OnRedoButtonClick()
    {
        commandInvoker.RedoCommand();
        StartCoroutine(ButtonManager.Instance.OnAnyButtonClick());
    }

}
