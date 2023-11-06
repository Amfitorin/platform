using System;
using Random = System.Random;

namespace MyRI
{
    public class RandomUtils
    {
        public Random Random;
        private RandomUtils()
        {
            Random = new Random(DateTime.Now.Second);
        }

        private static RandomUtils _instance;

        public static RandomUtils Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RandomUtils();
                return _instance;
            }
        }
    }
}