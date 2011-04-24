﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
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
namespace MassTransit.BusConfigurators
{
	using System;

	public class ServiceBusSettings :
		BusSettings
	{
		public ServiceBusSettings(ServiceBusConfiguratorDefaultSettings defaultSettings)
		{
			AutoStart = defaultSettings.AutoStart;
			ObjectBuilder = defaultSettings.ObjectBuilder;
			ConcurrentConsumerLimit = defaultSettings.ConcurrentConsumerLimit;
			ConcurrentReceiverLimit = defaultSettings.ConcurrentReceiverLimit;
			ReceiveTimeout = defaultSettings.ReceiveTimeout;
			EndpointCache = defaultSettings.EndpointCache;
		}

		public IEndpointCache EndpointCache { get; set; }
		public TimeSpan ReceiveTimeout { get; set; }
		public int ConcurrentReceiverLimit { get; set; }
		public int ConcurrentConsumerLimit { get; set; }


		public Action BeforeConsume { get; set; }
		public Action AfterConsume { get; set; }
		public IObjectBuilder ObjectBuilder { get; set; }

		public bool AutoStart { get; set; }
		public Uri InputAddress { get; set; }
	}
}