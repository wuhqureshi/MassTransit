// Copyright 2007-2008 The Apache Software Foundation.
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
namespace MassTransit.Services.LoadBalancer.Configuration
{
	using System;
	using System.Collections;
	using Internal;
	using MassTransit.Subscriptions;

	public class LoadBalancerServiceConfigurator :
		ILoadBalancerServiceConfigurator
	{
		public Type ServiceType
		{
			get { return typeof (ILoadBalancerService); }
		}

		public IBusService Create(IServiceBus bus, ISubscriptionCache cache, IObjectBuilder builder)
		{
			var arguments = new Hashtable
				{
					{ "bus", bus },
					{ "cache", cache },
				};

			var service = builder.GetInstance<ILoadBalancerService>(arguments);

			return service;
		}
	}
}