using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptions
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAtttibute : Attribute, IInterceptor
    {
        public int Prioty { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
