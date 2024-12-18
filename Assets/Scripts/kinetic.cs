using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;

public class kinetic : MonoBehaviour
{
    public float speed = 50f;
    public float rotateSpeed = 15f;
    public Transform[] circle;
    public Transform[] arm;

    public Transform target;
    public float minAngle;
    public float maxAngle;
    public float current;

    void Start()
    {
        minAngle = -10;
        maxAngle = 10;


    }
    void Update()
    {

        Circle(circle);
        Arim(arm, target);

    }



    void Circle(Transform[] circle)
    {
        circle[0].Rotate(0f, 0f, speed * Time.deltaTime);
        circle[1].Rotate(speed * Time.deltaTime, 0f, 0f);
        float y = Mathf.Sin(Time.time * speed);
        circle[2].rotation = Quaternion.Euler(new Vector3(y * 180, 0f, 0f));

    }
    void Arim(Transform[] arm, Transform target)
    {
        float rotationstep = rotateSpeed * Time.deltaTime;
        current += rotationstep;
        if (current < minAngle || current > maxAngle)
        {
            rotateSpeed = -rotateSpeed;
        }
        if (arm != null)
        {

            for (int i = 0; i < arm.Length; i++)
            {

                if (i % 2 == 0)
                {
                    arm[i].RotateAround(target.position, Vector3.forward, rotateSpeed * Time.deltaTime);
                }
                if (i % 2 == 1)
                {
                    arm[i].RotateAround(target.position, Vector3.back, rotateSpeed * Time.deltaTime);
                }

            }
        }

    }
}


