using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform Target;
    public float speed;

    private Vector3 start, end;
    // Start is called before the first frame update
    void Start()
    {
        if(Target != null)
        {
            Target.parent = null;
            start = transform.position;
            end = Target.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,Target.position, fixedSpeed);
        }
        if (transform.position == Target.position)
        {
            Target.position = (Target.position == start) ? end : start;
        }
    }
}
