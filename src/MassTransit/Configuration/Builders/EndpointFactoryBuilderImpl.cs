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
namespace MassTransit.Builders
{
	using System;
	using System.Collections.Generic;
	using Configuration;
	using EndpointConfigurators;
	using Serialization;
	using Transports;

	public class EndpointFactoryBuilderImpl :
		EndpointFactoryBuilder
	{
		readonly EndpointDefaults _defaults;
		readonly IDictionary<Uri, EndpointBuilder> _endpointBuilders;
		readonly IDictionary<string, ITransportFactory> _transportFactories;

		public EndpointFactoryBuilderImpl()
		{
			_endpointBuilders = new Dictionary<Uri, EndpointBuilder>();
			_transportFactories = new Dictionary<string, ITransportFactory>();

			AddTransportFactory(new LoopbackTransportFactory());
			AddTransportFactory(new MulticastUdpTransportFactory());

			_defaults = new EndpointDefaults();
		}

		public IEndpointFactory Build()
		{
			var endpointFactory = new EndpointFactory(_transportFactories, _endpointBuilders, _defaults);

			return endpointFactory;
		}

		public void SetDefaultSerializer(IMessageSerializer defaultSerializer)
		{
			_defaults.Serializer = defaultSerializer;
		}

		public void SetDefaultTransactionTimeout(TimeSpan transactionTimeout)
		{
			_defaults.TransactionTimeout = transactionTimeout;
		}
		
		public void SetCreateMissingQueues(bool createMissingQueues)
		{
			_defaults.CreateMissingQueues = createMissingQueues;
		}
	
		public void SetCreateTransactionalQueues(bool createTransactionalQueues)
		{
			_defaults.CreateTransactionalQueues = createTransactionalQueues;
		}

		public void SetPurgeOnStartup(bool purgeOnStartup)
		{
			_defaults.PurgeOnStartup = purgeOnStartup;
		}

		public void AddEndpointBuilder(Uri uri, EndpointBuilder endpointBuilder)
		{
			_endpointBuilders[uri] = endpointBuilder;
		}

		public void AddTransportFactory(ITransportFactory transportFactory)
		{
			string scheme = transportFactory.Scheme.ToLowerInvariant();

			_transportFactories[scheme] = transportFactory;
		}

		public IEndpointDefaults Defaults
		{
			get { return _defaults; }
		}
	}
}