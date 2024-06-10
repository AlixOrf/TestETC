using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCasting : MonoBehaviour
{
    public float m_MaxDistance = 2.0f;
    RaycastHit m_Hit;

    void FixedUpdate()
    {
        if (Physics.BoxCast(transform.position, transform.localScale * 0.5f, transform.forward, out m_Hit, transform.rotation, m_MaxDistance))
        {
            Debug.Log("Hit : " + m_Hit.collider.name);
            transform.GetComponent<Player>().myTarget = m_Hit.transform.gameObject;
        }
        else
        {
            if (transform.GetComponent<Player>().myTarget != null)
            {
                transform.GetComponent<Player>().myTarget = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (Physics.BoxCast(transform.position, transform.localScale * 0.5f, transform.forward, out m_Hit, transform.rotation, m_MaxDistance))
        {
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance, transform.localScale);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance, transform.localScale);
        }
    }
}

