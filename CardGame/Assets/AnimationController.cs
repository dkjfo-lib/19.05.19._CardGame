using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // refs
    public Animator animator;
    public RectTransform cardTransform;

    // props
    [Range(0.1f, 0.5f)] public float sideWeight = 0.4f;
    [Range(0.1f, 1f)] public float cardRotation = 1;

    // stats
    public bool left = false;
    public bool idle = false;
    public bool right = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetUpMouseAlignment();
        float mouseValue = 0.5f - GetMousePositionPercents();
        cardTransform.rotation = new Quaternion(0, 0, cardRotation * mouseValue, 1);
    }

    float GetMousePositionPercents()
    {
        float value = Input.mousePosition.x / Screen.width;
        return value < 0 ? 0 : value > 1 ? 1 : value;
    }

    void SetUpMouseAlignment()
    {
        float value = GetMousePositionPercents();
        bool newLeft = value < sideWeight;
        bool newRight = 1 - value < sideWeight;
        bool newIdle = !newLeft && !newRight;
        if (left != newLeft)
        {
            if (newLeft)
            {
                animator.SetTrigger("go_LeanL");
            }
            left = newLeft;
        }
        if (right != newRight)
        {
            if (newRight)
            {
                animator.SetTrigger("go_LeanR");
            }
            right = newRight;
        }
        if (idle != newIdle)
        {
            if (newIdle)
            {
                animator.SetTrigger("go_Idle");
            }
            idle = newIdle;
        }
    }
}
