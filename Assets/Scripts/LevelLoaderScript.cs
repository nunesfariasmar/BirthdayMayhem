using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void LoadNextLevel()
    {
    }

    public IEnumerator LoadLevel(int levelIndex)
    {

        var textBox = FindObjectsOfType<Text>().FirstOrDefault(x => x.CompareTag("Transition"));

        textBox.text = "The Next Weekend...";

        //Play animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
