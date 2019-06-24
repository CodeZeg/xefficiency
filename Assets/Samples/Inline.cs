/*
 * File Name:               Inline.cs
 * 
 * Description:             测试类
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2019/06/20
 */

using System.Runtime.CompilerServices;
using UnityEngine;

[XTest("Inline")]
public class Inline : BaseTester
{
    private XNumber a = new XNumber() { raw = 1234567 };
    private XNumber_Inline b = new XNumber_Inline() { raw = 1234567 };
    private int r;

    [XTest("无内联编译测试")]
    public void testXnumber()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = a.total().raw;
            }
        }
    }

    [XTest("内联编译测试")]
    public void testInline()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = b.total().raw;
            }
        }
    }

    [XTest("人工内联编码测试")]
    public void testInlineCode()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = b.raw + b.raw - b.raw * b.raw;
            }
        }
    }
}


public struct XNumber
{
    public int raw;

    public static XNumber operator +(XNumber lhs, XNumber rhs)
    {
        XNumber r;
        r.raw = lhs.raw + rhs.raw;
        return r;
    }

    public static XNumber operator -(XNumber lhs, XNumber rhs)
    {
        XNumber r;
        r.raw = lhs.raw - rhs.raw;
        return r;
    }

    public static XNumber operator *(XNumber lhs, XNumber rhs)
    {
        XNumber r;
        r.raw = lhs.raw * rhs.raw;
        return r;
    }

    public static XNumber operator /(XNumber lhs, XNumber rhs)
    {
        XNumber r;
        r.raw = lhs.raw / rhs.raw;
        return r;
    }

    public XNumber total()
    {
        return this + this - this * this;
    }
}

public struct XNumber_Inline
{
    public int raw;

    [MethodImpl(256)]
    public static XNumber_Inline operator +(XNumber_Inline lhs, XNumber_Inline rhs)
    {
        XNumber_Inline r;
        r.raw = lhs.raw + rhs.raw;
        return r;
    }


    [MethodImpl(256)]
    public static XNumber_Inline operator -(XNumber_Inline lhs, XNumber_Inline rhs)
    {
        XNumber_Inline r;
        r.raw = lhs.raw - rhs.raw;
        return r;
    }


    [MethodImpl(256)]
    public static XNumber_Inline operator *(XNumber_Inline lhs, XNumber_Inline rhs)
    {
        XNumber_Inline r;
        r.raw = lhs.raw * rhs.raw;
        return r;
    }


    [MethodImpl(256)]
    public static XNumber_Inline operator /(XNumber_Inline lhs, XNumber_Inline rhs)
    {
        XNumber_Inline r;
        r.raw = lhs.raw / rhs.raw;
        return r;
    }

    [MethodImpl(256)]
    public XNumber_Inline total()
    {
        return this + this - this * this;
    }
}