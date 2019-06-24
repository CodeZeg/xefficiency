/*
 * File Name:               Gate.cs
 * 
 * Description:             测试入口类
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2017/12/16
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTester
{
    public int count;

    public virtual void init()
    {

    }
}

public class Gate : MonoBehaviour
{
    public Dropdown mDropDown;
    public Button mButton;
    public Text mTxtContent;
    public InputField mInputField;

    private Type[] mTypes;
   
    private void Start()
    {
        mButton.onClick.AddListener(onBtnClick);
        mTxtContent.text = "请选择测试项目";

        var options = new List<string>();
        var tmpTypes = new List<Type>();
        var types = this.GetType().Assembly.GetTypes();
        foreach (var item in types)
        {
            var attrs = item.GetCustomAttributes(typeof(XTestAttribute), true);
            if (attrs == null || attrs.Length == 0)
                continue;

            tmpTypes.Add(item);
            options.Add((attrs[0] as XTestAttribute).Tag);
        }
        mTypes = tmpTypes.ToArray();
  
        mDropDown.ClearOptions();
        mDropDown.AddOptions(options);
    }

    private void onBtnClick()
    {

        if (mDropDown.value >= mTypes.Length)
            return;
        var count = int.Parse(mInputField.text);

        mTxtContent.text = "";
        var type = mTypes[mDropDown.value];

        object obj = Activator.CreateInstance(type);
        var tester = obj as BaseTester;
        tester.count = count;
        tester.init();

        var methods = type.GetMethods();
        foreach (var item in methods)
        {
            var attrs = item.GetCustomAttributes(typeof(XTestAttribute), true);
            if (attrs == null || attrs.Length == 0)
                continue;
            var callback = (Action)Delegate.CreateDelegate(typeof(Action), obj, item);
            var tag = (attrs[0] as XTestAttribute).Tag;
            XProfiler.begin();
            callback();
            mTxtContent.text += XProfiler.end(tag);
        }
    }
}
