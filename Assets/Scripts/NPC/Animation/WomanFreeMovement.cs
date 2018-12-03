using UnityEngine;

public partial class WomanAnimationController
{
    private string _animationToPlay;
    
    public void HandleFreeMovement()
    {
        if (IsMovingLeft())
        {
            if (IsAboveCenterPointOnMap())
            {
                _animationToPlay = "left_up";
            }
            else
            {
                _animationToPlay = "left_down";
            }
        }
        else if (IsMovingRight())
        {
            if (IsAboveCenterPointOnMap())
            {
                _animationToPlay = "right_up";
            }
            else
            {
                _animationToPlay = "right_down";
            }
        }
        else if (IsMovingUp())
        {
            if (IsToTheRightOfCenterPointOnMap())
            {
                _animationToPlay = "up_right";
            }
            else
            {
                _animationToPlay = "up_left";
            }
        }
        else if (IsMovingDown())
        {
            if (IsToTheRightOfCenterPointOnMap())
            {
                _animationToPlay = "down_right";
            }
            else
            {
                _animationToPlay = "down_left";
            }
        }
        else
        {
            if (Facing.IsFacingLeft())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay = "still_left_up";
                }
                else
                {
                    _animationToPlay = "still_left_down";
                }
            } 
            else if (Facing.IsFacingRight())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay = "still_right_up";
                }
                else
                {
                    _animationToPlay = "still_right_down";
                }
            }
            else if (Facing.IsFacingUp())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay = "still_up_right";
                }
                else
                {
                    _animationToPlay = "still_up_left";
                }
            }
            else if (Facing.IsFacingDown())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay = "still_down_right";
                }
                else
                {
                    _animationToPlay = "still_down_left";
                }
            }
        }
        Animator.Play(_animationToPlay);
    }
}