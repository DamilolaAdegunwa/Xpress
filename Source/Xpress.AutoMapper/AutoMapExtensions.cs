﻿using AutoMapper;

namespace Xpress.AutoMapper
{
    /// <summary>
    /// Object mapping extension
    /// </summary>
    public static class ObjectMapperExtensions
    {
        /// <summary>
        /// Map out new target objects
        /// </summary>
        public static TDestination MapTo<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// Map attribute content to target object
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}

