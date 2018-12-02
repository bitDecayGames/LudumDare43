using UnityEngine;

public partial class PlayerAnimationController
{
    private string _animationToPlay;
    
    public void HandleFreeMovement()
    {
        if (IsMovingLeft())
        {
            if (IsAboveCenterPointOnMap())
            {
                _animationToPlay = "moving_left_upper";
            }
            else
            {
                _animationToPlay = "moving_left_lower";
            }
        }
        else if (IsMovingRight())
        {
            if (IsAboveCenterPointOnMap())
            {
                _animationToPlay = "moving_right_upper";
            }
            else
            {
                _animationToPlay = "moving_right_lower";
            }
        }
        else if (IsMovingUp())
        {
            if (IsToTheRightOfCenterPointOnMap())
            {
                _animationToPlay = "moving_up_righter";
            }
            else
            {
                _animationToPlay = "moving_up_lefter";
            }
        }
        else if (IsMovingDown())
        {
            if (IsToTheRightOfCenterPointOnMap())
            {
                _animationToPlay = "moving_down_righter";
            }
            else
            {
                _animationToPlay = "moving_down_lefter";
            }
        }
        else
        {
            if (Facing.IsFacingLeft())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay = "still_left_upper";
                }
                else
                {
                    _animationToPlay = "still_left_lower";
                }
            } 
            else if (Facing.IsFacingRight())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay = "still_right_upper";
                }
                else
                {
                    _animationToPlay = "still_right_lower";
                }
            }
            else if (Facing.IsFacingUp())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay = "still_up_righter";
                }
                else
                {
                    _animationToPlay = "still_up_lefter";
                }
            }
            else if (Facing.IsFacingDown())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay = "still_down_righter";
                }
                else
                {
                    _animationToPlay = "still_down_lefter";
                }
            }
        }
        Animator.Play(_animationToPlay);
    }
}