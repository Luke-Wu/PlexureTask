// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using CouponManagerSystem;
using System.Threading.Tasks;

namespace CouponManagerSystem.Tests
{
    [TestFixture]
    public class CouponManagerTest
    {
        [Test]
        public void Test_CouponManager_Constructor()
        {
            var ex = Assert.Catch<ArgumentNullException>(() => new CouponManager(null, null));
            Assert.AreEqual(ex.ParamName, "logger");

            ex = Assert.Catch<ArgumentNullException>(() => new CouponManager(LogManager.GetCurrentClassLogger(), null));
            Assert.AreEqual(ex.ParamName, "couponProvider");
        }

        [Test]
        public void TestCanRedeemCoupon()
        {
            var cm1 = new CouponManager(LogManager.GetCurrentClassLogger(), new CouponProvider());

            var ex = Assert.CatchAsync<ArgumentNullException>(() => cm1.CanRedeemCoupon(Guid.NewGuid(), Guid.NewGuid(), null));
            Assert.AreEqual(ex.ParamName, "evaluators");

            var evaluators = new List<Func<CouponManager, Guid, bool>>();

            Assert.Catch<KeyNotFoundException>(async () => await cm1.CanRedeemCoupon(Guid.Empty, Guid.NewGuid(), evaluators));

            var xx = Guid.NewGuid();
            Task<bool> r1;
            r1 = cm1.CanRedeemCoupon(xx, Guid.NewGuid(), evaluators);
            Assert.IsTrue(r1.Result);

            evaluators.Add((manager, guid) => true);
            r1 = cm1.CanRedeemCoupon(xx, Guid.NewGuid(), evaluators);
            Assert.IsTrue(r1.Result);

            evaluators.Add((manager, guid) => false);
            r1 = cm1.CanRedeemCoupon(xx, Guid.NewGuid(), evaluators);
            Assert.IsFalse(r1.Result);
        }




    }
}
