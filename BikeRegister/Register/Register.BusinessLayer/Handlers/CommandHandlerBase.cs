using Register.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.BusinessLayer.Handlers
{
    /// <summary>
    /// Abstract class for all command handlers
    /// </summary>
    internal abstract class CommandHandlerBase<TRequest, TResult>:IHandler where TRequest:Command where TResult:CommandResult
    {
        /// <summary>
        /// The method that execute the command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public abstract CommandResult Execute(Command command);

        public CommandResult Execute(Command command)
        {
            throw new NotImplementedException();
        }
    }
    internal interface IHandler
    {
        CommandResult Execute(Command command);
    }
}
