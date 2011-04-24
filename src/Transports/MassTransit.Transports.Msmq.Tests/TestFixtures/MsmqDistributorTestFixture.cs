﻿// Copyright 2007-2008 The Apache Software Foundation.
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
namespace MassTransit.Transports.Msmq.Tests.TestFixtures
{
	using Configuration;
	using Configurators;
	using EndpointConfigurators;
	using MassTransit.Tests.Distributor;
	using NUnit.Framework;

	[TestFixture, Category("Integration")]
	public class MsmqDistributorTestFixture :
		DistributorTestFixture<MsmqTransportFactory>
	{
		protected override void EstablishContext()
		{
			SubscriptionServiceUri = SubscriptionServiceUri.Replace("loopback", "msmq");
			ClientControlUri = ClientControlUri.Replace("loopback", "msmq");
			ServerControlUri = ServerControlUri.Replace("loopback", "msmq");
			ClientUri = ClientUri.Replace("loopback", "msmq");
			ServerUri = ServerUri.Replace("loopback", "msmq");

			base.EstablishContext();
		}

		protected override void AdditionalEndpointFactoryConfiguration(EndpointFactoryConfigurator x)
		{
			base.AdditionalEndpointFactoryConfiguration(x);

			EndpointConfiguratorImpl.Defaults(y =>
				{
					y.CreateMissingQueues = true;
					y.CreateTransactionalQueues = false;
					y.PurgeOnStartup = true;
				});
		}
	}
}