using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float timeOffSet;
    [SerializeField]
    private Vector2 posOffSet;

    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float topLimit;
    [SerializeField]
    private float bottonLimit;

    void Start()
    {

    }


    void FixedUpdate()
    {
        getposition();
    }

    void getposition()
    {
        //Current camera position
        Vector3 startPos = transform.position;
        //Current Player position
        Vector3 endPos = Player.transform.position;
        endPos.x += posOffSet.x;
        endPos.y += posOffSet.y;
        endPos.z = -10;


        transform.position = Vector3.Lerp(startPos, endPos, timeOffSet * Time.deltaTime);

        //Limits player position
        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottonLimit, topLimit),
                transform.position.z
            );

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, bottonLimit), new Vector2(rightLimit, bottonLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottonLimit), new Vector2(leftLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottonLimit), new Vector2(rightLimit, topLimit));

    }

}
