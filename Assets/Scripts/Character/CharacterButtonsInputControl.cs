using UnityEngine;

public class CharacterButtonsInputControl : CharacterControlBase
{
    private void Update()
    {
        bool isMoveLeft  = Input.GetButtonDown("MoveLeft");
        bool isMoveRight = Input.GetButtonDown("MoveRight");

        if (isMoveLeft)
            model.MoveLeft();

        if (isMoveRight)
            model.MoveRight();
    }
}