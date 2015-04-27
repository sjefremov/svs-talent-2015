using Register.BusinessLayer.Contracts;
using Register.BusinessLayer.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.BusinessLayer
{
    /// <summary>
    /// Provides method for invoking commands from other layers
    /// </summary>
    public class CommandInvoker
    {
        /// <summary>
        /// Entry point for execution of differerent commands
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static TResult InvokeCommand<TRequest, TResult>(TRequest command)
            where TRequest : Command
            where TResult : CommandResult
        {
            CommandHandlerBase<TRequest, TResult> _handler = null;
            TResult _result = default(TResult);
            if (typeof(TRequest) == typeof(BikeSearchCommand))
            {
                _handler = (CommandHandlerBase<TRequest, TResult>)command;
            }
        }
    }
}
