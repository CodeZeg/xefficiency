/*
 * File Name:               XRandom.cs
 * 
 * Description:             随机数库 避免测试逻辑引用特定库
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2017/12/16
 */

using System;

public class XRandom 
{
    private static Random mRandom = new Random();
    public static int Next()
    {
        return mRandom.Next();
    }

    public static int Next(int min, int max)
    {
        return mRandom.Next(min, max);
    }
}
