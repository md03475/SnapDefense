using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class EnemyMissileExplosion : MonoBehaviour
{
    public GameObject missile;
    public float radius = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 explosionPosition = missile.transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, radius);
        foreach (Collider2D collider in colliders)
        {
            Buildings b = collider.GetComponent<Buildings>();
            if (b!=null)
            {
                b.takeDamage();
            }

            MissileBatteries m = collider.GetComponent<MissileBatteries>();
            if (m != null)
            {
                m.takeDamage();
            }
        }
    }
}
