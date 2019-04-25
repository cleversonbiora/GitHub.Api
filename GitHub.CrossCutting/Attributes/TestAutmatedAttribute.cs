using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.CrossCutting.Attributes
{
    public class TestAutmatedAttribute : Attribute
    {
        object[] parameters;
        public TestAutmatedAttribute(params object[] args)
        {
            parameters = args;
        }
    }
}