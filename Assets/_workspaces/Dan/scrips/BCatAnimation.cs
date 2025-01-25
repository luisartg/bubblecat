using UnityEngine;

public class BCatAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animControl;
    private AnimStates currentAnimState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animControl = GetComponent<Animator>();
        currentAnimState = AnimStates.Idle;
    }

    public void GoLeft()
    {
        if (currentAnimState != AnimStates.Left)
        {
            this.transform.rotation = Quaternion.Euler(0, -180, 0);
            if (currentAnimState != AnimStates.Right && currentAnimState != AnimStates.Left)
            {
                animControl.SetTrigger("Sideways");
            }
            currentAnimState = AnimStates.Left;
        }
    }

    public void GoRight()
    {
        if (currentAnimState != AnimStates.Right)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (currentAnimState != AnimStates.Right && currentAnimState != AnimStates.Left)
            {
                animControl.SetTrigger("Sideways");
            }
            currentAnimState = AnimStates.Right;
        }
    }

    public void Idle()
    {
        if (currentAnimState != AnimStates.Idle)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            animControl.SetTrigger("Idle");
            currentAnimState = AnimStates.Idle;
        }
    }

    public void GoDown()
    {
        if (currentAnimState != AnimStates.Down)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            //if (currentAnimState == AnimStates.Left || currentAnimState == AnimStates.Right)
            //{
            //    animControl.SetTrigger("Idle");
            //}
            animControl.SetTrigger("Down");
            currentAnimState = AnimStates.Down;
        }
    }

    enum AnimStates
    {
        Left,
        Right,
        Down,
        Idle
    }
}
