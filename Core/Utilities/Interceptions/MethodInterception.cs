using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptions
{
    public abstract class MethodInterception : MethodInterceptionBaseAtttibute
    {
        protected virtual void OnBefore(IInvocation ınvocation) { }
        protected virtual void OnAfter(IInvocation ınvocation) { }
        protected virtual void OnException(IInvocation ınvocation) { }
        protected virtual void OnSuccess(IInvocation ınvocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
