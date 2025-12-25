using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Forward Movement")]
    public float forwardSpeed = 8f;

    [Header("Lane Settings")]
    public float laneDistance = 2.5f;
    public float laneChangeSpeed = 10f;

    private int currentLane = 1; // 0 = left, 1 = middle, 2 = right
    private float targetX;

    void Start()
    {
        targetX = transform.position.x;
    }

    void Update()
    {
        // حرکت خودکار رو به جلو
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // ورودی چپ و راست
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLane(1);
        }

        // حرکت نرم به سمت لاین هدف
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, laneChangeSpeed * Time.deltaTime);
        transform.position = pos;
    }

    void ChangeLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
        targetX = (currentLane - 1) * laneDistance;
    }
}
