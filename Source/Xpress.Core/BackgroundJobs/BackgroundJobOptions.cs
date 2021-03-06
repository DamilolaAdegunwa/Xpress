﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Xpress.Core.Exceptions;
using Xpress.Core.Extensions;

namespace Xpress.Core.BackgroundJobs
{
    public class BackgroundJobOptions
    {
        private readonly Dictionary<Type, BackgroundJobConfiguration> _jobConfigurationsByArgsType;
        private readonly Dictionary<string, BackgroundJobConfiguration> _jobConfigurationsByName;

        //TODO: Implement for all providers! (Hangfire does not implement yet)
        /// <summary>
        /// Default: true.
        /// </summary>
        public bool IsJobExecutionEnabled { get; set; } = true;

        public BackgroundJobOptions()
        {
            _jobConfigurationsByArgsType = new Dictionary<Type, BackgroundJobConfiguration>();
            _jobConfigurationsByName = new Dictionary<string, BackgroundJobConfiguration>();
        }

        public BackgroundJobConfiguration GetJob<TArgs>()
        {
            return GetJob(typeof(TArgs));
        }

        public BackgroundJobConfiguration GetJob(Type argsType)
        {
            var jobConfiguration = _jobConfigurationsByArgsType.GetOrDefault(argsType);

            if (jobConfiguration == null)
            {
                throw new XpressException("Undefined background job for the job args type: " + argsType.AssemblyQualifiedName);
            }

            return jobConfiguration;
        }

        public BackgroundJobConfiguration GetJob(string name)
        {
            var jobConfiguration = _jobConfigurationsByName.GetOrDefault(name);

            if (jobConfiguration == null)
            {
                throw new XpressException("Undefined background job for the job name: " + name);
            }

            return jobConfiguration;
        }

        public IReadOnlyList<BackgroundJobConfiguration> GetJobs()
        {
            return _jobConfigurationsByArgsType.Values.ToImmutableList();
        }

        public bool TryAddJob<TJob>()
        {
            return TryAddJob(typeof(TJob));
        }

        public bool TryAddJob(Type jobType)
        {
            return TryAddJob(new BackgroundJobConfiguration(jobType));
        }

        public bool TryAddJob(BackgroundJobConfiguration jobConfiguration)
        {
            if (!_jobConfigurationsByName.ContainsKey(jobConfiguration.JobName) && !_jobConfigurationsByArgsType.ContainsKey(jobConfiguration.ArgsType))
            {
                _jobConfigurationsByArgsType[jobConfiguration.ArgsType] = jobConfiguration;
                _jobConfigurationsByName[jobConfiguration.JobName] = jobConfiguration;
                return true;
            }

            return false;
        }
    }
}
