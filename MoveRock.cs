using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRock : MovePlatform
{
    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
    [SerializeField] float rockSpeed=5;
    [SerializeField] float rotateSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(bottomPosition));
    }

    // Update is called once per frame
    protected override void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
        if (GameManager.instance.PlayerActive)
            base.Update();        
    }

    IEnumerator Move(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 2f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction *rockSpeed* Time.deltaTime;

            yield return null;
        }

        //print("Reached the target");
        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;
        StartCoroutine(Move(newTarget));
    }

    public void resetPosition()
    {
        Vector3 newPos = transform.localPosition + 10 * Vector3.left;
        transform.position=newPos;
    }
}
