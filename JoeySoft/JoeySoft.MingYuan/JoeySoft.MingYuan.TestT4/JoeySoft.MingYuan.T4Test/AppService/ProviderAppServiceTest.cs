using Mysoft.Clgyl.ProjectPrep.AppServices;
using Mysoft.Clgyl.ProjectPrep.DomainServices;
using Mysoft.Clgyl.ProjectPrep.DomainServices.Fakes;
using Mysoft.Clgyl.ProjectPrep.Model;
using Mysoft.Clgyl.Utility;
using Mysoft.Map6.Platform.Services;
using Mysoft.Map6.Platform.Services.Fakes;
using Mysoft.Map6.Core.Pipeline;
using Mysoft.Map6.TestCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysoft.Clgyl.ProjectPrep.UnitTest.AppServices
{
	/// <summary>
    /// 单测 
    /// </summary>
    [TestFixture]
    public class ProviderAppServiceTest
    {
		private readonly ProviderAppService _providerAppService = new ProviderAppService();

        private readonly StubProviderDomainService _providerDomainService = new StubProviderDomainService();
        
        private readonly StubFormEntityDomainService _formEntity = new StubFormEntityDomainService();

        private readonly EntityMocker<Provider> _providerMock = new EntityMocker<Provider>();
        
        #region 接口服务
        #endregion

        [SetUp]
        public void InitResource()
        {
            TestMockServiceResolver.RegisterInstance<FormEntityDomainService, StubFormEntityDomainService>(_formEntity);

            TestMockServiceResolver.RegisterInstance<ProviderDomainService, StubProviderDomainService>(_providerDomainService);

        }

        [Test(Description = "测试单测")]
        public void Test1()
        {
            
        }
	}
}