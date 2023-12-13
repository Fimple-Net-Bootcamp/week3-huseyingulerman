using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3_huseyingulerman.Core.Result.Abstract;

namespace week3_huseyingulerman.Core.Result.Concrete
{
    public class AppResult<T> : IAppResult<T>
    {
        public T Data { get; set; }

        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }
        public static AppResult<T> Success(int statusCode, T data)
        {
            return new AppResult<T> { StatusCode = statusCode, Data=data };
        }
        public static AppResult<T> Success(int statusCode)
        {
            return new AppResult<T> { StatusCode = statusCode };
        }
        public static AppResult<T> Fail(int statusCode, List<string> errors)
        {
            return new AppResult<T> { StatusCode=statusCode, Errors = errors };
        }
        public static AppResult<T> Fail(int statusCode, string error)
        {
            return new AppResult<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
