using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    Player player;
    Rigidbody Rb;

    void Start()
    {
        player = Player.Instance;
        Rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        player.GrabbedItem.position = transform.position;
        //transform.SetParent(player.transform);
        Rb.useGravity = false;
    }

    void OnMouseDrag()
    {
        Rb.velocity = (player.GrabbedItem.position - transform.position) * 5f;
        //transform.position=Vector3.Lerp(transform.position,player.GrabbedItem.position,Time.deltaTime*5f);
    }

    void OnMouseUp()
    {
        Rb.useGravity = true;
    }
}