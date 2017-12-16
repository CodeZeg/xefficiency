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
        int count = int.Parse(mInputField.text);

        mTxtContent.text = "";
        var type = mTypes[mDropDown.value];

        var obj = Activator.CreateInstance(type);
        setEmptyTime(count);
        var methods = type.GetMethods();
        foreach (var item in methods)
        {
            var attrs = item.GetCustomAttributes(typeof(XTestAttribute), true);
            if (attrs == null || attrs.Length == 0)
                continue;
            var callback = (Action)Delegate.CreateDelegate(typeof(Action), obj, item);
            XProfiler.begin();
            int i = 0;
            while(i++ < count)
            {
                callback();
            }
            mTxtContent.text += XProfiler.end((attrs[0] as XTestAttribute).Tag);
        }
    }

    private void setEmptyTime(int count)
    {
        Action callback = emptyMethod;
        var st = Time.realtimeSinceStartup;
        int i = 0;
        while (i++ < count)
        {
            callback();
        }
        XProfiler.setEmptyTime(Time.realtimeSinceStartup - st);
    }

    private void emptyMethod()
    {

    }
}
