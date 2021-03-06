﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xpress.Core.EventBus.Local
{
    /// <summary>
    /// This <see cref="IEventHandlerFactory"/> implementation is used to handle events
    /// by a transient instance object. 
    /// </summary>
    /// <remarks>
    /// This class always creates a new transient instance of handler.
    /// </remarks>
    public class TransientEventHandlerFactory<THandler> : IEventHandlerFactory
        where THandler : ILocalEventHandler, new()
    {
        /// <summary>
        /// Creates a new instance of the handler object.
        /// </summary>
        /// <returns>The handler object</returns>
        public IEventHandlerDisposeWrapper GetHandler()
        {
            var handler = new THandler();
            return new EventHandlerDisposeWrapper(handler, () => (handler as IDisposable)?.Dispose());
        }
    }
}
