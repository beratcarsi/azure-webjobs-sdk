﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Binding provider handling bindings to both <see cref="TraceWriter"/> and <see cref="TextWriter"/>.
    /// <remarks>
    /// </remarks>
    /// </summary>
    internal class TraceWriterBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ParameterInfo parameter = context.Parameter;
            if (parameter.ParameterType != typeof(TraceWriter) &&
                parameter.ParameterType != typeof(TextWriter))
            {
                return Task.FromResult<IBinding>(null);
            }

            IBinding binding = new TraceWriterBinding(parameter);
            return Task.FromResult(binding);
        }
    }
}
