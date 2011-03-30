﻿using System;
using Microsoft.Practices.EnterpriseLibrary.Caching.InMemory;
using Microsoft.Practices.EnterpriseLibrary.Caching.Runtime.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.ContextBase;

namespace Microsoft.Practices.EnterpriseLibrary.Caching.Tests.CacheItemPolicyScenarios.
    given_policy_with_nonremovable_priority_and_expiration
{
    public abstract class Context : ArrangeActAssert
    {
        protected DateTimeOffset ExpirationTime = new DateTimeOffset(2011, 2, 25, 11, 44, 00, TimeSpan.Zero);
        protected CacheItemPolicy Policy;

        protected override void Arrange()
        {
            base.Arrange();

            Policy = 
                new CacheItemPolicy
                {
                    AbsoluteExpiration = ExpirationTime,
                    Priority = CacheItemPriority.NotRemovable
                };
        }

        protected override void Teardown()
        {
            CachingTimeProvider.ResetTimeProvider();
            base.Teardown();
        }
    }
}