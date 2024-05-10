using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class LoadSpecificScene : MonoBehaviour
{
    public string SceneName;
    private Animator fadeSystem;
    public AudioClip clip;
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }
    }
    private IEnumerator loadNextScene()
    {
        AudioManager.instance.PlayClipAt(clip, transform.position);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneName);
    }
}
