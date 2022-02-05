using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    
    public GameObject inputFieldObject;
    private TMP_InputField inputField;

 
    

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputFieldObject.GetComponent<TMP_InputField>();
        inputField.text = DataManager.Instance.playerName;
    }



    public void OnNameEdited(string playerName){
        string newName = inputField.text;
        DataManager.Instance.playerName = newName;
        Debug.Log("wtf"+newName);
    }



    public void StartNew(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        DataManager.Instance.Save();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
