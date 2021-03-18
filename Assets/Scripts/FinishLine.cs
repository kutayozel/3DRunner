using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{



 
    private void OnTriggerEnter(Collider other) 
    {
        StartCoroutine ("FinishLevel");
    }

    public IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
