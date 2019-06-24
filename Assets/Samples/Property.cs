/*
 * File Name:               Property.cs
 * 
 * Description:             测试类
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2019/06/22
 */

using Unity.IL2CPP.CompilerServices;

[XTest("Property")]
public class Property : BaseTester
{
    public class Data
    {
        public int raw;

        public int property
        {
            get { return raw; }
            set { raw = value; }
        }

        public int property2 { get; set; }

        public unsafe int* _pointer;
        public unsafe int pointer
        {
            get { return *_pointer; }
            set { *_pointer = value; }
        }

        [Il2CppSetOption(Option.NullChecks, false)]
        public unsafe int pointer2
        {
            get { return *_pointer; }
            set { *_pointer = value; }
        }

        public unsafe void init()
        {
            fixed (int* _raw = &raw)
            {
                _pointer = _raw;
            }
        }
    }

    private int r;
    private Data data;
    public override void init()
    {
        data = new Data();
        data.init();
    }


    [XTest("Field")]
    public void testField()
    {
        // count:100000 => 27.357s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                data.raw = r;
                r = data.raw;
            }
        }
    }

    [XTest("Property")]
    public void testProperty()
    {
        // count:100000 => 23.598s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                data.property = r;
                r = data.property;
            }
        }
    }

    [XTest("Property {get; set;}")]
    public void testProperty2()
    {
        // count:100000 => 27.329s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                data.property2 = r;
                r = data.property2;
            }
        }
    }

    [XTest("Pointer")]
    public void testPointer()
    {
        // count:100000 => 50.732s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                data.pointer = r;
                r = data.pointer;
            }
        }
    }

    [XTest("Pointer without nullcheck")]
    public void testPointer2()
    {
        // count:100000 => 54.941s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                data.pointer2 = r;
                r = data.pointer2;
            }
        }
    }
}
