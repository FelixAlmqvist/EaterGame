using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    enum Direction
    {
        RIGHT, LEFT
    }
    [SerializeField] private AnimationCurve _rotCurve;
    public float rotSpeed_;
    private float currentPos_;
    float current_;
    float currentTarget_;
    float target_;
    private Vector3 goalRotation_;
    private Vector3 startRotation_;

    void Start()
    {
        currentPos_ = transform.rotation.eulerAngles.y;
        target_ = currentPos_;
        startRotation_ = transform.rotation.eulerAngles;
        current_ = 0;
        currentTarget_ = 0;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) && currentPos_ == target_)
        {
            Spin(Direction.LEFT);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && currentPos_ == target_)
        {
            Spin(Direction.RIGHT);
        }


        if (currentPos_ != target_)
        {
            current_ = Mathf.MoveTowards(current_, currentTarget_, rotSpeed_ * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(startRotation_), Quaternion.Euler(goalRotation_), _rotCurve.Evaluate(current_));
            if (current_ == currentTarget_)
            {
                currentPos_ = target_;
                startRotation_ = goalRotation_;
            }
        }

    }

    void Spin(Direction dir)
    {
        current_ = 0;
        currentTarget_ = 1;
        if (dir == Direction.LEFT)
        {
            target_ += 90;

        }
        else
        {
            target_ -= 90;
        }
        goalRotation_ = new Vector3(transform.rotation.eulerAngles.x, target_, transform.rotation.eulerAngles.z);
    }
}
