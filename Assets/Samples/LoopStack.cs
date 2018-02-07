/*
 * File Name:               LoopStack.cs
 * 
 * Description:             测试类
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2018/02/04
 */

[XTest("LoopStack")]
public class LoopStack 
{
    int count = 1000;
    //[XTest("inner")]
    public void tstInner()
    {
        for (int i = 0; i < count; i++)
        {
            float a = 0.5f;
            float b = 0.5f;
            float c = 0.5f;
            float d = 0.5f;
            float e = 0.5f;
            float f = 0.5f;
            float g = 0.5f;
            float h = 0.5f;
            float j = 0.5f;
            float k = 0.5f;
            float l = 0.5f;
            float m = 0.5f;
        }
    }

    //[XTest("outer")]
    public void tstOuter()
    {
        float a = 0.5f;
        float b = 0.5f;
        float c = 0.5f;
        float d = 0.5f;
        float e = 0.5f;
        float f = 0.5f;
        float g = 0.5f;
        float h = 0.5f;
        float j = 0.5f;
        float k = 0.5f;
        float l = 0.5f;
        float m = 0.5f;
        for (int i = 0; i < count; i++)
        {
            a = 0.5f;
            b = 0.5f;
            c = 0.5f;
            d = 0.5f;
            e = 0.5f;
            f = 0.5f;
            g = 0.5f;
            h = 0.5f;
            j = 0.5f;
            k = 0.5f;
            l = 0.5f;
            m = 0.5f;
        }
    }

    [XTest("没有方法01")]
    public void tst_noFunc01()
    {
        for (int i = 0; i < count; i++)
        {
            return;
            float a = 0.5f;
            float b = 0.5f;
            float c = 0.5f;
            float d = 0.5f;
            float e = 0.5f;
            float f = 0.5f;
            float g = 0.5f;
            float h = 0.5f;
            float j = 0.5f;
            float k = 0.5f;
            float l = 0.5f;
            float m = 0.5f;
        }
    }

    [XTest("没有方法02")]
    public void tst_noFunc02()
    {
        for (int i = 0; i < count; i++)
        {
            return;
        }
        float a = 0.5f;
        float b = 0.5f;
        float c = 0.5f;
        float d = 0.5f;
        float e = 0.5f;
        float f = 0.5f;
        float g = 0.5f;
        float h = 0.5f;
        float j = 0.5f;
        float k = 0.5f;
        float l = 0.5f;
        float m = 0.5f;
    }

    [XTest("有方法")]
    public void tst_func()
    {
        for (int i = 0; i < count; i++)
        {
            return;
            other();
        }
    }

    private void other()
    {
        float a = 0.5f;
        float b = 0.5f;
        float c = 0.5f;
        float d = 0.5f;
        float e = 0.5f;
        float f = 0.5f;
        float g = 0.5f;
        float h = 0.5f;
        float j = 0.5f;
        float k = 0.5f;
        float l = 0.5f;
        float m = 0.5f;
    }
}
