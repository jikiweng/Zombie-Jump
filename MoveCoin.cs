using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoin : MovePlatform
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (GameManager.instance.PlayerActive)
            base.Update();
        if (transform.localPostion.x = resetPosition)
        {
            //rigidBoby.detectCollisions = true;
            gameObject.SetActive(true);
        }
    }
}
