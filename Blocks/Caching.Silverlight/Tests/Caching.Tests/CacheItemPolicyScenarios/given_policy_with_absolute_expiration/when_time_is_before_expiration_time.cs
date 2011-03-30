﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.EnterpriseLibrary.Caching.InMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Caching.Tests.CacheItemPolicyScenarios.given_policy_with_absolute_expiration
{
    [TestClass]
    public class when_time_is_before_expiration_time : Context
    {
        protected override void Act()
        {
            base.Act();

            CachingTimeProvider.SetTimeProviderForTests(() => AbsoluteExpirationTime - TimeSpan.FromMinutes(3) );
        }

        [TestMethod]
        public void then_item_is_not_expired()
        {
            Assert.IsFalse(CacheItemPolicy.IsExpired(DateTimeOffset.Now));
        }
    }
}
