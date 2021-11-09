using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float Xspeed;
    [SerializeField] private float Zspeed;
    [Space]
    [Header("Speed Waypoints")]
    [SerializeField] private float speedWP1;
    [SerializeField] private float speedWP2;
    [Header("Speed change")]
    [SerializeField] private float XSpeedChange1;
    [SerializeField] private float XSpeedChange2;
    [SerializeField] private float XSpeedChange3;
    [SerializeField] private float ZSpeedChange1;
    [SerializeField] private float ZSpeedChange2;
    [SerializeField] private float ZSpeedChange3;

    private float moveHorizontal;
    private float targetX;

    private Vector3 targetPos;
    private Vector3 currentPos;
    #endregion

    #region Private Methods

    private void MoveTowards()
    {
        transform.Translate(Vector3.forward * Zspeed * Time.fixedDeltaTime);
    }

    private void Slide(int direction)
    {
        currentPos = transform.position;

        //if object is not sliding and button is pressed
        if (currentPos.x == targetX && direction != 0)
        {
            var distance = Settings.GameConstants.PlayerSlideDistance;
            if (direction == 1 && targetX != distance) targetX += distance;
            if (direction == -1 && targetX != -distance) targetX -= distance;
        }

        targetPos = new Vector3(targetX, currentPos.y, currentPos.z);
        transform.position = Vector3.MoveTowards(currentPos, targetPos, Xspeed * Time.fixedDeltaTime);
    }

    private void IncreaseSpeed()
    {
        if (Zspeed < speedWP1)
        {
            Zspeed += ZSpeedChange1;
            Xspeed += XSpeedChange1;
        } else if (speedWP1 <= Zspeed && Zspeed < speedWP2)
        {
            Zspeed += ZSpeedChange2;
            Xspeed += XSpeedChange2;
            
        }
        else
        {
            Zspeed += ZSpeedChange3;
            Xspeed += XSpeedChange3;
        }
    }

    private void FollowPressedPosition()
    {
        currentPos = transform.position;
        var direction = InputManager.TouchCoords.x - transform.position.x;
        transform.Translate(Vector3.right * direction * Xspeed * Time.fixedDeltaTime);
        if (transform.position.x > Settings.GameConstants.PlayerSlideDistance ||
            transform.position.x < -Settings.GameConstants.PlayerSlideDistance)
        {
            var fixedPos = new Vector3(Settings.GameConstants.PlayerSlideDistance * Math.Sign(transform.position.x),
                transform.position.y, transform.position.z);
            transform.position = fixedPos;
        }

    }

    #endregion

    #region Unity Lifecycle

    private void OnEnable()
    {
        GroundTile.OnAnyTileExit += IncreaseSpeed;
    }

    void FixedUpdate()
    {
        MoveTowards();
        //FollowPressedPosition();
        Slide(Math.Sign(InputManager.XTouchScreeenCoord));
    }

    private void OnDisable()
    {
        GroundTile.OnAnyTileExit -= IncreaseSpeed;
    }

    #endregion
}