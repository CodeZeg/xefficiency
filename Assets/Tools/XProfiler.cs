/*
 * File Name:               XProfiler.cs
 * 
 * Description:             性能统计工具
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2017/12/16
 */

using UnityEngine;
using UnityEngine.Profiling;

public class XProfiler 
{
    private static float mLastTime;
    private static long mLastMem;
  
    public static void begin()
    {
        
        System.GC.Collect();
        mLastMem = Profiler.GetMonoHeapSizeLong();
        mLastTime = Time.realtimeSinceStartup;
    }

    public static string end(string tag)
    {
        var nowTime = Time.realtimeSinceStartup;
        var nowMem = Profiler.GetMonoHeapSizeLong();
        return string.Format("<color=green>{0}</color> used time <color=red>{1}</color> s and alloc mem <color=red>{2}</color> byte\n", tag, nowTime - mLastTime, nowMem - mLastMem);
    }
}
