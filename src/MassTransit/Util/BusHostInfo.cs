﻿// Copyright 2007-2016 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Util
{
    using System;
    using System.Diagnostics;


    [Serializable]
    public class BusHostInfo :
        HostInfo
    {
        public BusHostInfo()
        {
        }

        public BusHostInfo(bool initialize)
        {
            MachineName = Environment.MachineName;

            MassTransitVersion = FileVersionInfo.GetVersionInfo(typeof(IBus).Assembly.Location).FileVersion;
            FrameworkVersion = Environment.Version.ToString();
            OperatingSystemVersion = Environment.OSVersion.ToString();
            var currentProcess = Process.GetCurrentProcess();
            ProcessId = currentProcess.Id;
            ProcessName = currentProcess.ProcessName;

            var entryAssembly = System.Reflection.Assembly.GetEntryAssembly() ?? System.Reflection.Assembly.GetCallingAssembly();
            var assemblyName = entryAssembly.GetName();
            Assembly = assemblyName.Name;
            AssemblyVersion = FileVersionInfo.GetVersionInfo(entryAssembly.Location).FileVersion;
        }

        public string MachineName { get; private set; }
        public string ProcessName { get; private set; }
        public int ProcessId { get; private set; }
        public string Assembly { get; private set; }
        public string AssemblyVersion { get; private set; }
        public string FrameworkVersion { get; private set; }
        public string MassTransitVersion { get; private set; }
        public string OperatingSystemVersion { get; private set; }
    }
}