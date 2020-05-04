using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public GameObject BallPrefab;
    public float BallSpeed;
    GameObject BallInstance;
    Vector3 mouseStart;
    Vector3 mouseEnd;

    float minMove = 15f;
    float zDepth = 25f;

    // Start is called before the first frame update
    void Start()
    {
        CreateBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseEnd = Input.mousePosition;
            if(Vector3.Distance(mouseEnd, mouseStart) > minMove)
            {
                // shoot ball
                Vector3 hitPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDepth);
                hitPos = Camera.main.ScreenToWorldPoint(hitPos);
                BallInstance.transform.LookAt(hitPos);
                BallInstance.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * BallSpeed, ForceMode.Impulse);
                Invoke("CreateBall", 2f);
            }
        }
    }

    void CreateBall()
    {
        BallInstance = Instantiate (BallPrefab, BallPrefab.transform.position, Quaternion.identity) as GameObject;
    }
}
