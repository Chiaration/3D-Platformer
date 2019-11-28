using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject MenuObject;
    [SerializeField] private GameObject LevelObject;
    
    bool MenuBool = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectLevel()
    {
        if (MenuBool)
        {
            MenuObject.SetActive(false);
            LevelObject.SetActive(true);
            MenuBool = false;
        } else if (!MenuBool)
        {
            MenuObject.SetActive(true);
            LevelObject.SetActive(false);
            MenuBool = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
