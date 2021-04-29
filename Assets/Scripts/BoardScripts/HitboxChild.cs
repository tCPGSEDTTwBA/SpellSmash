using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxChild : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a collision is detected, 'disable' that direction
        transform.parent.GetComponent<HitboxHandler>().ReportCollision(this.name, false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If a block leaves the collision, 'enabled' that direction
        transform.parent.GetComponent<HitboxHandler>().ReportCollision(this.name, true);
    }
}
