using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple Command Object implementing ICommand
public class MoveCommand : ICommand
{
    private PlayerMovement player;
    private Vector3 movement;

    //Constructor
    public MoveCommand(PlayerMovement player, Vector3 movement)
    {
        this.player = player;
        this.movement = movement;
    }

    //Execute logic. For managing Player Movement.
    public void Execute()
    {
        player.HandleMovement(movement);
    }

    //Undo logic. For managing the opposite of Execute method.
    public void Undo()
    {
        player.HandleMovement(-movement);
    }
}
