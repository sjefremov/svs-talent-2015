using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registar.BusinessLayer.Contracts;

namespace Registar.BusinessLayer.Handlers
{
    //We changed the access level of the class to public only for testing. Otherwise was internal
    /// <summary>
    /// Abstract class for all command handlers
    /// </summary>
    public abstract class CommandHandlerBase<TRequest,TResult>:IHandler where TRequest:Command
                                                                 where TResult:CommandResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public CommandResult Execute(Command command)
        {
            return ExecuteCommand((TRequest)command);
        }

        /// <summary>
        /// The method that executes the command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected abstract TResult ExecuteCommand(TRequest command);

    }

    internal interface IHandler
    {
        CommandResult Execute(Command command);
    }
}
