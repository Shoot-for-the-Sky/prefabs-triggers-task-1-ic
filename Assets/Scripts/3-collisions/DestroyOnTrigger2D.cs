using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] int life;

    private void Damage()
    {
        life--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {

            if (this.gameObject.tag == "Player")
            {
                Damage();
                if (life == 0)
                {
                    Destroy(this.gameObject);
                    Application.Quit();


                }
                Destroy(other.gameObject);
            }
            else
            {
                
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
