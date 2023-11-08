using System;
using Random = System.Random;

namespace MyRI
{
    public class RandomUtils
    {

        private static RandomUtils _instance;
        public Random Random;

        public static RandomUtils Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RandomUtils();
                return _instance;
            }
        }

        private RandomUtils()
        {
            Random = new Random(DateTime.Now.Second);
        }
    }
}
