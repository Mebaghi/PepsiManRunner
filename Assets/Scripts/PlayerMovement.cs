using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Forward Movement")]
    public float forwardSpeed = 8f;

    [Header("Lane Settings")]
    public float laneDistance = 2.5f;
    public float laneChangeSpeed = 10f;

    // 0 = left, 1 = middle, 2 = right
    private int currentLane = 1;
    private float targetX;

    private bool isDead = false;

    void Start()
    {
        targetX = transform.position.x;
    }

    void Update()
    {
        if (isDead)
            return;

        // حرکت رو به جلو
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

        // حرکت نرم بین لاین‌ها
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, laneChangeSpeed * Time.deltaTime);
        transform.position = pos;
    }

    void ChangeLane(int direction)
    {
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
        targetX = (currentLane - 1) * laneDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isDead = true;
            GameManager.Instance.GameOver();
        }
    }
}
