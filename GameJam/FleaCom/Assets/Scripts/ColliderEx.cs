using UnityEngine;

public class ColliderEx : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.gameObject.name + "entered");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(this.gameObject.name + "exit");
    }
}
