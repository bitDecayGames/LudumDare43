using UnityEngine;

public partial class WomanAnimationController
{
    private string _animationToPlay;
    
    public void HandleFreeMovement()
    {
        if (IsMovingLeft())
        {
            LastDirectionWasLeft = true;
            _animationToPlay = "left_up";
        }
        else if (IsMovingRight())
        {
            LastDirectionWasLeft = false;
            _animationToPlay = "right_up";
        }
        else
        {
            if (LastDirectionWasLeft)
            {
                _animationToPlay = "still_left_up";
            } 
            else
            {
                _animationToPlay = "still_right_up";
            }
        }
        Animator.Play(_animationToPlay);
    }
}