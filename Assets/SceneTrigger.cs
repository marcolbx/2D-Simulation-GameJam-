using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision");
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        if(currentSceneIndex<SceneManager.sceneCount-1)
        {
        SceneManager.LoadScene(currentSceneIndex + 1);
        }
        }
    }
}
