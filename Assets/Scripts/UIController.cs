using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Action OnBuildAreaHandler;
    private Action OnCancelActionHandler;

    public Button BuildResidentialAreaBtn;
    public Button CancelActionBtn;
    public GameObject CancelActionPanel; 

    // Start is called before the first frame update
    void Start()
    {
        CancelActionPanel.SetActive(false); 
        BuildResidentialAreaBtn.onClick.AddListener(OnBuildAreaCallback);
        CancelActionBtn.onClick.AddListener(OnCancelActionCallback);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBuildAreaCallback()
    {
        CancelActionPanel.SetActive(true);
        OnBuildAreaHandler?.Invoke();
    }

    private void OnCancelActionCallback()
    {
        CancelActionPanel.SetActive(false);
        OnCancelActionHandler?.Invoke();
    }

    public void AddOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler += listener;
    }

    public void RemoveOnBuildAreaEvent(Action listener)
    {
        OnBuildAreaHandler -= listener;
    }

    public void AddOnCancelActionEvent(Action listener)
    {
        OnCancelActionHandler += listener;
    }

    public void RemoveCancelActionEvent(Action listener)
    {
        OnCancelActionHandler -= listener;
    }
}
