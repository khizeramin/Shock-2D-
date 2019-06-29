using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class UIGeneral : MonoBehaviour
{
    public Canvas BeeBack;

    public UIGeneralData UIData;

    protected virtual void OnUIOperation()
    {
             
    }

    protected virtual void Awake()
    { 
        OnUIOperation();
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (Application.isEditor)
        {
            OnUIOperation();
        }
    }
}
