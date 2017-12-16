/*
 * File Name:               XTestAttribute.cs
 * 
 * Description:             测试用属性标签
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2017/12/16
 */

using System;

public class XTestAttribute : Attribute
{
    public string Tag;
    public XTestAttribute(string tag)
    {
        this.Tag = tag;
    }
}
