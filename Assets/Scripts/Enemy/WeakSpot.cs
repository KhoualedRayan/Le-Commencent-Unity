using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(clip,transform.position);
            Destroy(objectToDestroy);
            PlayerMovement.instance.rb.AddForce(new Vector2(0f, PlayerMovement.instance.GetJumpForce()*1.5f), ForceMode2D.Impulse);
        }
    }
}
