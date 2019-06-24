/*
 * File Name:               Il2cpp.cs
 * 
 * Description:             测试类
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2019/06/21
 */

using Unity.IL2CPP.CompilerServices;

[XTest("Il2cpp")]
public class Il2cpp : BaseTester
{
    public class Il2cppValue
    {
        public int raw = 0;
    }

    private Il2cppValue value;
    private Il2cppValue[] values;
    private int r;

    public override void init()
    {
        value = new Il2cppValue();
        values = new Il2cppValue[count];
        for (int i = 0; i < count; i++)
        {
            values[i] = new Il2cppValue();
        }
    }

    [XTest("NullChecks true")]
    public void testNullChecksTrue()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = value.raw;
            }
        }
    }

    [XTest("NullChecks false")]
    [Il2CppSetOption(Option.NullChecks, false)]
    public void testNullChecksFalse()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = value.raw;
            }
        }
    }

    [XTest("ArrayBoundsChecks true")]
    public void testArrayBoundsChecksTrue()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = values[i].raw;
            }
        }
    }

    [XTest("ArrayBoundsChecks false")]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    public void testArrayBoundsChecksFalse()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = values[i].raw;
            }
        }
    }

    [XTest("NullChecksAndArrayBoundsChecks false")]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    public void testNullChecksAndArrayBoundsChecksFalse()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = values[i].raw;
            }
        }
    }
}