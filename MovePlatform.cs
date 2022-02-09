using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float objectSpeed = 3;
    [SerializeField] private float resetPosition = 50.0f;
    [SerializeField] private float startPosition = -79.0f;

    public float ResetPosition { get { return resetPosition; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            transform.Translate(Vector3.right * objectSpeed * Time.deltaTime, Space.World);

            if (transform.localPosition.x >= resetPosition)
            {
                Vector3 newPos = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    }
}
