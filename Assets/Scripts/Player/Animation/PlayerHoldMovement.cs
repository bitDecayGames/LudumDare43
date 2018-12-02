using UnityEngine;

public partial class PlayerAnimationController
{
    public void HandleHoldAnimation()
    {
        if (Facing.IsFacingLeft())
        {
            if (IsMovingLeft())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay ="moving_push_left_upper";
                }
                else
                {
                    _animationToPlay ="moving_push_left_lower";
                }
            }
            else if (IsMovingRight())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay ="moving_pull_right_upper";
                }
                else
                {
                    _animationToPlay ="moving_pull_right_lower";
                }
            }
            else
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay ="hold_still_left_upper";
                }
                else
                {
                    _animationToPlay ="hold_still_left_lower";
                }
            }
        } 
        else if (Facing.IsFacingRight())
        {
            if (IsMovingRight())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay ="moving_push_right_upper";
                }
                else
                {
                    _animationToPlay ="moving_push_right_lower";
                }
            }
            else if (IsMovingLeft())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay ="moving_pull_left_upper";
                }
                else
                {
                    _animationToPlay ="moving_pull_left_lower";
                }
            }
            else
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay ="hold_still_right_upper";
                }
                else
                {
                    _animationToPlay ="hold_still_right_lower";
                }
            }
        }
        else if (Facing.IsFacingUp())
        {
            if (IsMovingUp())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay ="moving_push_up_righter";
                }
                else
                {
                    _animationToPlay ="moving_push_up_lefter";
                }
            }
            else if (IsMovingDown())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay ="moving_pull_down_righter";
                }
                else
                {
                    _animationToPlay ="moving_pull_down_lefter";
                }
            }
            else
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay ="hold_still_up_righter";
                }
                else
                {
                    _animationToPlay ="hold_still_up_lefter";
                }
            }
        }
        else if (Facing.IsFacingDown())
        {
            if (IsMovingDown())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay ="moving_push_down_righter";
                }
                else
                {
                    _animationToPlay ="moving_push_down_lefter";
                }
            }
            else if (IsMovingUp())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay ="moving_pull_up_righter";
                }
                else
                {
                    _animationToPlay ="moving_pull_up_lefter";
                }
            }
            else
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay ="hold_still_down_righter";
                }
                else
                {
                    _animationToPlay ="hold_still_down_lefter";
                }
            }
        }
        Debug.Log("Playing animation: " + _animationToPlay);
        Animator.Play(_animationToPlay);
    }
}