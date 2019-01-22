﻿using AutoMapper;
using System;
using Xpress.Core;

namespace Xpress.AutoMapper
{
    /// <summary>
    /// AutoMapper specific extension methods for <see cref="AppBuilderOptions" />.
    /// </summary>
    public static class AutoMapperAppBuilderOptionsExtension
    {
        /// <summary>
        /// Use AutoMapper
        /// </summary>
        public static AppBuilderOptions UseAutoMapper(this AppBuilderOptions builder, Action<IMapperConfigurationExpression> config = null)
        {
            Mapper.Initialize(options =>
            {
                options.ValidateInlineMaps = false;
                config?.Invoke(options);
            });

            return builder;
        }
    }
}

