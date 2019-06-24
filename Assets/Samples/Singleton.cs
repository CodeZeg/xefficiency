[XTest("Singleton")]
public class Singleton : BaseTester
{
    public class Data
    {
        public int raw;
        public static int staticRaw;

        private static Data _singleton;
        public static Data singleton
        {
            get
            {
                if (_singleton == null)
                    _singleton = new Data();
                return _singleton;
            }
        }

        public static Data singleton2
        {
            get
            {
                return _singleton;
            }
        }
    }

    public int r;
    private Data data = Data.singleton;

    [XTest("Singleton")]
    public void testSingleton()
    {
        // count:100000 => 78.863s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = Data.singleton.raw;
            }
        }
    }

    [XTest("Singleton no check")]
    public void testSingleton2()
    {
        // count:100000 => 27.329s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = Data.singleton2.raw;
            }
        }
    }

    [XTest("var")]
    public void testVar()
    {
        // count:100000 => 18.225s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = data.raw;
            }
        }
    }

    [XTest("static")]
    public void testStatic()
    {
        // count:100000 => 13.666s
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                r = Data.staticRaw;
            }
        }
    }
}
