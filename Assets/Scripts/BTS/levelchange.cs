using UnityEngine.SceneManagement;
using UnityEngine;

public class levelchange : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fadetolevel(string levelName) {
        anim.SetTrigger("Fadeout");
        SceneManager.LoadScene(levelName);

    }
   
}
