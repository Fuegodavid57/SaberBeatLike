using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


enum ButtonType
{
    PLAY,
    EXIT
}


public class MainButton : MonoBehaviour
{
    [SerializeField] ButtonType buttonType;
    [SerializeField] Button button;
    [SerializeField] string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(GetActionByType());
    }

    public UnityAction GetActionByType()
    {
        List<Action> _actions = new List<Action>
        {
            () => { SceneManager.LoadScene(sceneName); },
            () => { EditorApplication.ExitPlaymode(); },
        };

        return new UnityAction(_actions[(int)buttonType]);
    }
}
