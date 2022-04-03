using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float zSpeed;

    private float xSpeed;

    private float moveHorizontal;
    private float targetX;

    private Vector3 targetPos;
    private Vector3 currentPos;

    private int direction;
    
    #endregion

    #region Private Methods

    private void Move()
    {
        MoveTowards();
        Slide();
    }

    private void MoveTowards()
    {
        transform.Translate(Vector3.forward * zSpeed * Time.fixedDeltaTime);
    }

    private void Slide()
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
        transform.position = Vector3.MoveTowards(currentPos, targetPos, xSpeed * Time.fixedDeltaTime);
    }

    private void IncreaseSpeed()
    {
        if (zSpeed >= Settings.GameConstants.ZSpeedCap) return;
        zSpeed += LevelStateProvider.ZSpeedChange;
        xSpeed = zSpeed * Settings.GameConstants.SpeedRateZX;
        
    }

    /*private void FollowPressedPosition()
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

    }*/

    #endregion

    #region Unity Lifecycle

    private void OnEnable()
    {
        GroundTile.OnAnyTileExit += IncreaseSpeed;
    }

    private void Start()
    {
        xSpeed = zSpeed * Settings.GameConstants.SpeedRateZX;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = -1;
        }
        else if (SwipeManager.swipeLeft)
        {
            direction = -1;
        } 
        else if (SwipeManager.swipeRight)
        {
            direction = 1;
        }
    }

    void FixedUpdate()
    {
        Move();
        direction = 0;
        //Slide(Math.Sign(InputManager.XTouchScreeenCoord + Input.GetAxis("Horizontal")));

    }

    private void OnDisable()
    {
        GroundTile.OnAnyTileExit -= IncreaseSpeed;
    }

    #endregion
}