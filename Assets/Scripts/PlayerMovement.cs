using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float Xspeed;
    [SerializeField] private float Zspeed;
    [SerializeField] private float distance;

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
            if (direction == 1 && targetX != distance) targetX += distance;
            if (direction == -1 && targetX != -distance) targetX -= distance;
        }

        targetPos = new Vector3(targetX, currentPos.y, currentPos.z);
        transform.position = Vector3.MoveTowards(currentPos, targetPos, Xspeed * Time.fixedDeltaTime);
    }

    #endregion

    #region Unity Lifecycle

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        MoveTowards();
        Slide(Math.Sign(moveHorizontal));
    }

    #endregion
}