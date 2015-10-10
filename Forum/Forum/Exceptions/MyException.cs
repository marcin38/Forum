using System;

namespace Forum.Exceptions
{
    public class MyException : Exception
    {
        public int status {get; set;}

        public MyException(int status)
        {
            this.status = status;
        }
    }
}