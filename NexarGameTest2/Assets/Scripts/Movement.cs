using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public float duration = 5f;

    private float t = 0f;

    Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }

    private void Update()
    {
        t += Time.deltaTime / duration;
        if (t > 1f)
        {
            t = 1f;
            animator.SetBool("isWalking", false);
        }

        Vector3 position = CalculateBezierPoint(t, pointA.position, pointB.position, pointC.position, pointD.position);
        transform.LookAt(position);
        transform.position = position;
    }

    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = Mathf.Pow(t, 2);
        float uu = Mathf.Pow(u, 2);
        float uuu = Mathf.Pow(u, 3);
        float ttt = Mathf.Pow(t, 3);

        Vector3 p = uuu * p0 + 3 * uu * t * p1 + 3 * u * tt * p2 + ttt * p3; // (1-t)^3 * P0 + 3 * (1-t)^2 * t * P1 + 3 * (1-t) * t^2 * P2 + t^3 * P3

        return p;
    }
}
