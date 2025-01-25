using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    public float StartPosition;
    public float EndPosition;
    public float MoveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x += MoveSpeed * Time.deltaTime;
        if (newPos.x >= EndPosition)
        {
            MoveSpeed = Mathf.Abs(MoveSpeed) * -1;
            newPos.x = EndPosition + MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (newPos.x <= StartPosition)
        {
            MoveSpeed = Mathf.Abs(MoveSpeed);
            newPos.x = StartPosition + MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.position = newPos;

    }
}
