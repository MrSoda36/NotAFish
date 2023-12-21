using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transition;
    public string sceneName;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
    }


    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string str)
    {
        transition.SetTrigger("LeaveScene");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(str);
    }
}
