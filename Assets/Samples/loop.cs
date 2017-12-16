/*
 * File Name:               loop.cs
 * 
 * Description:             普通类
 * Author:                  lisiyu <576603306@qq.com>

 * Create Date:             2017/12/16
 */

using System.Collections.Generic;

[XTest("for/foreach/while")]
public class loop 
{
    private int count = 1000;
    private loop_int value_int;
    private loop_class value_class;
    public loop()
    {
        value_int = new loop_int(count);
        value_class = new loop_class(count);
    }

    [XTest("int_for_array")]
    public void int_for_array()
    {
        value_int.tst_for_array();
    }

    [XTest("int_foreach_array")]
    public void int_foreach_array()
    {
        value_int.tst_foreach_array();
    }

    [XTest("int_while_array")]
    public void int_while_array()
    {
        value_int.tst_while_array();
    }

    [XTest("int_for_list")]
    public void int_for_list()
    {
        value_int.tst_for_list();
    }

    [XTest("int_foreach_list")]
    public void int_foreach_list()
    {
        value_int.tst_foreach_list();
    }

    [XTest("int_while_list")]
    public void int_while_list()
    {
        value_int.tst_while_list();
    }

    class loop_int
    {
        private int count;
        private int[] values_array;
        private List<int> values_list;
        public loop_int(int count)
        {
            this.count = count;
            values_array = new int[count];
            values_list = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                values_array[i] = i;
                values_list.Add(i);
            }
        }

        public void tst_for_array()
        {
            for (int i = 0; i < count; i++)
            {
                int a = values_array[i];
            }
        }

        public void tst_foreach_array()
        {
            foreach (var item in values_array)
            {
                int a = item;
            }
        }

        public void tst_while_array()
        {
            int i = 0;
            while(i < count)
            {
                int a = values_array[i];
                i++;
            }
        }

        public void tst_for_list()
        {
            for (int i = 0; i < count; i++)
            {
                int a = values_list[i];
            }
        }

        public void tst_foreach_list()
        {
            foreach (var item in values_list)
            {
                int a = item;
            }
        }

        public void tst_while_list()
        {
            int i = 0;
            while (i < count)
            {
                int a = values_list[i++];
            }
        }
    }

    [XTest("class_for_array")]
    public void class_for_array()
    {
        value_class.tst_for_array();
    }

    [XTest("class_foreach_array")]
    public void class_foreach_array()
    {
        value_class.tst_foreach_array();
    }

    [XTest("class_while_array")]
    public void class_while_array()
    {
        value_class.tst_while_array();
    }

    [XTest("class_for_list")]
    public void class_for_list()
    {
        value_class.tst_for_list();
    }

    [XTest("class_foreach_list")]
    public void class_foreach_list()
    {
        value_class.tst_foreach_list();
    }

    [XTest("class_while_list")]
    public void class_while_list()
    {
        value_class.tst_while_list();
    }

    class loop_class
    {
        private class data
        {
            int a, b, c;
        }

        private int count;
        private data[] values_array;
        private List<data> values_list;
        public loop_class(int count)
        {
            this.count = count;
            values_array = new data[count];
            values_list = new List<data>(count);
            for (int i = 0; i < count; i++)
            {
                var _value = new data();
                values_array[i] = _value;
                values_list.Add(_value);
            }
        }

        public void tst_for_array()
        {
            for (int i = 0; i < count; i++)
            {
                data a = values_array[i];
            }
        }

        public void tst_foreach_array()
        {
            foreach (var item in values_array)
            {
                data a = item;
            }
        }

        public void tst_while_array()
        {
            int i = 0;
            while (i < count)
            {
                data a = values_array[i++];
            }
        }

        public void tst_for_list()
        {
            for (int i = 0; i < count; i++)
            {
                data a = values_list[i];
            }
        }

        public void tst_foreach_list()
        {
            foreach (var item in values_list)
            {
                data a = item;
            }
        }

        public void tst_while_list()
        {
            int i = 0;
            while (i < count)
            {
                data a = values_list[i++];
            }
        }
    }
}
