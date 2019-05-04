using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator anim;
    public int LevelToLoad;

    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
