using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Shared
{
    /// <summary>
    /// It is an abstraction of to get HTTP Response
    /// </summary>
    public interface IResult
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }
    }

    /// <summary>
    /// It is an abstraction of to get HTTP Response for a generic parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
