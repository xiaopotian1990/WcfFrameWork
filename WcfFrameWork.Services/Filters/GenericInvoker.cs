using System;
using System.ServiceModel.Dispatcher;

namespace WcfFrameWork.Services.Filters
{
    /// <summary>
    /// 自定义操作执行器，该操作发生在操作选择器之后。
    /// </summary>
    public abstract class GenericInvoker : IOperationInvoker
    {
        /// <summary>
        /// 旧的操作执行器。
        /// </summary>
        readonly IOperationInvoker m_OldInvoker;

        /// <summary>
        /// 通过构造函数保存旧的操作执行器。
        /// </summary>
        /// <param name="oldInvoker"></param>
        public GenericInvoker(IOperationInvoker oldInvoker)
        {
            m_OldInvoker = oldInvoker;
        }

        /// <summary>
        /// 返回参数对象的 System.Array。
        /// </summary>
        /// <returns>要用作操作的实参的形参。</returns>
        public virtual object[] AllocateInputs()
        {
            return m_OldInvoker.AllocateInputs();
        }
        /// <summary>
        /// 操作执行之前调用。
        /// </summary>
        /// <returns></returns>
        protected virtual void PreInvoke(object instance, object[] inputs)
        { }

        /// <summary>
        /// 操作执行完成以后调用，总会被调用。
        /// </summary>
        /// <returns></returns>
        protected virtual void PostInvoke(object instance, object returnedValue, object[] outputs, Exception exception)
        { }

        /// <summary>
        /// 从一个实例和输入对象的集合返回一个对象和输出对象的集合。
        /// </summary>
        /// <param name="instance"> 要调用的对象。</param>
        /// <param name="inputs"> 方法的输入。</param>
        /// <param name="outputs"> 方法的输出。</param>
        /// <returns> 返回值。</returns>
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            PreInvoke(instance, inputs);
            object returnedValue = null;
            object[] outputParams = new object[] { };
            Exception exception = null;
            try
            {
                returnedValue = m_OldInvoker.Invoke(instance, inputs, out outputParams);
                outputs = outputParams;
                return returnedValue;
            }
            catch (Exception operationException)
            {
                exception = operationException;
                throw;
            }
            finally
            {
                PostInvoke(instance, returnedValue, outputParams, exception);
            }
        }

        /// <summary>
        /// System.ServiceModel.Dispatcher.IOperationInvoker.Invoke(System.Object,System.Object[],System.Object[]@)
        /// 方法的异步实现。
        /// </summary>
        /// <param name="instance"> 要调用的对象。</param>
        /// <param name="inputs"> 方法的输入。</param>
        /// <param name="callback"> 异步回调对象。</param>
        /// <param name="state"> 关联的状态数据。</param>
        /// <returns> 用来完成异步调用的 System.IAsyncResult。</returns>
        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            PreInvoke(instance, inputs);
            return m_OldInvoker.InvokeBegin(instance, inputs, callback, state);
        }

        /// <summary>
        /// 异步结束方法。
        /// </summary>
        /// <param name="instance"> 调用的对象。</param>
        /// <param name="outputs"> 方法的输出。</param>
        /// <param name="result"> System.IAsyncResult 对象。</param>
        /// <returns> 返回值。</returns>
        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            object returnedValue = null;
            object[] outputParams = { };
            Exception exception = null;

            try
            {
                returnedValue = m_OldInvoker.InvokeEnd(instance, out outputs, result);
                outputs = outputParams;
                return returnedValue;
            }
            catch (Exception operationException)
            {
                exception = operationException;
                throw;
            }
            finally
            {
                PostInvoke(instance, returnedValue, outputParams, exception);
            }
        }

        /// <summary>
        /// 获取一个值，该值指定调度程序是调用 System.ServiceModel.Dispatcher.IOperationInvoker.Invoke(System.Object,System.Object[],System.Object[]@)
        /// 方法还是调用 System.ServiceModel.Dispatcher.IOperationInvoker.InvokeBegin(System.Object,System.Object[],System.AsyncCallback,System.Object)
        /// 方法。如果调度程序调用同步操作，则为 true；否则为 false。
        /// </summary>
        public bool IsSynchronous
        {
            get
            {
                return m_OldInvoker.IsSynchronous;
            }
        }
    }
}
